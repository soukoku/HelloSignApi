namespace Soukoku.DropboxSignApi.Requests
{
    public class SubUnclaimedDraftTemplateSigner : IRoleIndexedSigner
    {
        /// <summary>
        /// Must match an existing role in chosen Template(s).
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// The name of the signer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email address of the signer. This is required.
        /// </summary>
        public string EmailAddress { get; set; }
    }
}