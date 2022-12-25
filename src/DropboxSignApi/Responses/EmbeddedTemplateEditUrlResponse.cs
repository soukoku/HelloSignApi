using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the embedded template edit api call.
    /// </summary>
    public class EmbeddedTemplateEditUrlResponse : ApiResponse
    {
        /// <summary>
        /// An embedded template object.
        /// </summary>
        public EmbeddedEditUrl Embedded { get; set; }
    }
}
