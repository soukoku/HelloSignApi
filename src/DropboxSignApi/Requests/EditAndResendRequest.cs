namespace DropboxSignApi.Requests
{
    public class EditAndResendRequest
    {
        /// <summary>
        /// Client id of the app used to create the draft. 
        /// Used to apply the branding and callback url defined for the app.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// This allows the requester to specify editor options when a preparing a document.
        /// </summary>
        public SubEditorOptions EditorOptions { get; set; }

        /// <summary>
        /// The request created from this draft will also be signable in embedded mode if set to <code>true</code>.
        /// </summary>
        public bool IsForEmbeddedSigning { get; set; }

        /// <summary>
        /// The email address of the user that should be designated as the requester of this draft. 
        /// If not set, original requester's email address will be used.
        /// </summary>
        public string RequesterEmailAddress { get; set; }

        /// <summary>
        /// The URL you want signers redirected to after they successfully request a signature.
        /// </summary>
        public string RequestingRedirectUrl { get; set; }

        /// <summary>
        /// When only one step remains in the signature request process and this parameter 
        /// is set to false then the progress stepper will be hidden.
        /// </summary>
        public bool ShowProgressStepper { get; set; } = true;

        /// <summary>
        /// The URL you want signers redirected to after they successfully sign.
        /// </summary>
        public string SigningRedirectUrl { get; set; }

        /// <summary>
        /// Whether this is a test, the signature request created from this draft 
        /// will not be legally binding if set to true. Defaults to false.
        /// </summary>
        public bool TestMode { get; set; }
    }
}