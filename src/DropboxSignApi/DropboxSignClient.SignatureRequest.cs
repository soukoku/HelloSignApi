using DropboxSignApi.Requests;
using DropboxSignApi.Responses;
using DropboxSignApi.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DropboxSignApi
{
    // this contains signature request api methods

    partial class DropboxSignClient
    {
        const string SignatureUrl = "https://api.hellosign.com/v3/signature_request";

        /// <summary>
        /// Returns the status of the SignatureRequest specified by the signature_request_id parameter.
        /// </summary>
        /// <param name="signatureRequestId">The id of the SignatureRequest to retrieve.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Signature request id is required.</exception>
        public Task<SignatureRequestResponseWrap> GetSignatureRequestAsync(string signatureRequestId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }

            return GetAsync<SignatureRequestResponseWrap>($"{SignatureUrl}/{Uri.EscapeDataString(signatureRequestId)}", cancellationToken);
        }

        /// <summary>
        /// Returns a list of SignatureRequests that you can access. This includes SignatureRequests you have sent as well as received, 
        /// but not ones that you have been CCed on.
        /// </summary>
        /// <param name="accountId">Which account to return SignatureRequests for. Must be a team member. 
        /// Use "all" to indicate all team members. Defaults to your account.</param>
        /// <param name="page">Which page number of the SignatureRequest List to return. Defaults to 1.</param>
        /// <param name="pageSize">Number of objects to be returned per page. Must be between 1 and 100. Default is 20.</param>
        /// <param name="query">String that includes search terms and/or fields to be used to filter the SignatureRequest objects. 
        /// You can use <see cref="ListQueyBuilder"/> to generate it.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<SignatureRequestListResponseWrap> GetSignatureRequestListAsync(string accountId = null, 
            int page = 1, int pageSize = 20, string query = null,
            CancellationToken cancellationToken = default)
        {
            page = Math.Max(1, page);
            pageSize = Math.Min(100, Math.Max(1, pageSize));

            return GetAsync<SignatureRequestListResponseWrap>($"{SignatureUrl}/list?account_id={Uri.EscapeDataString(accountId)}&page={page}&page_size={pageSize}&query={query}", cancellationToken);
        }

        /// <summary>
        /// Obtain a copy of the current documents specified by the signature_request_id parameter. Returns a PDF or ZIP file.
        /// If the files are currently being prepared, a status code of 409 will be returned instead.
        /// </summary>
        /// <param name="signatureRequestId">The id of the SignatureRequest to retrieve.</param>
        /// <param name="fileType">Set to <see cref="FileType.Pdf" /> for a single merged document or
        /// <see cref="FileType.Zip" /> for a collection of individual documents.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Signature request id is required.</exception>
        public async Task<FileDownloadResponseWrap> GetRequestFilesAsync(string signatureRequestId, FileType fileType,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }

            var ft = fileType == FileType.Zip ? "zip" : "pdf";
            var url = $"{SignatureUrl}/files/{Uri.EscapeDataString(signatureRequestId)}?file_type={ft}";
            _log.Requesting("GET", url);
            var resp = await _client.GetAsync(url, cancellationToken).ConfigureAwait(false);
            var apiR = new FileDownloadResponseWrap();
            apiR.FillExtraValues(resp);
            apiR.FileResponse = resp;
            return apiR;
        }

        /// <summary>
        /// Obtain a copy of the current documents specified by the signature_request_id parameter. 
        /// Returns a object with a data_uri representing the base64 encoded file (PDFs only).
        /// </summary>
        /// <param name="signatureRequestId">The id of the SignatureRequest to retrieve.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<FileDataUriResponseWrap> GetRequestFileDataUriAsync(string signatureRequestId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }

            var url = $"{SignatureUrl}/files_as_data_uri/{Uri.EscapeDataString(signatureRequestId)}";
            return GetAsync<FileDataUriResponseWrap>(url, cancellationToken);
        }

        /// <summary>
        /// Obtain a copy of the current documents specified by the signatureRequestId parameter.
        /// If the files are currently being prepared, a status code of 409 will be returned instead.
        /// </summary>
        /// <param name="signatureRequestId">The id of the SignatureRequest to retrieve.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Signature request id is required.</exception>
        public Task<FileUrlResponseWrap> GetRequestFileUrlAsync(string signatureRequestId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }

            var url = $"{SignatureUrl}/files_as_file_url/{Uri.EscapeDataString(signatureRequestId)}";
            return GetAsync<FileUrlResponseWrap>(url, cancellationToken);
        }

        /// <summary>
        /// Creates and sends a new SignatureRequest with the submitted documents. 
        /// If <see cref="SendSignatureRequestRequest.FormFieldsPerDocument"/> is not specified, 
        /// a signature page will be affixed where all signers will be required to add their signature, 
        /// signifying their agreement to all contained documents.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">request</exception>
        public Task<SignatureRequestResponseWrap> SendSignatureRequestAsync(SendSignatureRequestRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request == null) { throw new ArgumentNullException(nameof(request)); }

            return PostAsync<SignatureRequestResponseWrap>($"{SignatureUrl}/send", new ApiMultipartContent(request, _log), cancellationToken);
        }

        /// <summary>
        /// Creates and sends a new SignatureRequest based off of the Templates specified.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">request</exception>
        public Task<SignatureRequestResponseWrap> SendSignatureFromTemplateRequestAsync(SendTemplatedSignatureRequestRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request == null) { throw new ArgumentNullException(nameof(request)); }

            return PostAsync<SignatureRequestResponseWrap>($"{SignatureUrl}/send_with_template", new ApiMultipartContent(request, _log), cancellationToken);
        }

        /// <summary>
        /// Creates BulkSendJob which sends up to 250 SignatureRequests in bulk based off of the 
        /// provided Template(s).
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">request</exception>
        public Task<BulkSendJobResponseWrap> BulkSendWithTemplateAsync(BulkSendWithTemplateRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request == null) { throw new ArgumentNullException(nameof(request)); }

            return PostAsync<BulkSendJobResponseWrap>($"{SignatureUrl}/bulk_send_with_template", new ApiMultipartContent(request, _log), cancellationToken);
        }

        /// <summary>
        /// Sends an email to the signer reminding them to sign the signature request. 
        /// You cannot send a reminder within 1 hour of the last reminder that was sent. 
        /// This includes manual AND automatic reminders.
        /// </summary>
        /// <param name="signatureRequestId">The id of the SignatureRequest to send a reminder for.</param>
        /// <param name="emailAddress">The email address of the signer to send a reminder to.</param>
        /// <param name="name">The name of the signer to send a reminder to. Include if two or more signers share an email address.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// Signature request id is required.
        /// or
        /// Email address is required.
        /// </exception>
        public Task<SignatureRequestResponseWrap> SendRequestReminderAsync(string signatureRequestId, 
            string emailAddress, string name = null,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }
            if (string.IsNullOrEmpty(emailAddress)) { throw new ArgumentException("Email address is required."); }

            var request = new { emailAddress, name };

            return PostAsync<SignatureRequestResponseWrap>($"{SignatureUrl}/remind/{Uri.EscapeDataString(signatureRequestId)}", request.ToJsonContent(_log), cancellationToken);
        }

        /// <summary>
        /// Releases a held SignatureRequest that was claimed and prepared from an UnclaimedDraft. 
        /// The owner of the Draft must indicate at Draft creation that the SignatureRequest created 
        /// from the Draft should be held. Releasing the SignatureRequest will send requests to all signers.
        /// </summary>
        /// <param name="signatureRequestId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Task<SignatureRequestResponseWrap> ReleaseOnHoldSignatureRequestAsync(string signatureRequestId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }

            return PostAsync<SignatureRequestResponseWrap>($"{SignatureUrl}/release_hold/{Uri.EscapeDataString(signatureRequestId)}", null, cancellationToken);
        }

        /// <summary>
        /// Updates the email address and/or the name for a given signer on a signature request. 
        /// You can listen for the signature_request_email_bounce event on your app or account to detect bounced emails, 
        /// and respond with this method.
        /// </summary>
        /// <param name="signatureRequestId">The id of the SignatureRequest to update.</param>
        /// <param name="request">The new data.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Task<SignatureRequestResponseWrap> UpdateSignatureRequestAsync(string signatureRequestId, 
            UpdateSignatureRequestRequest request,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }

            return PostAsync<SignatureRequestResponseWrap>($"{SignatureUrl}/update/{Uri.EscapeDataString(signatureRequestId)}", request.ToJsonContent(_log), cancellationToken);
        }


        ///// <summary>
        ///// Queues a SignatureRequest to be canceled. The cancelation is asynchronous and a successful call to this endpoint will return a 200 OK response if the signature request is eligible to be canceled and has been successfully queued. To be eligible for cancelation, a signature request must have been sent successfully and must be unsigned. Once canceled, singers will not be able to sign the signature request or access its documents. Canceling a signature request is not reversible.
        ///// </summary>
        ///// <param name="signatureRequestId">The id of the SignatureRequest to cancel.</param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        ///// <exception cref="ArgumentException">Signature request id is required.</exception>
        //public Task<ApiResponse> CancelSignatureRequestAsync(string signatureRequestId,
        //    CancellationToken cancellationToken = default)
        //{
        //    if (string.IsNullOrEmpty(signatureRequestId)) { throw new ArgumentException("Signature request id is required."); }

        //    return PostAsync<ApiResponse>($"{SignatureUrl}/cancel/{Uri.EscapeDataString(signatureRequestId)}", null, cancellationToken);
        //}

        ///// <summary>
        ///// Creates a new SignatureRequest with the submitted documents to be signed in an embedded iFrame. If <see cref="SendSignatureRequestRequest.FormFieldsPerDocument"/> is not specified, 
        ///// a signature page will be affixed where all signers will be required to add their signature, signifying their agreement to all contained documents. 
        ///// Note that embedded signature requests can only be signed in embedded iFrames whereas normal signature requests can only be signed on HelloSign.
        ///// </summary>
        ///// <param name="request">The request.</param>
        ///// <param name="cancellationToken">The cancellation token.</param>
        ///// <returns></returns>
        ///// <exception cref="ArgumentNullException">request</exception>
        //public Task<SignatureRequestResponseWrap> SendEmbeddedSignatureRequestAsync(SendSignatureRequestRequest request,
        //    CancellationToken cancellationToken = default)
        //{
        //    if (request == null) { throw new ArgumentNullException(nameof(request)); }

        //    return PostAsync<SignatureRequestResponseWrap>($"{SignatureUrl}/create_embedded", new ApiMultipartContent(request, _log), cancellationToken);
        //}

        ///// <summary>
        ///// Creates a new SignatureRequest based on the given Template to be signed in an embedded iFrame.
        ///// </summary>
        ///// <param name="request">The request.</param>
        ///// <param name="cancellationToken">The cancellation token.</param>
        ///// <returns></returns>
        ///// <exception cref="ArgumentNullException">request</exception>
        //public Task<SignatureRequestResponseWrap> SendEmbeddedSignatureFromTemplateRequestAsync(NewTemplatedSignatureRequest request,
        //    CancellationToken cancellationToken = default)
        //{
        //    if (request == null) { throw new ArgumentNullException(nameof(request)); }

        //    return PostAsync<SignatureRequestResponseWrap>($"{SignatureUrl}/create_embedded_with_template", new ApiMultipartContent(request, _log), cancellationToken);
        //}
    }
}
