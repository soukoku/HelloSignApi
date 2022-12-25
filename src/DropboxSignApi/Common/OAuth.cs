// this file contains reponse data models.

namespace DropboxSignApi.Common
{
    /// <summary>
    /// Contains OAuth info.
    /// </summary>
    public class OAuth
    {
        /// <summary>
        /// The app's OAuth callback URL.
        /// </summary>
        public string CallbackUrl { get; set; }
        /// <summary>
        /// The app's OAuth secret.
        /// </summary>
        public string Secret { get; set; }
        /// <summary>
        /// Array of OAuth scopes used by the app.
        /// </summary>
        public string[] Scopes { get; set; }
        /// <summary>
        /// Boolean indicating whether the app owner or the account granting permission is billed for OAuth requests.
        /// </summary>
        public bool ChargesUsers { get; set; }
    }
}
