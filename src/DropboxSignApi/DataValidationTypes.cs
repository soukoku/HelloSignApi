namespace DropboxSignApi
{
    /// <summary>
    /// Contains possible values for text fields accept validation type, which must be met before the user can submit the signed document. 
    /// This value can be specified in form fields, text tags, or on the web. These are the options you can specify for validation type.
    /// </summary>
    public static class DataValidationTypes
    {
        /// <summary>
        /// Numbers only (negative and decimal values included)
        /// </summary>
        public const string NumbersOnly = "numbers_only";
        /// <summary>
        /// Letters only (non-English letters included)
        /// </summary>
        public const string LettersOnly = "letters_only";
        /// <summary>
        /// 10- or 11-digit number
        /// </summary>
        public const string PhoneNumber = "phone_number";
        /// <summary>
        /// 9-digit number
        /// </summary>
        public const string BankRoutingNumber = "bank_routing_number";
        /// <summary>
        /// Minimum 6-digit number
        /// </summary>
        public const string BankAccountNumber = "bank_account_number";
        /// <summary>
        /// Email address
        /// </summary>
        public const string EmailAddress = "email_address";
        /// <summary>
        /// 5- or 9-digit number
        /// </summary>
        public const string ZipCode = "zip_code";
        /// <summary>
        /// 9-digit number
        /// </summary>
        public const string SocialSecurityNumber = "social_security_number";
        /// <summary>
        /// 9-digit number
        /// </summary>
        public const string EmployerIdentificationNumber = "employer_identification_number";
        /// <summary>
        /// Custom regular expression.
        /// </summary>
        public const string CustomRegex = "custom_regex";
    }
}
