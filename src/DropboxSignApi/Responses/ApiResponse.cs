using DropboxSignApi.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Basic response from calling the api.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Contains information about an error that occurred.
        /// </summary>
        public Error Error { get; set; }

        /// <summary>
        /// A list of warnings.
        /// </summary>
        public IList<Warning> Warnings { get; set; }

        internal void FillExtraValues(HttpResponseMessage httpResponse)
        {
            if (httpResponse != null)
            {
                HttpStatusCode = httpResponse.StatusCode;

                RateLimit = httpResponse.Headers.ParseInt("X-Ratelimit-Limit");
                RateLimitRemaining = httpResponse.Headers.ParseInt("X-Ratelimit-Limit-Remaining");
                RateLimitResetTime = httpResponse.Headers.ParseLong("X-Ratelimit-Reset").FromUnixTime();
            }
        }

        #region nice extra values

        /// <summary>
        /// Gets the actual http status code of the response.
        /// </summary>
        [JsonIgnore]
        public HttpStatusCode HttpStatusCode { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this response is considered a success.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess { get { return HttpStatusCode == HttpStatusCode.OK && Error == null; } }

        /// <summary>
        /// The maximum number of requests per hour that you can make.
        /// </summary>
        [JsonIgnore]
        public int RateLimit { get; private set; }
        /// <summary>
        /// The number of requests remaining in the current rate limit window.
        /// </summary>
        [JsonIgnore]
        public int RateLimitRemaining { get; private set; }
        /// <summary>
        /// The time at which the rate limit will reset to its maximum.
        /// </summary>
        [JsonIgnore]
        public DateTime RateLimitResetTime { get; private set; }

        #endregion
    }
}
