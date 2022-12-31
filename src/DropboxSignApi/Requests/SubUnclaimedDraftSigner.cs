namespace Soukoku.DropboxSignApi.Requests
{
    public class SubUnclaimedDraftSigner
    {
        /// <summary>
        /// The name of the signer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email address of the signer. This is required.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The order the signer is required to sign.
        /// </summary>
        public int? Order { get; set; }
    }
}