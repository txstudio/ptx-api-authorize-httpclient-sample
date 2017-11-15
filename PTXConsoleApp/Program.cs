using PTXHttpClientExtension;
using System;
using System.Net.Http;

namespace PTXConsoleApp
{
    class Program
    {
        //請替換為串接使用的 appID 與 appKey
        const string appID = "your appID";
        const string appKey = "your appKey";

        const string baseAddress = "http://ptx.transportdata.tw/";
        const string requestUri = "/MOTC/v2/Air/FIDS/Airport/TNN?$format=json";

        static void Main(string[] args)
        {
            HttpClient _client;
            string _html;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseAddress);

            Console.WriteLine("start api request");

            for (int i = 0; i < 10; i++)
            {
                //設定 RequestHeader 驗證簽章
                _client.SetSignature(appID, appKey);

                var _response = _client.GetAsync(requestUri).Result;

                if (_response.IsSuccessStatusCode == true)
                {
                    _html = _response.Content.ReadAsStringAsync().Result;

                    Console.WriteLine("{0}\t{1}\t{2}"
                                    , i
                                    , _response.StatusCode
                                    , _html.Substring(0, 50));
                }
            }

            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}
