namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Represents a signature request recipient.
    /// </summary>
    public class SubSignatureRequestSigner
    {
        /// <summary>
        /// The name of the signer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email address of the signer. This is required.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The order the signer is required to sign.
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        /// The 4- to 12-character access code that will secure this signer's signature page.
        /// </summary>
        public string Pin { get; set; }

        /// <summary>
        /// An E.164 formatted phone number.
        /// </summary>
        public string SmsPhoneNumber { get; set; }

        /// <summary>
        /// Specifies the feature used with the sms_phone_number. Default authentication.
        /// If authentication, signer is sent a verification code via SMS that is required to access the document.
        /// If delivery, a link to complete the signature request is delivered via SMS (and email).
        /// </summary>
        public string SmsPhoneNumberType { get; set; }

        ///// <summary>
        ///// The role name of the signer for template purposes.
        ///// </summary>
        //public string Role { get; set; }
    }
}
