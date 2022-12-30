namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Custom field in a <see cref="TemplateResponseDocument"/>.
    /// </summary>
    public class TemplateResponseDocumentCustomField : TemplateResponseCustomField
    {
        /// <summary>
        /// The signer of the Form Field.
        /// </summary>
        public string Signer { get; set; }
    }
}