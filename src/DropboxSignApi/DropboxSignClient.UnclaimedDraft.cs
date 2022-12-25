using DropboxSignApi.Internal;
﻿using DropboxSignApi.Requests;
using DropboxSignApi.Responses;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DropboxSignApi
{
    // this contains unclaimed draft api methods

    partial class DropboxSignClient
    {
        const string DraftUrl = "https://api.hellosign.com/v3/unclaimed_draft";

        /// <summary>
        /// Creates a new Draft that can be claimed using the claim URL.
        /// The first authenticated user to access the URL will claim the Draft and will be shown either
        /// the "Sign and send" or the "Request signature" page with the Draft loaded.
        /// Subsequent access to the claim URL will result in a 404.
        /// </summary>
        /// <param name="draft">The draft.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">draft</exception>
        public Task<UnclaimedDraftResponse> CreateUnclaimedDraftAsync(NewUnclaimedDraftRequest draft,
            CancellationToken cancellationToken = default)
        {
            if (draft == null) { throw new ArgumentNullException(nameof(draft)); }

            var content = new MultipartFormDataContent();
            content.AddUnclaimedDraft(_log, draft);

            return PostAsync<UnclaimedDraftResponse>($"{DraftUrl}/create", content, cancellationToken);
        }

        /// <summary>
        /// Creates a new Draft that can be claimed and used in an embedded iFrame.
        /// The first authenticated user to access the URL will claim the Draft and will be shown
        /// the "Request signature" page with the Draft loaded. Subsequent access to the claim URL will
        /// result in a 404. For this embedded endpoint the RequesterEmailAddress parameter is required.
        /// </summary>
        /// <param name="draft">The draft.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">draft</exception>
        public Task<UnclaimedDraftResponse> CreateUnclaimedDraftAsync(NewEmbeddedUnclaimedDraftRequest draft,
            CancellationToken cancellationToken = default)
        {
            if (draft == null) { throw new ArgumentNullException(nameof(draft)); }

            var content = new MultipartFormDataContent();
            content.AddEmbeddedUnclaimedDraft(_log, draft);

            return PostAsync<UnclaimedDraftResponse>($"{DraftUrl}/create_embedded", content, cancellationToken);
        }


        /// <summary>
        /// Creates a new Draft with a previously saved template that can be claimed and used in an embedded iFrame. 
        /// The first authenticated user to access the URL will claim the Draft and will be shown the "Request signature" page with the Draft loaded. 
        /// Subsequent access to the claim URL will result in a 404. For this embedded endpoint the RequesterEmailAddress parameter is required.
        /// </summary>
        /// <param name="draft">The draft.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">draft</exception>
        public Task<UnclaimedDraftResponse> CreateEmbeddedUnclaimedDraftWithTemplateAsync(NewTemplatedEmbeddedUnclaimedDraft draft, 
            CancellationToken cancellationToken = default)
        {
            if (draft == null) { throw new ArgumentNullException(nameof(draft)); }

            var content = new MultipartFormDataContent();
            content.AddTemplatedEmbeddedUnclaimedDraft(_log, draft);

            return PostAsync<UnclaimedDraftResponse>($"{DraftUrl}/create_embedded_with_template", content, cancellationToken);
        }

        /// <summary>
        /// Creates a new signature request from an embedded request that can be edited prior to being sent to the recipients. 
        /// Parameter test_mode can be edited prior to request. Signers can be edited in embedded editor. 
        /// Requester's email address will remain unchanged if requester_email_address parameter is not set.
        /// </summary>
        /// <param name="signatureRequestId">The ID of the signature request to edit and resend.</param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<UnclaimedDraftResponse> EditAndResendUnclaimedDraft(string signatureRequestId,
            EditAndResendRequest request,
            CancellationToken cancellationToken = default)
        {
            return PostAsync<UnclaimedDraftResponse>($"{DraftUrl}/edit_and_resend/{Uri.EscapeDataString(signatureRequestId)}", 
                request.ToJsonContent(), cancellationToken);
        }
    }
}
