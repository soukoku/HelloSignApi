namespace DropboxSignApi.Requests
{

    /// <summary>
    /// Data for creating or modifying a new api app.
    /// </summary>
    public class NewApiApp
    {
        /// <summary>
        /// The name you want to assign to the ApiApp.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The domain name the ApiApp will be associated with.
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// The URL at which the ApiApp should receive event callbacks.
        /// </summary>
        public string CallbackUrl { get; set; }
        /// <summary>
        /// An image file to use as a custom logo in embedded contexts. (Only applies to some API plans)
        /// </summary>
        public string CustomLogoFile { get; set; }

        /// <summary>
        /// The callback URL to be used for OAuth flows. (Required if <see cref="OAuthScopes"/> is provided)
        /// </summary>
        public string OAuthCallbackUrl { get; set; }
        /// <summary>
        /// A comma-separated list of OAuth scopes to be granted to the app. (Required if <see cref="OAuthCallbackUrl"/> is provided)
        /// </summary>
        public string OAuthScopes { get; set; }

        /// <summary>
        /// Serialized <see cref="WhiteLabelingOptions"/>, to be used to customize the app's signer page. (Only applies to some API plans)
        /// </summary>
        public string WhiteLabelingOptions { get; set; }
    }
}
