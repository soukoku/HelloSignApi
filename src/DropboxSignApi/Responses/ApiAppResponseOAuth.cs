using System.Collections.Generic;
using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Contains OAuth info.
    /// </summary>
    public class ApiAppResponseOAuth
    {
        /// <summary>
        /// The app's OAuth callback URL.
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// The app's OAuth secret, or null if the app does not belong to user.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Array of OAuth scopes used by the app.
        /// See <see cref="OAuthScopes"/>.
        /// </summary>
        public IList<string> Scopes { get; set; }

        /// <summary>
        /// Boolean indicating whether the app owner or the account granting permission is billed for OAuth requests.
        /// </summary>
        public bool ChargesUsers { get; set; }
    }

}
