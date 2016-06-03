using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloSignApi
{
    static class Hasher
    {
        public static string GetHMACSHA256Hash(byte[] key, byte[] input)
        {
#if DESKTOP
            using (var hmac = new System.Security.Cryptography.HMACSHA256(key))
            {
                var hash = BitConverter.ToString(hmac.ComputeHash(input));
                return hash.Replace("-", "");
            }
#else

#endif
        }
    }
}
