namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Quotas for a <see cref="TemplateResponseAccount"/>.
    /// </summary>
    public class TemplateResponseAccountQuota : AccountResponseQuotas
    {
        /// <summary>
        /// SMS verifications remaining.
        /// </summary>
        public int SmsVerificationsLeft { get; set; }
    }
}
