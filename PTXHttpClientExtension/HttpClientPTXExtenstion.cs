using System.Net.Http;

namespace PTXHttpClientExtension
{
    public static class HttpClientPTXExtenstion
    {
        public static void SetSignature(this HttpClient client, string appID, string appKey)
        {
            HttpClientHelper _helper;

            _helper = new HttpClientHelper(appID, appKey);
            _helper.SetRequestHeader(client);
        }
    }
}
