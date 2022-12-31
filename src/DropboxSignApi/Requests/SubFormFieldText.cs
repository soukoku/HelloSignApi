namespace DropboxSignApi.Requests
{
    public class SubFormFieldText : SubFormFieldsPerDocumentBase
    {
        /// <summary>
        /// Placeholder value for text field.
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// Auto fill type for populating fields automatically. 
        /// Check out the list of auto fill types to learn more about the possible values.
        /// </summary>
        public string AutoFillType { get; set; }

        /// <summary>
        /// Link two or more text fields. Enter data into one linked text field, 
        /// which automatically fill all other linked text fields.
        /// </summary>
        public string LinkId { get; set; }

        /// <summary>
        /// Masks entered data. For more information see Masking sensitive information. 
        /// true for masking the data in a text field, otherwise false.
        /// </summary>
        public bool Masked { get; set; }
    }
}