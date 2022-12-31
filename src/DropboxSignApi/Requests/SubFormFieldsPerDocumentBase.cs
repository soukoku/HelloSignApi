using DropboxSignApi.Internal;
using Newtonsoft.Json;

namespace DropboxSignApi.Requests
{
    [JsonConverter(typeof(SubFormFieldConverter))]
    public abstract class SubFormFieldsPerDocumentBase
    {
        /// <summary>
        /// Represents the integer index of the file the field should be attached to.
        /// </summary>
        public int DocumentIndex { get; set; }

        /// <summary>
        /// An identifier for the field that is unique across all documents in the request.
        /// </summary>
        public string ApiId { get; set; }

        /// <summary>
        /// The type of this form field. See <see cref="DropboxSignApi.FieldTypes"/> values.
        /// </summary>
        public virtual string Type { get => FieldTypes.Text; }

        /// <summary>
        /// Whether this field is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// <para>Signer index identified by the offset in the signers parameter 
        /// (0-based indexing), indicating which signer should fill out the field.
        /// </para>
        /// <para>If type is text-merge or checkbox-merge, 
        /// you must set this to sender in order to use pre-filled data.</para>
        /// </summary>
        public string Signer { get; set; }

        /// <summary>
        /// Size of the field in pixels.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Size of the field in pixels.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Location coordinates of the field in pixels.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Location coordinates of the field in pixels.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Display name for the field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Page in the document where the field 
        /// should be placed (requires documents be PDF files).
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Each text field may contain a validation_type parameter. 
        /// Check out the list of validation types to learn more about the possible values.
        /// </summary>
        public string ValidationType { get; set; }

        public string ValidationCustomRegex { get; set; }

        public string ValidationCustomRegexFormatLabel { get; set; }
    }
}