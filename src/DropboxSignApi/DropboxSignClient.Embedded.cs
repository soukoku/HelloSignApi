using DropboxSignApi.Internal;
using DropboxSignApi.Requests;
using DropboxSignApi.Responses;
using DropboxSignApi.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DropboxSignApi
{
    // this contains embedded url api methods

    partial class DropboxSignClient
    {
        const string EmbeddedUrl = "https://api.hellosign.com/v3/embedded";

        /// <summary>
        /// Retrieves an embedded object containing a signature url that can be opened in an iFrame.
        /// Note that templates created via the embedded template process will only be accessible through the API.
        /// </summary>
        /// <param name="signatureId">The id of the signature to get a signature url for.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Signature id is required.</exception>
        public Task<EmbeddedSignUrlResponseWrap> GetEmbeddedSignUrlAsync(string signatureId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(signatureId)) { throw new ArgumentException("Signature id is required."); }

            return GetAsync<EmbeddedSignUrlResponseWrap>($"{EmbeddedUrl}/sign_url/{Uri.EscapeDataString(signatureId)}", cancellationToken);
        }

        /// <summary>
        /// Retrieves an embedded object containing a template url that can be opened in an iFrame. 
        /// Note that only templates created via the embedded template process are available to be edited with this endpoint.
        /// </summary>
        /// <param name="templateId">The id of the template to edit.</param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<EmbeddedTemplateEditUrlResponseWrap> GetEmbeddedTemplateEditUrlAsync(string templateId,
            EmbeddedTemplateEditUrlRequest request,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            return PostAsync<EmbeddedTemplateEditUrlResponseWrap>($"{EmbeddedUrl}/edit_url/{Uri.EscapeDataString(templateId)}", 
                request.ToJsonContent(_log), cancellationToken);
        }

    }
}
