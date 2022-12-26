namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Contains API app options.
    /// </summary>
    public class ApiAppResponseOptions
    {
        /// <summary>
        /// Boolean denoting if signers can "Insert Everywhere" in one click while signing a document.
        /// </summary>
        public bool CanInsertEverywhere { get; set; }
    }
}
