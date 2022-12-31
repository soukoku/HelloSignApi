namespace Soukoku.DropboxSignApi.Requests
{
    public class SubSigningOptions
    {
        /// <summary>
        /// The default type shown (limited to "draw" "phone" "type" "upload").
        /// </summary>
        public string DefaultType { get; set; }

        /// <summary>
        /// Allows drawing the signature.
        /// </summary>
        public bool Draw { get; set; }

        /// <summary>
        /// Allows using a smartphone to email the signature.
        /// </summary>
        public bool Phone { get; set; }

        /// <summary>
        /// Allows typing the signature.
        /// </summary>
        public bool Type { get; set; }

        /// <summary>
        /// Allows uploading the signature.
        /// </summary>
        public bool Upload { get; set; }
    }
}