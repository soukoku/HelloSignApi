namespace DropboxSignApi.Common
{
    /// <summary>
    /// Field object for a template <see cref="Document"/>.
    /// </summary>
    public class FormField
    {
        /// <summary>
        /// A unique id for the form field.
        /// </summary>
        public string ApiId { get; set; }
        /// <summary>
        /// The name of the form field.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The type of this form field. See <see cref="FieldTypes"/> values.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The horizontal offset in pixels for this form field.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// The vertical offset in pixels for this form field.
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// The width in pixels of this form field.
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// The height in pixels of this form field.
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Boolean showing whether or not this field is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// The name of the group this field is in. If this field is not a group, this defaults to null.
        /// </summary>
        public string Group { get; set; }
    }
}
