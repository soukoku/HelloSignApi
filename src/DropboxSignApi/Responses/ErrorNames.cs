namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Contains possible values for <see cref="Error.Name" />.
    /// </summary>
    public static class ErrorNames
    {
        /// <summary>
        /// The request could not be understood by the server due to malformed syntax. The client should not repeat the request without modifications.
        /// </summary>
        public const string BadRequest = "bad_request";
        /// <summary>
        /// The credentials you have supplied are invalid.
        /// </summary>
        public const string Unauthorized = "unauthorized";
        /// <summary>
        /// Your account must be credited before the requested action is possible.
        /// </summary>
        public const string PaymentRequired = "payment_required";
        /// <summary>
        /// The requested action cannot be performed in the current context. Most of the time this happens when trying to access resources you don't have access to.
        /// </summary>
        public const string Forbidden = "forbidden";
        /// <summary>
        /// The server has not found anything matching the Request-URI.
        /// </summary>
        public const string NotFound = "not_found";
        /// <summary>
        /// Your request was well-formed but it cannot be completed to a conflict of some kind.
        /// </summary>
        public const string Conflict = "conflict";
        /// <summary>
        /// The team invite request has failed. Most of the time this means the person you've invited already belongs to a team.
        /// </summary>
        public const string TeamInviteFailed = "team_invite_failed";
        /// <summary>
        /// The email address you provided for the recipient is not valid.
        /// </summary>
        public const string InvalidRecipient = "invalid_recipient";
        /// <summary>
        /// Could not cancel the Signature Request. Either you are not the requester or the Signature Request can no longer be cancelled.
        /// </summary>
        public const string SignatureRequestCancelFailed = "signature_request_cancel_failed";
        /// <summary>
        /// Could not remove your access to the Signature Request. Either you are not a party to the request, or it is not yet fully executed.
        /// </summary>
        public const string SignatureRequestRemoveFailed = "signature_request_remove_failed";
        /// <summary>
        /// The request could not be completed because we are currently performing site maintenance.
        /// </summary>
        public const string Maintenance = "maintenance";
        /// <summary>
        /// The request was cancelled or deleted.
        /// </summary>
        public const string Deleted = "deleted";
        /// <summary>
        /// An unknown error has occurred, please try again.
        /// </summary>
        public const string Unknown = "unknown";
        /// <summary>
        /// The HTTP method used is not supported for the API endpoint being called.
        /// </summary>
        public const string MethodNotSupported = "method_not_supported";
        /// <summary>
        /// An error was detected with the signature request parameters during processing.
        /// </summary>
        public const string SignatureRequestInvalid = "signature_request_invalid";
        /// <summary>
        /// An error occurred while creating your template.
        /// </summary>
        public const string TemplateError = "template_error";
        /// <summary>
        /// A signature request reminder attempt was invalid. This is usually due to the reminder being made against an embedded request
        /// </summary>
        public const string InvalidReminder = "invalid_reminder";
        /// <summary>
        /// Your account's API request rate limit has been exceeded.
        /// </summary>
        public const string ExceededRate = "exceeded_rate";
        /// <summary>
        /// A file was invalid. This is usually due to an unsupported file format or a file that exceeds maximum file sizes.
        /// </summary>
        public const string InvalidFile = "invalid_file";
        /// <summary>
        /// An entity is invalid and the request can not be properly processed.
        /// </summary>
        public const string UnprocessableEntity = "unprocessable_entity";
        /// <summary>
        /// The signature request is expired and therefore can no longer have the action performed on it.
        /// </summary>
        public const string SignatureRequestExpired = "signature_request_expired";



        /// <summary>
        /// [White labeling] Invalid element name.
        /// </summary>
        public const string InvalidElementName = "invalid_element_name";
        /// <summary>
        /// [White labeling] Invalid value passed for legal_version.
        /// </summary>
        public const string InvalidLegalVersion = "invalid_legal_version";
        /// <summary>
        /// [White labeling] Invalid hex code.
        /// </summary>
        public const string InvalidHexCode = "invalid_hex_code";
        /// <summary>
        /// [White labeling] Contrast ratio is less than minimum 2.1.
        /// </summary>
        public const string InvalidContrastRatio = "invalid_contrast_ratio";
    }
}
