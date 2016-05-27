using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

// this file contains reponse object models.

namespace HelloSignApi
{
    /// <summary>
    /// Error object for an <see cref="ApiResponse"/>.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Error details.
        /// </summary>
        [JsonProperty("error_msg")]
        public string Message { get; set; }

        /// <summary>
        /// Short name for error. See <see cref="ErrorNames"/>.
        /// </summary>
        [JsonProperty("error_name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Warning object for an <see cref="ApiResponse"/>.
    /// </summary>
    public class Warning
    {
        /// <summary>
        /// Warning details.
        /// </summary>
        [JsonProperty("warning_msg")]
        public string Message { get; set; }

        /// <summary>
        /// Short name for warning. See <see cref="WarningNames"/>.
        /// </summary>
        [JsonProperty("warning_name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Basic response from calling the api.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Gets the error.
        /// </summary>
        public Error Error { get; set; }

        /// <summary>
        /// Gets the warnings.
        /// </summary>
        public Warning[] Warnings { get; set; }

        internal void FillExtraValues(HttpResponseMessage httpResponse)
        {
            if (httpResponse != null)
            {
                HttpStatusCode = httpResponse.StatusCode;

                RateLimit = httpResponse.Headers.ParseInt("X-Ratelimit-Limit");
                RateLimitRemaining = httpResponse.Headers.ParseInt("X-Ratelimit-Limit-Remaining");
                RateLimitResetTime = httpResponse.Headers.ParseLong("X-Ratelimit-Reset").ToUnixTime();
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

    /// <summary>
    /// Contains paging info for a <see cref="ListApiResponse"/>.
    /// </summary>
    public class ListInfo
    {
        /// <summary>
        /// Total number of pages available.
        /// </summary>
        [JsonProperty("num_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Total number of objects available.
        /// </summary>
        [JsonProperty("num_results")]
        public int TotalCount { get; set; }

        /// <summary>
        /// Number of the page being returned.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Objects returned per page.
        /// </summary>
        public int PageSize { get; set; }
    }

    /// <summary>
    /// Basic response from calling a list api.
    /// </summary>
    public class ListApiResponse : ApiResponse
    {
        /// <summary>
        /// Gets the paging info for the response.
        /// </summary>
        public ListInfo ListInfo { get; set; }
    }

    /// <summary>
    /// Response for the account api calls.
    /// </summary>
    public class AccountResponse : ApiResponse
    {
        /// <summary>
        /// The account object.
        /// </summary>
        public Account Account { get; set; }
    }
}
