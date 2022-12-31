namespace Soukoku.DropboxSignApi.Requests
{
    /// <summary>
    /// Custom field for requests.
    /// </summary>
    public class SubCustomField
    {
        /// <summary>
        /// The name of a custom field. When working with pre-filled data, 
        /// the custom field's name must have a matching merge field name or 
        /// the field will remain empty on the document during signing.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Used to create editable merge fields. When the value matches a role passed in with signers, 
        /// that role can edit the data that was pre-filled to that field. This field is optional, 
        /// but required when this custom field object is set to required = true.
        /// </summary>
        public string Editor { get; set; }

        /// <summary>
        /// Used to set an editable merge field when working with pre-filled data. 
        /// When true, the custom field must specify a signer role in editor.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// The string that resolves (aka "pre-fills") to the merge field on the final document(s) used for signing.
        /// </summary>
        public string Value { get; set; }
    }
}
