using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Limited oauth options for API app use.
    /// </summary>
    public class SubOAuth
    {
        /// <summary>
        /// The callback URL to be used for OAuth flows. (Required if <see cref="Scopes"/> is provided).
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// A list of OAuth scopes to be granted to the app. (Required if <see cref="CallbackUrl"/> is provided).
        /// See <see cref="OAuthScopes"/>.
        /// </summary>
        public IList<string> Scopes { get; set; }
    }

}
