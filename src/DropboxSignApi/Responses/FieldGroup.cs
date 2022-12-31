namespace DropboxSignApi.Responses
{
    /// <summary>
    /// FieldGroup object for a document.
    /// </summary>
    public class DocumentFieldGroup
    {
        /// <summary>
        /// The name of the form field group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The rule used to validate checkboxes in the form field group.
        /// </summary>
        public string Rule { get; set; }
    }
}
