namespace DropboxSignApi.Common
{
    /// <summary>
    /// An object that contains necessary information to set up embedded template editing.
    /// </summary>
    public class EmbeddedEditUrl : ExpiringObject
    {
        /// <summary>
        /// A template url that can be opened in an iFrame.
        /// </summary>
        public string EditUrl { get; set; }
    }
}
