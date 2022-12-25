using DropboxSignApi.Common;

// this file contains reponse wrapper models.

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the signature request api calls.
    /// </summary>
    public class ApiAppResponse : ApiResponse
    {
        /// <summary>
        /// The api app object.
        /// </summary>
        public ApiApp ApiApp { get; set; }
    }
}
