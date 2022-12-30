using DropboxSignApi.Common;
using System.Collections.Generic;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Document object in a template.
    /// </summary>
    public class TemplateResponseDocument
    {
        /// <summary>
        /// Name of the associated file
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Document ordering, the lowest index is diplayed first and the highest last (0-based indexing).
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// An array of Form Field Group objects.
        /// </summary>
        public IList<DocumentFieldGroup> FieldGroups { get; set; }

        /// <summary>
        /// An array of Form Field objects containing the name and type of each named textbox and checkmark field.
        /// </summary>
        public IList<DocumentFormField> FormFields { get; set; }

        /// <summary>
        /// An array of Custom Field objects containing the name and type of each custom field.
        /// </summary>
        public IList<TemplateResponseDocumentCustomField> CustomFields { get; set; }

        /// <summary>
        /// An array describing static overlay fields. Note only available for certain subscriptions.
        /// </summary>
        public IList<TemplateResponseDocumentStaticField> StaticFields { get; set; }
    }
}
