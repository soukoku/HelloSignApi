using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the embedded template edit api call.
    /// </summary>
    public class EmbeddedTemplateResponse : ApiResponse
    {
        /// <summary>
        /// An embedded template object.
        /// </summary>
        public EmbeddedTemplate Embedded { get; set; }
    }
}
