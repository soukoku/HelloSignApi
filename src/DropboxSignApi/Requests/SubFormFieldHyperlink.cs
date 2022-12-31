namespace DropboxSignApi.Requests
{
    public class SubFormFieldHyperlink : SubFormFieldBase
    {
        public override string Type => FieldTypes.Hyperlink;

        /// <summary>
        /// Link text.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Link URL.
        /// </summary>
        public string ContentUrl { get; set; }
    }
}