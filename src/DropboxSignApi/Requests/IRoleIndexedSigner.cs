namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Used to indicate the signer is indexed by role name instead of number.
    /// For multipart request use only.
    /// </summary>
    public interface IRoleIndexedSigner
    {
        /// <summary>
        /// The role name.
        /// </summary>
        string Role { get; set; }
    }
}