using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the signature request api calls.
    /// </summary>
    public class SignatureRequestResponse : ApiResponse
    {
        /// <summary>
        /// The signature request object.
        /// </summary>
        public SignatureRequest SignatureRequest { get; set; }
    }
}
