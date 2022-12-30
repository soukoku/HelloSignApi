namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Custom field for a <see cref="SignatureRequestResponse"/>.
    /// </summary>
    public class SignatureRequestResponseCustomField
    {
        /// <summary>
        /// The name of the Custom Field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of this Custom Field. Only 'text' and 'checkbox' are currently supported.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A boolean value denoting if this field is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// The unique ID for this field.
        /// </summary>
        public string ApiId { get; set; }

        /// <summary>
        /// The name of the Role that is able to edit this field.
        /// </summary>
        public string Editor { get; set; }

        /// <summary>
        /// A text string for text fields 
        /// </summary>
        public string Value { get; set; }
    }
}