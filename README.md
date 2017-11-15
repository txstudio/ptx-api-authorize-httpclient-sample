# 公共運輸整合資訊流通服務平台串接範例程式碼

因網站提供的 CSharp API 串接範例程式碼使用 WebClient 類別，故撰寫一份使用 CSharp 與 .NET Standard 擴充 HttpClient 方法進行 PTX API 串接簽章驗證的類別庫範例程式碼。

> 公共運輸整合資訊流通服務平台會因需要變更驗證流程，請務必先行驗證無誤後再使用至生產環境。

### 方案架構
|專案名稱|類型|備註|
|--|--|--|
|PTXConsoleApp|主控台應用程式|有 HttpClient 啟用 GZip 與 Deflate 功能的程式碼片段|
|PTXHttpClientExtension|.NET Standard 2.0 類別庫|--|

> 主控台應用程式專案 .NET Framework 版本為 .NET Framework 4.6.1

### 使用方式

設定 PTXConsoleApp 為起始專案，替換 appID 與 appKey 字串即可測試是否可呼叫成功。

> 依照需求調整程式碼內容測試更多 API 呼叫方法。

### PTXHttpClientExtension 程式碼說明

擴充 HttpClient 類別加入 SetSignature 方法指定 appID 與 appKey 參數設定驗證使用 RequestHeader，每次進行 API 呼叫時皆需要呼叫此方法。

使用此類別庫時請確認 .NET Standard 2.0 支援的版本資訊。

### 參考資料

- [公共運輸整合資訊流通服務平台網址](http://ptx.transportdata.tw/PTX)
- [串接範例程式碼](https://github.com/ptxmotc/Sample-code)
