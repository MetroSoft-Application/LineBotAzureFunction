using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotAzureFunction
{
    internal static class ResponseMessage
    {
        public static string GetDummyResponseMessage() 
        {
            return DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(9)).DateTime.ToString("yyyy/MM/dd HH:mm:ss ffff");
        }
    }
}
