namespace DropboxSignApi
{
    /// <summary>
    /// Contains possible values for <see cref="Event.EventType" />.
    /// </summary>
    public static class EventTypes
    {
        /// <summary>
        /// The SignatureRequest has been viewed.
        /// </summary>
        public const string SignatureRequestViewed = "signature_request_viewed";
        /// <summary>
        /// A signer has completed all required fields on the SignatureRequest.
        /// </summary>
        public const string SignatureRequestSigned = "signature_request_signed";
        /// <summary>
        /// An updated version of the SignatureRequest PDF is available for download.
        /// </summary>
        public const string SignatureRequestDownloadable = "signature_request_downloadable";
        /// <summary>
        /// The SignatureRequest has been sent successfully.
        /// </summary>
        public const string SignatureRequestSent = "signature_request_sent";
        /// <summary>
        /// The SignatureRequest was declined by a signer.
        /// </summary>
        public const string SignatureRequestDeclined = "signature_request_declined";
        /// <summary>
        /// The signer has reassigned their signature to a different signer.
        /// </summary>
        public const string SignatureRequestReassigned = "signature_request_reassigned";
        /// <summary>
        /// All signers have been sent a reminder to complete the SignatureRequest.
        /// </summary>
        public const string SignatureRequestRemind = "signature_request_remind";
        /// <summary>
        /// All signers have completed all required fields for the SignatureRequest and the final PDF is ready to be downloaded.
        /// </summary>
        public const string SignatureRequestAllSigned = "signature_request_all_signed";
        /// <summary>
        /// An email address for one of the signers on your signature request has bounced. May be correctable by updating
        /// the request.
        /// </summary>
        public const string SignatureRequestEmailBounce = "signature_request_email_bounce";
        /// <summary>
        /// An error occurred while processing the signature request data on our back-end.
        /// For example: Invalid text tags
        /// </summary>
        public const string SignatureRequestInvalid = "signature_request_invalid";
        /// <summary>
        /// The SignatureRequest has been canceled.
        /// </summary>
        public const string SignatureRequestCanceled = "signature_request_canceled";
        /// <summary>
        /// The signature request has expired, signers who failed to sign will be marked expired.
        /// </summary>
        public const string SignatureRequestExpired = "signature_request_expired";
        /// <summary>
        /// The SignatureRequest has been prepared but not sent.
        /// </summary>
        public const string SignatureRequestPrepared = "signature_request_prepared";
        /// <summary>
        /// We're unable to convert the file you provided.
        /// </summary>
        public const string FileError = "file_error";
        /// <summary>
        /// An unknown error occurred during while processing a signature request.
        /// </summary>
        public const string UnknownError = "unknown_error";
        /// <summary>
        /// The embedded sign URL you provided is invalid or expired.
        /// </summary>
        public const string SignUrlInvalid = "sign_url_invalid";
        /// <summary>
        /// An account created via one of your apps has been confirmed.
        /// </summary>
        public const string AccountConfirmed = "account_confirmed";
        /// <summary>
        /// The Template has been created.
        /// </summary>
        public const string TemplateCreated = "template_created";
        /// <summary>
        /// There was an error while creating your template.
        /// </summary>
        public const string TemplateError = "template_error";
    }
}
