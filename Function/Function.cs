using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace LineBotAzureFunction
{
    public static class Function
    {
        private static readonly string LineChannelAccessToken = Environment.GetEnvironmentVariable("LINE_CHANNEL_ACCESS_TOKEN");

        [FunctionName("Function")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                log.LogInformation(requestBody);

                dynamic data = JsonConvert.DeserializeObject(requestBody);
                string lineUserId = data?.events[0]?.source?.userId;
                string message = data?.events[0]?.message?.text;
                log.LogInformation($"line_user_id {lineUserId}");
                log.LogInformation($"message {message}");
                if (string.IsNullOrEmpty(lineUserId) || string.IsNullOrEmpty(message))
                {
                    log.LogInformation("lineUserId or message is null or empty.");
                    return new OkObjectResult("Skip End.");
                }

                var response = message;
                await SendMessageToLine(lineUserId, response);

                return new OkObjectResult("Success.");
            }
            catch (Exception e)
            {
                log.LogError($"Error: {e}");
                return new StatusCodeResult(500);
            }
        }

        private static async Task SendMessageToLine(string userId, string message)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = "https://api.line.me/v2/bot/message/push";
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {LineChannelAccessToken}");

                    var postData = new
                    {
                        to = userId,
                        messages = new[] { new { type = "text", text = message } }
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"LINE API response {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error user:{userId} message:{message} {e}");
            }
        }
    }
}
