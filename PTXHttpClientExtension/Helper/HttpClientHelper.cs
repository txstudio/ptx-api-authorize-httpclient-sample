using System.Net.Http;

namespace PTXHttpClientExtension
{
    internal sealed class HttpClientHelper
    {
        const string header_authorization = "Authorization";
        const string header_xDate = "x-date";

        private string _appID;
        private string _appKey;

        private string _xDate;

        public HttpClientHelper(string appID, string appKey)
        {
            this._appID = appID;
            this._appKey = appKey;
        }


        /// <summary>設定 HttpClient 物件提供驗證的 RequestHeader 內容</summary>
        /// <param name="client">HttpClient 呼叫物件</param>
        public void SetRequestHeader(HttpClient client)
        {
            this._xDate = XDateHelper.GetXDate();


            var _requestHeaders = client.DefaultRequestHeaders;
            var _authorization = this.GetAuthorizationHeaderValue();


            //指定 Header 資料存在的話移除 Header
            if (_requestHeaders.Contains(header_authorization) == true)
                _requestHeaders.Remove(header_authorization);

            if (_requestHeaders.Contains(header_xDate) == true)
                _requestHeaders.Remove(header_xDate);


            _requestHeaders.Add(header_authorization, _authorization);
            _requestHeaders.Add(header_xDate, this._xDate);
        }

        private string GetAuthorizationHeaderValue()
        {
            string _signature;
            string _xDate;

            _xDate = this.GetXDateHeaderValue();
            _signature = SignatureHelper.GetSignature(_xDate, this._appKey);

            return string.Format($"hmac username=\"{this._appID}\", algorithm=\"hmac-sha1\", headers=\"x-date\", signature=\"{_signature}\"");
        }


        private string GetXDateHeaderValue()
        {
            // return "x-date: Wed, 27 Sep 2017 02:02:55 GMT"

            return string.Format($"{header_xDate}: {this._xDate}");
        }

    }
}
