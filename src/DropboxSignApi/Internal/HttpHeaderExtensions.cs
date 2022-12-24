using System.Linq;
using System.Net.Http.Headers;

namespace DropboxSignApi
{
    static class HttpHeaderExtensions
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
