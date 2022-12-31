using System.Collections.Generic;

namespace Soukoku.DropboxSignApi.Requests
{
    /// <summary>
    /// Signer for <see cref="BulkSendWithTemplateRequest"/>.
    /// </summary>
    public class SubBulkSigner
    {
        /// <summary>
        /// An list of custom field values.
        /// </summary>
        public IList<SubBulkSignerListCustomField> CustomFields { get; } = new List<SubBulkSignerListCustomField>();

        /// <summary>
        /// The signers to request signatures.
        /// </summary>
        public IList<SubSignatureRequestTemplateSigner> Signers { get; } = new List<SubSignatureRequestTemplateSigner>();

    }
}