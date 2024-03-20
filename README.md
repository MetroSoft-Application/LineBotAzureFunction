
# LineBot Azure Function

LineBotを提供するAzure Fuctionsです。

## 前提条件
- .net 6.0以上、HttpトリガーのAzure Fuctionsが必要です。
- LINE Developersアカウント及び作成したBotチャネルの作成、友達登録が必要です。
- Botチャネルの応答メッセージは無効にしておく必要があります。
- LINE Messaging APIのアクセストークンが必要です。

## 使用方法

1. **環境変数の設定：**  
    Azure Fuctionsで使用する環境変数を設定します。  
    `LINE_CHANNEL_ACCESS_TOKEN`にLINE Messaging APIのチャネルアクセストークンを設定します。  

2. **Azure Functionのデプロイ：**  
    作成したC#コードをAzure Fuctionsにデプロイします。

3. **LINE Webhook URLの設定：**  
    Azure FuctionsのURLをLINE Messaging APIのWebhook URLとして設定します。  
    これにより、BotチャネルへのメッセージがAzure Fuctionsに送信されるようになります。

4. **動作確認：**  
    LINEアカウントからBotチャネルにメッセージを送信し、Azure Fuctionsからメッセージが返ってくることを確認します。

5. **機能拡張：**  
    `ResponseMessage`クラスの`GetResponseMessage`メソッドを修正することで返答メッセージをカスタマイズします。


