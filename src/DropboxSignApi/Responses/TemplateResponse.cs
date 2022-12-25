using DropboxSignApi.Common;

// this file contains reponse wrapper models.

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the template api calls.
    /// </summary>
    public class TemplateResponse : ApiResponse
    {
        /// <summary>
        /// The template object.
        /// </summary>
        public Template Template { get; set; }
    }
}
