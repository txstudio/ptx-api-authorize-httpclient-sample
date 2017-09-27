using System;
using System.Security.Cryptography;
using System.Text;

namespace PTXHttpClientExtension
{
    internal sealed class SignatureHelper
    {
        const string _encodingName = "utf-8";

        /// <summary>建立驗證簽章</summary>
        /// <param name="xDate"></param>
        /// <param name="appKey"></param>
        /// <returns>使用 HMACSHA1 雜湊</returns>
        public static string GetSignature(string xDate, string appKey)
        {
            Encoding _encoding;

            byte[] _xDateBytes;
            byte[] _appKeyBytes;
            byte[] _hashBytes;

            string _base64String;


            _encoding = Encoding.GetEncoding(_encodingName);

            _xDateBytes = _encoding.GetBytes(xDate);
            _appKeyBytes = _encoding.GetBytes(appKey);

            using (HMACSHA1 _HMacSha1 = new HMACSHA1(_appKeyBytes))
            {
                _hashBytes = _HMacSha1.ComputeHash(_xDateBytes);
            }

            _base64String = Convert.ToBase64String(_hashBytes);

            return _base64String;
        }

    }
}
