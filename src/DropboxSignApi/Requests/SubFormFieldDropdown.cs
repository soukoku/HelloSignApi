using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    public class SubFormFieldDropdown : SubFormFieldsPerDocumentBase
    {
        public override string Type => FieldTypes.Dropdown;

        /// <summary>
        /// Array of string values representing dropdown values.
        /// </summary>
        public IList<string> Options { get; set; } = new List<string>();

        /// <summary>
        /// Selected value in options array. Value must exist in array.
        /// </summary>
        public string Content { get; set; }
    }
}