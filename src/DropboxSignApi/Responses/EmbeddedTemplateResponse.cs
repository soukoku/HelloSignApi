using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the embedded template edit api call.
    /// </summary>
    public class EmbeddedTemplateResponse : ApiResponse
    {
        /// <summary>
        /// The <see cref="EmbeddedTemplate"/> object.
        /// </summary>
        public EmbeddedTemplate Embedded { get; set; }
    }
}
