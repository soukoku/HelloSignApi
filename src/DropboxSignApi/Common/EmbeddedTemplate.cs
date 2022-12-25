namespace DropboxSignApi.Common
{
    /// <summary>
    /// An object that contains necessary information to set up embedded template editing.
    /// </summary>
    public class EmbeddedTemplate : ExpiringObject
    {
        /// <summary>
        /// The template id if applicable.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// URL of the template page to display in the embedded iFrame.
        /// </summary>
        public string EditUrl { get; set; }
    }
}
