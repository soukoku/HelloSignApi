namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Static field in a <see cref="TemplateResponseDocument"/>.
    /// </summary>
    public class TemplateResponseDocumentStaticField
    {
        /// <summary>
        /// The name of the static field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of this static Field.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The signer of the static Field.
        /// </summary>
        public string Signer { get; set; }

        /// <summary>
        /// The horizontal offset in pixels for this static field.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The vertical offset in pixels for this static field.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The width in pixels of this static field.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height in pixels of this static field.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Boolean showing whether or not this field is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// A unique id for the static field.
        /// </summary>
        public string ApiId { get; set; }

        /// <summary>
        /// The name of the group this field is in. If this field is not a group, this defaults to null.
        /// </summary>
        public string Group { get; set; }
    }
}