namespace DropboxSignApi.Common
{
    /// <summary>
    /// An object that contains necessary information to set up embedded signing.
    /// </summary>
    public class EmbeddedSign : ExpiringObject
    {
        /// <summary>
        /// A signature url that can be opened in an iFrame.
        /// </summary>
        public string SignUrl { get; set; }
    }
}
