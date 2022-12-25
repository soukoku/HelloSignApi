namespace DropboxSignApi.Common
{
    /// <summary>
    /// Quotas for an <see cref="Account"/>.
    /// </summary>
    public class AccountQuotas
    {
        /// <summary>
        /// API templates remaining.
        /// </summary>
        public int TemplatesLeft { get; set; }
        /// <summary>
        /// API signature requests remaining.
        /// </summary>
        public int ApiSignatureRequestsLeft { get; set; }
        /// <summary>
        /// Signature requests remaining.
        /// </summary>
        public int DocumentsLeft { get; set; }
    }
}
