namespace Soukoku.DropboxSignApi.Requests
{
    /// <summary>
    /// Custom field for <see cref="SubBulkSigner"/>.
    /// </summary>
    public class SubBulkSignerListCustomField
    {
        /// <summary>
        /// The name of a custom field. When working with pre-filled data, 
        /// the custom field's name must have a matching merge field name or 
        /// the field will remain empty on the document during signing.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The string that resolves (aka "pre-fills") to the merge field on the final document(s) used for signing.
        /// </summary>
        public string Value { get; set; }
    }
}