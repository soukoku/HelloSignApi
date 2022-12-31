namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the unclaimed draft api calls.
    /// </summary>
    public class UnclaimedDraftResponseWrap : ResponseWrap
    {
        /// <summary>
        /// A group of documents that a user can take ownership of via the claim URL.
        /// </summary>
        public UnclaimedDraftResponse UnclaimedDraft { get; set; }
    }
}
