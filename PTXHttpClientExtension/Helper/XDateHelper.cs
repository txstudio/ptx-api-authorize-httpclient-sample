using System;

namespace PTXHttpClientExtension
{
    internal sealed class XDateHelper
    {
        const string _dateFormat = "r";

        public static string GetXDate()
        {
            DateTime _utcTime;
            string _xDate;

            _utcTime = DateTime.UtcNow.AddSeconds(1);
            _xDate = _utcTime.ToString(_dateFormat);

            return _xDate;
        }
    }
}
