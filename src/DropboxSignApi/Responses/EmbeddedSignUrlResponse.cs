namespace DropboxSignApi.Responses
{
    /// <summary>
    /// An object that contains necessary information to set up embedded signing.
    /// </summary>
    public class EmbeddedSignUrlResponse : ExpiringObject
    {
        /// <summary>
        /// A signature url that can be opened in an iFrame.
        /// </summary>
        public string SignUrl { get; set; }
    }
}
