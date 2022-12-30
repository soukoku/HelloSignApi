namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the template api calls.
    /// </summary>
    public class TemplateResponseWrap : ApiResponse
    {
        /// <summary>
        /// Contains information about the templates you and your team have created.
        /// </summary>
        public TemplateResponse Template { get; set; }
    }
}
