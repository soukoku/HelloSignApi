namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Represents a field data.
    /// </summary>
    public class SignatureRequestResponseData
    {
        /// <summary>
        /// The unique ID for this field.
        /// </summary>
        public string ApiId { get; set; }

        /// <summary>
        /// The ID of the signature to which this response is linked.
        /// </summary>
        public string SignatureId { get; set; }
        
        /// <summary>
        /// The name of the form field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A boolean value denoting if this field is required.
        /// </summary>
        public bool Required { get; set; }
        
        /// <summary>
        /// The type of this form field. See <see cref="FieldTypes"/> values.
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// The value of the form field.
        /// </summary>
        public string Value { get; set; }
    }
}
