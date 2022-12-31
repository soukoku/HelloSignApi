namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Quotas for an <see cref="AccountResponse"/>.
    /// </summary>
    public class AccountResponseQuotas
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
