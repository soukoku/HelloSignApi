using DropboxSignApi.Common;

// this file contains reponse wrapper models.

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the embedded sign api call.
    /// </summary>
    public class EmbeddedSignResponse : ApiResponse
    {
        /// <summary>
        /// The <see cref="EmbeddedSign"/> object.
        /// </summary>
        public EmbeddedSign Embedded { get; set; }
    }
}
