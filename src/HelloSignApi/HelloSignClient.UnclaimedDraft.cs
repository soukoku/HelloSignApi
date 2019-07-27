using HelloSignApi.Requests;
using HelloSignApi.Responses;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HelloSignApi
{
    // this contains unclaimed draft api methods

    partial class HelloSignClient
    {
        const string DraftUrl = "https://api.hellosign.com/v3/unclaimed_draft";

        /// <summary>
        /// Creates a new Draft that can be claimed using the claim URL.
        /// The first authenticated user to access the URL will claim the Draft and will be shown either
        /// the "Sign and send" or the "Request signature" page with the Draft loaded.
        /// Subsequent access to the claim URL will result in a 404.
        /// </summary>
        /// <param name="draft">The draft.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">draft</exception>
        public Task<UnclaimedDraftResponse> CreateUnclaimedDraftAsync(NewUnclaimedDraft draft)
        {
            return CreateUnclaimedDraftAsync(draft, CancellationToken.None);
        }

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
        public Task<UnclaimedDraftResponse> CreateUnclaimedDraftAsync(NewUnclaimedDraft draft, CancellationToken cancellationToken)
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
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">draft</exception>
        public Task<UnclaimedDraftResponse> CreateEmbeddedUnclaimedDraftAsync(NewEmbeddedUnclaimedDraft draft)
        {
            return CreateEmbeddedUnclaimedDraftAsync(draft, CancellationToken.None);
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
        public Task<UnclaimedDraftResponse> CreateEmbeddedUnclaimedDraftAsync(NewEmbeddedUnclaimedDraft draft, CancellationToken cancellationToken)
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
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">draft</exception>
        public Task<UnclaimedDraftResponse> CreateEmbeddedUnclaimedDraftWithTemplateAsync(NewTemplatedEmbeddedUnclaimedDraft draft)
        {
            return CreateEmbeddedUnclaimedDraftWithTemplateAsync(draft, CancellationToken.None);
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
        public Task<UnclaimedDraftResponse> CreateEmbeddedUnclaimedDraftWithTemplateAsync(NewTemplatedEmbeddedUnclaimedDraft draft, CancellationToken cancellationToken)
        {
            if (draft == null) { throw new ArgumentNullException(nameof(draft)); }

            var content = new MultipartFormDataContent();
            content.AddTemplatedEmbeddedUnclaimedDraft(_log, draft);

            return PostAsync<UnclaimedDraftResponse>($"{DraftUrl}/create_embedded_with_template", content, cancellationToken);
        }
    }
}
