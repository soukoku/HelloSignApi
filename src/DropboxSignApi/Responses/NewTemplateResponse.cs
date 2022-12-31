namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for creating new template call.
    /// </summary>
    public class NewTemplateResponse : ApiResponse
    {
        /// <summary>
        /// The embedded edit object for the new template.
        /// </summary>
        public EmbeddedTemplateUrl Template { get; set; }
    }
}
