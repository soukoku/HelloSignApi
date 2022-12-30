namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the template list api call.
    /// </summary>
    public class TemplateListResponseWrap : ListApiResponse
    {
        /// <summary>
        /// List of templates that the API caller has access to.
        /// </summary>
        public TemplateResponse[] Templates { get; set; }
    }
}
