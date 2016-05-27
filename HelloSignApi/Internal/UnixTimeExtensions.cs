using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloSignApi
{
    static class UnixTimeExtensions
    {
        static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ToUnixTime(this long value)
        {
            return Epoch.AddSeconds(value);
        }
    }
}
