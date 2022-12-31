using Newtonsoft.Json;
using System;

namespace Soukoku.DropboxSignApi.Requests
{
    /// <summary>
    /// Request object for <see cref="DropboxSignClient.UpdateSignatureRequestAsync(string, UpdateSignatureRequestRequest, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class UpdateSignatureRequestRequest
    {
        /// <summary>
        /// The signature ID for the recipient.
        /// </summary>
        public string SignatureId { get; set; }

        /// <summary>
        /// The signature ID for the recipient.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The new name for the recipient.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The new time when the signature request will expire. 
        /// Unsigned signatures will be moved to the expired status, and no longer signable.
        /// </summary>
        public DateTime? ExpiresAt { get; set; }
    }
}