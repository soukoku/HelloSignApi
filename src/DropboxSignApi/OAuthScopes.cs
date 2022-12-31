namespace Soukoku.DropboxSignApi
{
    /// <summary>
    /// Known OAuth scope values.
    /// </summary>
    public static class OAuthScopes
    {
        /// <summary>
        /// Access basic account information, such as email address and name.
        /// </summary>
        public const string BasicAccountInfo = "basic_account_info";
        /// <summary>
        /// Access basic account information, such as email address and name.
        /// </summary>
        public const string SendSignatureRequests = "request_signature";

        /// <summary>
        /// Access to basic account information, such as email address and name.
        /// </summary>
        public const string AccountAccess = "account_access";
        /// <summary>
        /// Access to send, view, and update signature requests and to download document files. 
        /// Signature requests must be made with oAuth token in order to access.
        /// </summary>
        public const string SignatureRequestAccess = "signature_request_access";
        /// <summary>
        /// Access to view, create, and modify templates.
        /// </summary>
        public const string TemplateAccess = "template_access";
        /// <summary>
        /// Access to view and modify team settings and team members.
        /// </summary>
        public const string TeamAccess = "team_access";
        /// <summary>
        /// Access to view, create, and modify embedded API apps.
        /// </summary>
        public const string ApiAppAccess = "api_app_access";
    }

}
