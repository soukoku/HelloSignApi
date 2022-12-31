using Soukoku.DropboxSignApi.Internal;
using Soukoku.DropboxSignApi.Utils;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Soukoku.DropboxSignApi
{
    partial class DropboxSignClient
    {
        /// <summary>
        /// Parses the event from the received multipart content.
        /// </summary>
        /// <param name="content">Content from the callback.</param>
        /// <param name="verify">Validate the event for integrity. 
        /// If validation fails the return value is null.</param>
        /// <returns></returns>
        public async Task<EventCallbackWrap> ParseEventAsync(MultipartFormDataContent content, bool verify = true)
        {
            if (content != null)
            {
                var part = content.FirstOrDefault(c => c.Headers.ContentDisposition != null &&
                    c.Headers.ContentDisposition.DispositionType == "form-data" &&
                    c.Headers.ContentDisposition.Name.Trim('"') == "json");
                if (part != null)
                {
                    var json = await part.ReadAsStringAsync().ConfigureAwait(false);
                    return ParseEvent(json, verify);
                }
            }

            return null;
        }

        /// <summary>
        /// Parses the json data received from the event callback.
        /// </summary>
        /// <param name="eventJson">json data from the callback.</param>
        /// <param name="verify">Validate the event for integrity. 
        /// If validation fails the return value is null.</param>
        /// <returns></returns>
        public EventCallbackWrap ParseEvent(string eventJson, bool verify = true)
        {
            var wrap = JsonConvert.DeserializeObject<EventCallbackWrap>(eventJson ?? "", JsonExtensions.JsonSettings);
            if (verify && wrap != null && wrap.Event != null)
            {
                var key = Encoding.UTF8.GetBytes(_apiKey);
                var hashInput = $"{wrap.Event.EventTime.ToUnixTime()}{wrap.Event.EventType}";
                var hash = Hasher.GetHMACSHA256Hash(key, hashInput);
                if (!string.Equals(hash, wrap.Event.EventHash, StringComparison.OrdinalIgnoreCase))
                {
                    wrap = null;
                }
            }
            return wrap;
        }
    }
}
