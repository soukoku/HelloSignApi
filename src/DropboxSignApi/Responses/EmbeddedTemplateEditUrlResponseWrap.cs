namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the embedded template edit api call.
    /// </summary>
    public class EmbeddedTemplateEditUrlResponseWrap : ApiResponse
    {
        /// <summary>
        /// An embedded template object.
        /// </summary>
        public EmbeddedEditUrlResponse Embedded { get; set; }
    }
}
