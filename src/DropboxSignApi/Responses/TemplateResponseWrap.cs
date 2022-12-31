namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the template api calls.
    /// </summary>
    public class TemplateResponseWrap : ResponseWrap
    {
        /// <summary>
        /// Contains information about the templates you and your team have created.
        /// </summary>
        public TemplateResponse Template { get; set; }
    }
}
