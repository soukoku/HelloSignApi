namespace DropboxSignApi.Common
{
    /// <summary>
    /// Represents a group of documents that a user can take ownership of via the claim URL.
    /// </summary>
    public class UnclaimedDraft : ExpiringObject
    {
        /// <summary>
        /// The ID of the signature request that is represented by this UnclaimedDraft.
        /// </summary>
        public string SignatureRequestId { get; set; }
        /// <summary>
        /// The URL to be used to claim this UnclaimedDraft.
        /// </summary>
        public string ClaimUrl { get; set; }
        /// <summary>
        /// The URL you want signers redirected to after they successfully sign.
        /// </summary>
        public string SigningRedirectUrl { get; set; }
        /// <summary>
        /// The URL you want signers redirected to after they successfully request a signature.
        /// </summary>
        public string RequestingRedirectUrl { get; set; }

        /// <summary>
        /// Whether this is a test draft. Signature requests made from test drafts have no legal value.
        /// </summary>
        public bool TestMode { get; set; }
    }
}
