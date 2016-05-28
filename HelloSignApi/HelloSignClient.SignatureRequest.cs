using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloSignApi
{
    // this contains signature request api methods

    partial class HelloSignClient
    {
        const string SignatureUrl = "https://api.hellosign.com/v3/signature_request";

        /// <summary>
        /// Returns the status of the SignatureRequest specified by the signature_request_id parameter.
        /// </summary>
        /// <param name="signatureRequestId">The id of the SignatureRequest to retrieve.</param>
        /// <returns></returns>
        public Task<SignatureRequestResponse> GetSignatureRequestAsync(string signatureRequestId)
        {
            var resp = _client.GetAsync($"{SignatureUrl}/{signatureRequestId}")
                .ContinueWith(t => t.Result.ParseApiResponseAsync<SignatureRequestResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Returns a list of SignatureRequests that you can access. This includes SignatureRequests you have sent as well as received, but not ones that you have been CCed on.
        /// </summary>
        /// <param name="accountId">Which account to return SignatureRequests for. Must be a team member. Use "all" to indicate all team members. Defaults to your account.</param>
        /// <param name="page">Which page number of the SignatureRequest List to return. Defaults to 1.</param>
        /// <param name="pageSize">Number of objects to be returned per page. Must be between 1 and 100. Default is 20.</param>
        /// <param name="query">String that includes search terms and/or fields to be used to filter the SignatureRequest objects.</param>
        /// <returns></returns>
        public Task<SignatureRequestListResponse> GetSignatureRequestListAsync(string accountId = null, int page = 1, int pageSize = 20, string query = null)
        {
            page = Math.Max(1, page);
            pageSize = Math.Min(100, Math.Max(1, pageSize));

            var resp = _client.GetAsync($"{SignatureUrl}/list?account_id={accountId}&page={page}&page_size={pageSize}&query={query}")
                .ContinueWith(t => t.Result.ParseApiResponseAsync<SignatureRequestListResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Obtain a copy of the current documents specified by the signatureRequestId parameter.
        /// If the files are currently being prepared, a status code of 409 will be returned instead.
        /// </summary>
        /// <param name="signatureRequestId">The id of the SignatureRequest to retrieve.</param>
        /// <returns></returns>
        public Task<DownloadInfoResponse> GetFilesAsync(string signatureRequestId)
        {
            var resp = _client.GetAsync($"{SignatureUrl}/files/{signatureRequestId}?get_url=1")
                .ContinueWith(t =>
                {
                    var dir = new DownloadInfoResponse();
                    dir.FillExtraValues(t.Result);

                    return t.Result.Content.ReadAsStringAsync().ContinueWith(t2 =>
                    {
                        var json = t2.Result;

                        var model = JsonConvert.DeserializeObject<DownloadInfo>(json, HttpResponseExtensions.JsonSettings);
                        dir.DownloadInfo = model;
                        return dir;
                    });
                });
            return resp.Unwrap();
        }

        /// <summary>
        /// Obtain a copy of the current documents specified by the signatureRequestId parameter.
        /// If the files are currently being prepared, a status code of 409 will be returned instead.
        /// </summary>
        /// <param name="signatureRequestId">The id of the SignatureRequest to retrieve.</param>
        /// <param name="fileType">Set to <see cref="FileType.Pdf"/> for a single merged document or 
        /// <see cref="FileType.Zip"/> for a collection of individual documents.</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> GetFilesAsync(string signatureRequestId, FileType fileType)
        {
            var ft = fileType == FileType.Zip ? "zip" : "pdf";

            return _client.GetAsync($"{SignatureUrl}/files/{signatureRequestId}?file_type={ft}");
        }

        /// <summary>
        /// Indicates the file type to download.
        /// </summary>
        public enum FileType
        {
            /// <summary>
            /// Pdf file.
            /// </summary>
            Pdf,
            /// <summary>
            /// Zip file.
            /// </summary>
            Zip
        }
    }
}
