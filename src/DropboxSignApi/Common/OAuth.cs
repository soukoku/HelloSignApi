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
        /// The app's OAuth secret, or null if the app does not belong to user.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Array of OAuth scopes used by the app.
        /// See <see cref="OAuthScopes"/>.
        /// </summary>
        public string[] Scopes { get; set; }

        /// <summary>
        /// Boolean indicating whether the app owner or the account granting permission is billed for OAuth requests.
        /// </summary>
        public bool ChargesUsers { get; set; }
    }

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
        public string[] Scopes { get; set; }
    }

}
