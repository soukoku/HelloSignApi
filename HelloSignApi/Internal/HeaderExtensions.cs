using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace HelloSignApi
{
    static class HeaderExtensions
    {
        public static int ParseInt(this HttpResponseHeaders header, string key, int defaultValue = 0)
        {
            var hit = header.FirstOrDefault(h => h.Key == key);
            if (hit.Value != null && hit.Value.Count() > 0)
            {
                return int.Parse(hit.Value.First());
            }
            return defaultValue;
        }

        public static long ParseLong(this HttpResponseHeaders header, string key, long defaultValue = 0)
        {
            var hit = header.FirstOrDefault(h => h.Key == key);
            if (hit.Value != null && hit.Value.Count() > 0)
            {
                return long.Parse(hit.Value.First());
            }
            return defaultValue;
        }
    }
}
