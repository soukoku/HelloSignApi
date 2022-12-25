namespace DropboxSignApi.Common
{
    /// <summary>
    /// Represents a signer role in a template.
    /// </summary>
    public class SignerRole
    {
        /// <summary>
        /// The name of the role.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// If signer order is assigned this is the 0-based index for this role.
        /// </summary>
        public int? Order { get; set; }
    }
}
