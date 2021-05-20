using PTXHttpClientExtension;
using System;
using System.Net;
using System.Net.Http;

namespace PTXConsoleApp
{
    class Program
    {
        //請替換為串接使用的 appID 與 appKey
        const string appID = "your appID";
        const string appKey = "your appKey";

        const string baseAddress = "https://ptx.transportdata.tw/";
        const string requestUri = "/MOTC/v2/Air/FIDS/Airport/TNN?$format=json";

        static void Main(string[] args)
        {
            string _json;
            
            HttpClient _client;
            HttpClientHandler _clientHandler;

            _clientHandler = new HttpClientHandler();

            //啟用 GZip, Deflate 壓縮傳輸 / 減少傳遞的資料量
            _clientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            _client = new HttpClient(_clientHandler);
            _client.BaseAddress = new Uri(baseAddress);


            Console.WriteLine("start api request");

            for (int i = 0; i < 10; i++)
            {
                //設定 RequestHeader 驗證簽章
                _client.SetSignature(appID, appKey);

                var _response = _client.GetAsync(requestUri).Result;

                if (_response.IsSuccessStatusCode == true)
                {
                    _json = _response.Content.ReadAsStringAsync().Result;

                    Console.WriteLine("{0}\t{1}\t{2}"
                                    , i
                                    , _response.StatusCode
                                    , _json.Substring(0, 50));
                }
                else
                {
                    Console.WriteLine("Status Cdoe: {0}", (int)_response.StatusCode);
                    Console.WriteLine("Message: {0}", _response.ReasonPhrase);
                }
            }

            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}
