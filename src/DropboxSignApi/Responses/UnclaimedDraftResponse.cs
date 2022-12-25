using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the unclaimed draft api calls.
    /// </summary>
    public class UnclaimedDraftResponse : ApiResponse
    {
        /// <summary>
        /// A group of documents that a user can take ownership of via the claim URL.
        /// </summary>
        public UnclaimedDraft UnclaimedDraft { get; set; }
    }
}
