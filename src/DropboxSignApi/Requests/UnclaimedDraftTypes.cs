namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Contains options for <see cref="NewUnclaimedDraftRequest.Type"/>.
    /// </summary>
    public static class UnclaimedDraftTypes
    {
        /// <summary>
        /// Used to create a claimable file.
        /// </summary>
        public const string SendDocument = "send_document";

        /// <summary>
        /// Used to create a claimable signature request.
        /// </summary>
        public const string RequestSignature = "request_signature";

    }
}
