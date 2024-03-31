
# LineBot Azure Functions

LineBotを提供するAzure Functionsです。

## 前提条件
- .net 6.0以上、HttpトリガーのAzure Functionsが必要です。
- LINE Developersアカウント及び作成したBotチャネルの作成、友達登録が必要です。
- Botチャネルの応答メッセージは無効にしておく必要があります。
- LINE Messaging APIのアクセストークンが必要です。

## 使用方法

1. **環境変数の設定：**  
    Azure Functionsで使用する環境変数を設定します。  
    `LINE_CHANNEL_ACCESS_TOKEN`にLINE Messaging APIのチャネルアクセストークンを設定します。  

2. **Azure Functionのデプロイ：**  
    作成したC#コードをAzure Functionsにデプロイします。

3. **LINE Webhook URLの設定：**  
    Azure FunctionsのURLをLINE Messaging APIのWebhook URLとして設定します。  
    これにより、BotチャネルへのメッセージがAzure Functionsに送信されるようになります。

4. **動作確認：**  
    LINEアカウントからBotチャネルにメッセージを送信し、Azure Functionsからメッセージが返ってくることを確認します。

5. **機能拡張：**  
    `ResponseMessage`クラスの`GetResponseMessage`メソッドを修正することで返答メッセージをカスタマイズします。


