namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the signature request api calls.
    /// </summary>
    public class SignatureRequestResponseWrap : ResponseWrap
    {
        /// <summary>
        /// Contains information about a signature request.
        /// </summary>
        public SignatureRequestResponse SignatureRequest { get; set; }
    }
}
