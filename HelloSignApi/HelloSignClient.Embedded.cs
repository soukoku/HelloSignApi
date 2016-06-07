using HelloSignApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloSignApi
{
    // this contains account api methods

    partial class HelloSignClient
    {
        const string EmbeddedUrl = "https://api.hellosign.com/v3/embedded";

        /// <summary>
        /// Retrieves an embedded object containing a signature url that can be opened in an iFrame.
        /// </summary>
        /// <param name="signatureId">The id of the signature to get a signature url for.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Signature id is required.</exception>
        public Task<EmbeddedSignResponse> GetEmbeddedSignUrlAsync(string signatureId)
        {
            if (string.IsNullOrEmpty(signatureId)) { throw new ArgumentException("Signature id is required."); }

            var resp = _client.GetAsync($"{EmbeddedUrl}/sign_url/{signatureId}")
                .ContinueWith(t => t.Result.ParseApiResponseAsync<EmbeddedSignResponse>(_log));
            return resp.Unwrap();
        }

        /// <summary>
        /// Retrieves an embedded object containing a template url that can be opened in an iFrame. Note that only templates created via the embedded template process are available to be edited with this endpoint.
        /// </summary>
        /// <param name="templateId">The id of the template to edit.</param>
        /// <param name="testMode">Whether this is a test, locked templates will only be available for editing if this is set.</param>
        /// <param name="skipSignerRoles">If signer roles are already provided, the user will not be prompted to edit them.</param>
        /// <param name="skipSubjectMessage">If the subject and message has already been provided, the user will not be prompted to edit them.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<EmbeddedTemplateResponse> GetEmbeddedTemplateEditUrlAsync(string templateId,
            bool testMode = false, bool skipSignerRoles = false, bool skipSubjectMessage = false)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var test = testMode ? 1 : 0;
            var signer = skipSignerRoles ? 1 : 0;
            var sm = skipSubjectMessage ? 1 : 0;

            var resp = _client.GetAsync($"{EmbeddedUrl}/edit_url/{templateId}?test_mode={test}&skip_signer_roles={signer}&skip_subject_message={sm}")
                .ContinueWith(t => t.Result.ParseApiResponseAsync<EmbeddedTemplateResponse>(_log));
            return resp.Unwrap();
        }

    }
}
