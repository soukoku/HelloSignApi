namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Response of <see cref="DropboxSignClient.UpdateTemplateFilesAsync(string, Requests.UpdateTemplateFileRequest, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class TemplateUpdateFilesResponseWrap : ResponseWrap
    {
        /// <summary>
        /// Contains template id.
        /// </summary>
        public TemplateUpdateFilesResponse Template { get; set; }
    }
}