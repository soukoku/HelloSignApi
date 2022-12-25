using DropboxSignApi.Common;

// this file contains reponse wrapper models.

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
