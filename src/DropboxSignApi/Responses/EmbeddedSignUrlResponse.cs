using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the embedded sign api call.
    /// </summary>
    public class EmbeddedSignUrlResponse : ApiResponse
    {
        /// <summary>
        /// An object that contains necessary information to set up embedded signing.
        /// </summary>
        public EmbeddedSignUrl Embedded { get; set; }
    }
}
