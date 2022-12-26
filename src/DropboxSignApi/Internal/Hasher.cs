using System;
using System.Security.Cryptography;
using System.Text;

namespace DropboxSignApi.Internal
{
    /// <summary>
    /// Produces hashes.
    /// </summary>
    static class Hasher
    {
        /// <summary>
        /// Generates a HMACSHA256 hash from a string input.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetHMACSHA256Hash(byte[] key, string input)
        {
            using (var algo = new HMACSHA256(key))
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var hash = BitConverter.ToString(algo.ComputeHash(inputBytes));
                return hash.Replace("-", "");
            }

            //using System.Runtime.InteropServices.WindowsRuntime;
            //using Windows.Security.Cryptography.Core;
            //var macProv = MacAlgorithmProvider.OpenAlgorithm(MacAlgorithmNames.HmacSha256);
            //CryptographicKey hmacKey = macProv.CreateKey(key.AsBuffer());
            //var hmac = CryptographicEngine.Sign(hmacKey, input.AsBuffer());
            //var hash = BitConverter.ToString(hmac.ToArray());
            //return hash.Replace("-", "");
        }
    }
}
