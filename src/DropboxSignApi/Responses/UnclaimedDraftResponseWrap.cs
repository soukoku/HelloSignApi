namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the unclaimed draft api calls.
    /// </summary>
    public class UnclaimedDraftResponseWrap : ApiResponse
    {
        /// <summary>
        /// A group of documents that a user can take ownership of via the claim URL.
        /// </summary>
        public UnclaimedDraftResponse UnclaimedDraft { get; set; }
    }
}
