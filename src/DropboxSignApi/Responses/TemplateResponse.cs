using DropboxSignApi.Common;

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
