namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the signature request api calls.
    /// </summary>
    public class ApiAppResponseWrap : ResponseWrap
    {
        /// <summary>
        /// The api app object.
        /// </summary>
        public ApiAppResponse ApiApp { get; set; }
    }
}
