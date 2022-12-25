using DropboxSignApi.Common;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new embedded unclaimed draft.
    /// </summary>
    public class NewEmbeddedUnclaimedDraft : NewUnclaimedDraft
    {
        /// <summary>
        /// Client id of the app you're using to create this draft. 
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The email address of the user that should be designated as the requester of this draft, 
        /// if the draft type is <see cref="UnclaimedDraftTypes.RequestSignature"/>.
        /// </summary>
        public string RequesterEmailAddress { get; set; }

        /// <summary>
        /// The request created from this draft will also be signable in embedded mode if set to <code>true</code>.
        /// </summary>
        public bool IsForEmbeddedSigning { get; set; }
    }
}
