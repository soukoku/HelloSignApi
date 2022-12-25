namespace DropboxSignApi.Common
{
    /// <summary>
    /// Contains API app options.
    /// </summary>
    public class ApiAppOptions
    {
        /// <summary>
        /// Boolean denoting if signers can "Insert Everywhere" in one click while signing a document
        /// </summary>
        public bool CanInsertEverywhere { get; set; }
    }
}
