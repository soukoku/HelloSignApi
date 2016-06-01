using HelloSignApi.Requests;
using HelloSignApi.Responses;
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
        /// <exception cref="ArgumentException">Signature request id is required.</exception>
        public Task<SignatureRequestResponse> GetSignatureRequestAsync(string signatureRequestId)
        {
            if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }

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
        /// Creates and sends a new SignatureRequest with the submitted documents. If form_fields_per_document is not specified, a signature page will be affixed where all signers will be required to add their signature, signifying their agreement to all contained documents.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">request</exception>
        public Task<SignatureRequestResponse> SendSignatureRequestAsync(NewSignatureRequest request)
        {
            return SendSignatureRequestAsync(request, CancellationToken.None);
        }
        /// <summary>
        /// Creates and sends a new SignatureRequest with the submitted documents. If form_fields_per_document is not specified, a signature page will be affixed where all signers will be required to add their signature, signifying their agreement to all contained documents.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">request</exception>
        public Task<SignatureRequestResponse> SendSignatureRequestAsync(NewSignatureRequest request, CancellationToken cancellationToken)
        {
            if (request == null) { throw new ArgumentNullException("request"); }

            var content = new MultipartFormDataContent();
            content.AddRequest(request);

            var resp = _client.PostAsync($"{SignatureUrl}/send", content, cancellationToken)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<SignatureRequestResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Sends an email to the signer reminding them to sign the signature request. You cannot send a reminder within 1 hour of the last reminder that was sent. This includes manual AND automatic reminders.
        /// </summary>
        /// <param name="signatureRequestId">The id of the SignatureRequest to send a reminder for.</param>
        /// <param name="emailAddress">The email address of the signer to send a reminder to.</param>
        /// <param name="name">The name of the signer to send a reminder to. Include if two or more signers share an email address.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// Signature request id is required.
        /// or
        /// Email address is required.
        /// </exception>
        public Task<SignatureRequestResponse> SendRequestReminderAsync(string signatureRequestId, string emailAddress, string name = null)
        {
            if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }
            if (string.IsNullOrEmpty(emailAddress)) { throw new ArgumentException("Email address is required."); }

            var content = new MultipartFormDataContent();
            content.AddParameter("email_address", emailAddress);
            content.AddParameter("name", name);

            var resp = _client.PostAsync($"{SignatureUrl}/remind/{signatureRequestId}", content)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<SignatureRequestResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Queues a SignatureRequest to be canceled. The cancelation is asynchronous and a successful call to this endpoint will return a 200 OK response if the signature request is eligible to be canceled and has been successfully queued. To be eligible for cancelation, a signature request must have been sent successfully and must be unsigned. Once canceled, singers will not be able to sign the signature request or access its documents. Canceling a signature request is not reversible.
        /// </summary>
        /// <param name="signatureRequestId">The id of the SignatureRequest to cancel.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Signature request id is required.</exception>
        public Task<ApiResponse> CancelSignatureRequestAsync(string signatureRequestId)
        {
            if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }

            var resp = _client.PostAsync($"{SignatureUrl}/cancel/{signatureRequestId}", null)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<ApiResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Obtain a copy of the current documents specified by the signatureRequestId parameter.
        /// If the files are currently being prepared, a status code of 409 will be returned instead.
        /// </summary>
        /// <param name="signatureRequestId">The id of the SignatureRequest to retrieve.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Signature request id is required.</exception>
        public Task<DownloadInfoResponse> GetFilesAsync(string signatureRequestId)
        {
            if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }

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
        /// <param name="fileType">Set to <see cref="FileType.Pdf" /> for a single merged document or
        /// <see cref="FileType.Zip" /> for a collection of individual documents.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Signature request id is required.</exception>
        public Task<HttpResponseMessage> GetFilesAsync(string signatureRequestId, FileType fileType)
        {
            if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }

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

        /// <summary>
        /// Creates a new SignatureRequest with the submitted documents to be signed in an embedded iFrame. If form_fields_per_document is not specified, a signature page will be affixed where all signers will be required to add their signature, signifying their agreement to all contained documents. Note that embedded signature requests can only be signed in embedded iFrames whereas normal signature requests can only be signed on HelloSign.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">request</exception>
        public Task<SignatureRequestResponse> SendEmbeddedSignatureRequestAsync(NewEmbeddedSignatureRequest request)
        {
            return SendEmbeddedSignatureRequestAsync(request, CancellationToken.None);
        }
        /// <summary>
        /// Creates a new SignatureRequest with the submitted documents to be signed in an embedded iFrame. If form_fields_per_document is not specified, a signature page will be affixed where all signers will be required to add their signature, signifying their agreement to all contained documents. Note that embedded signature requests can only be signed in embedded iFrames whereas normal signature requests can only be signed on HelloSign.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">request</exception>
        public Task<SignatureRequestResponse> SendEmbeddedSignatureRequestAsync(NewEmbeddedSignatureRequest request, CancellationToken cancellationToken)
        {
            if (request == null) { throw new ArgumentNullException("request"); }

            var content = new MultipartFormDataContent();
            content.AddEmbeddedRequest(request);

            var resp = _client.PostAsync($"{SignatureUrl}/create_embedded", content, cancellationToken)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<SignatureRequestResponse>());
            return resp.Unwrap();
        }
    }
}
