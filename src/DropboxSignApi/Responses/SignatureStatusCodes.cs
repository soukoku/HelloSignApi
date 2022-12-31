namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Contains possible values for <see cref="SignatureRequestResponseSignature.StatusCode" />.
    /// </summary>
    public static class SignatureStatusCodes
    {
        /// <summary>
        /// Success
        /// </summary>
        public const string Success = "success";
        /// <summary>
        /// On hold. This could be because the sending account needs to confirm its email address, or because of insufficient funds.
        /// </summary>
        public const string OnHold = "on_hold";
        /// <summary>
        /// Signed
        /// </summary>
        public const string Signed = "signed";
        /// <summary>
        /// Awaiting signature
        /// </summary>
        public const string AwaitingSignature = "awaiting_signature";
        /// <summary>
        /// Declined
        /// </summary>
        public const string Declined = "declined";
        /// <summary>
        /// Unknown error
        /// </summary>
        public const string ErrorUnknown = "error_unknown";
        /// <summary>
        /// File could not be converted
        /// </summary>
        public const string ErrorFile = "error_file";
        /// <summary>
        /// Invalid form fields placement
        /// </summary>
        public const string ErrorComponentPosition = "error_component_position";
        /// <summary>
        /// File contained invalid text tags
        /// </summary>
        public const string ErrorTextTag = "error_text_tag";
        /// <summary>
        /// Request was prepared for signature but has not been sent to signers. Requester must release the request from hold when ready to send.
        /// </summary>
        public const string OnHoldByRequester = "on_hold_by_requester";
    }
}
