namespace Soukoku.DropboxSignApi.Requests
{
    /// <summary>
    /// Request object for <see cref="DropboxSignClient.UpdateTemplateFilesAsync(string, UpdateTemplateFileRequest, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class UpdateTemplateFileRequest : FileRequestBase
    {
        /// <summary>
        /// Client id of the app you're using to update this template.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The new default template email message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The new default template email subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Whether this is a test, the signature request created from this draft 
        /// will not be legally binding if <code>true</code>.
        /// </summary>
        public bool TestMode { get; set; }
    }
}