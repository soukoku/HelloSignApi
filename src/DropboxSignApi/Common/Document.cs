// this file contains reponse data models.

namespace DropboxSignApi.Common
{
    /// <summary>
    /// Document object in a template.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Name of the associated file
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Document ordering, the lowest index is diplayed first and the highest last.
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// An array of Form Field Group objects.
        /// </summary>
        public FieldGroup[] FieldGroups { get; set; }
        /// <summary>
        /// An array of Form Field objects containing the name and type of each named textbox and checkmark field.
        /// </summary>
        public FormField[] FormFields { get; set; }
        /// <summary>
        /// An array of Custom Field objects containing the name and type of each custom field.
        /// </summary>
        public CustomField[] CustomFields { get; set; }
    }
}
