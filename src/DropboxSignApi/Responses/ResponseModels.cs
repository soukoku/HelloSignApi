﻿using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

// this file contains reponse wrapper models.

namespace DropboxSignApi.Responses
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

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Message ?? Name;
        }
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

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Message ?? Name;
        }
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

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Page {Page}/{TotalPages}";
        }
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

    /// <summary>
    /// Response for the signature request api calls.
    /// </summary>
    public class SignatureRequestResponse : ApiResponse
    {
        /// <summary>
        /// The signature request object.
        /// </summary>
        public SignatureRequest SignatureRequest { get; set; }
    }

    /// <summary>
    /// Response for the signature request list api call.
    /// </summary>
    public class SignatureRequestListResponse : ListApiResponse
    {
        /// <summary>
        /// The signature request objects.
        /// </summary>
        public SignatureRequest[] SignatureRequests { get; set; }
    }

    /// <summary>
    /// Response for the template api calls.
    /// </summary>
    public class TemplateResponse : ApiResponse
    {
        /// <summary>
        /// The template object.
        /// </summary>
        public Template Template { get; set; }
    }

    /// <summary>
    /// Response for creating new template call.
    /// </summary>
    public class NewTemplateResponse : ApiResponse
    {
        /// <summary>
        /// The embedded edit object for the new template.
        /// </summary>
        public EmbeddedTemplate Template { get; set; }
    }

    /// <summary>
    /// Response for the template list api call.
    /// </summary>
    public class TemplateListResponse : ListApiResponse
    {
        /// <summary>
        /// The template objects.
        /// </summary>
        public Template[] Templates { get; set; }
    }

    /// <summary>
    /// An object that contains file download info.
    /// </summary>
    public class DownloadInfo : ExpiringObject
    {
        /// <summary>
        /// URL of the download url.
        /// </summary>
        public string FileUrl { get; set; }
    }

    /// <summary>
    /// Response for the get file api call with download url.
    /// </summary>
    public class DownloadInfoResponse : ApiResponse
    {
        /// <summary>
        /// The download info object.
        /// </summary>
        public DownloadInfo DownloadInfo { get; internal set; }
    }

    /// <summary>
    /// Response for the get file api call with download url.
    /// </summary>
    public class DownloadDataResponse : ApiResponse
    {
        /// <summary>
        /// The download data response.
        /// </summary>
        public HttpResponseMessage FileResponse { get; internal set; }
    }

    /// <summary>
    /// Response for the team api calls.
    /// </summary>
    public class TeamResponse : ApiResponse
    {
        /// <summary>
        /// The team object.
        /// </summary>
        public Team Team { get; set; }
    }

    /// <summary>
    /// Response for the unclaimed draft api calls.
    /// </summary>
    public class UnclaimedDraftResponse : ApiResponse
    {
        /// <summary>
        /// The unclaimed draft object.
        /// </summary>
        public UnclaimedDraft UnclaimedDraft { get; set; }
    }

    /// <summary>
    /// Response for the embedded sign api call.
    /// </summary>
    public class EmbeddedSignResponse : ApiResponse
    {
        /// <summary>
        /// The <see cref="EmbeddedSign"/> object.
        /// </summary>
        public EmbeddedSign Embedded { get; set; }
    }

    /// <summary>
    /// Response for the embedded template edit api call.
    /// </summary>
    public class EmbeddedTemplateResponse : ApiResponse
    {
        /// <summary>
        /// The <see cref="EmbeddedTemplate"/> object.
        /// </summary>
        public EmbeddedTemplate Embedded { get; set; }
    }

    /// <summary>
    /// Response for the signature request api calls.
    /// </summary>
    public class ApiAppResponse : ApiResponse
    {
        /// <summary>
        /// The api app object.
        /// </summary>
        public ApiApp ApiApp { get; set; }
    }

    /// <summary>
    /// Response for the api app list api call.
    /// </summary>
    public class ApiAppListResponse : ListApiResponse
    {
        /// <summary>
        /// The api app objects.
        /// </summary>
        public ApiApp[] ApiApps { get; set; }
    }
}
