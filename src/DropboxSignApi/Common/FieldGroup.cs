// this file contains reponse data models.

namespace DropboxSignApi.Common
{
    /// <summary>
    /// FieldGroup object for a template <see cref="Document"/>.
    /// </summary>
    public class FieldGroup
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
