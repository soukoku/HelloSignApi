using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloSignApi.Responses
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

    /// <summary>
    /// Contains possible values for <see cref="Warning.Name" />.
    /// </summary>
    public static class WarningNames
    {
        /// <summary>
        /// The email address of the account making the Signature Request has not been confirmed. The Signature Request will be placed on hold until it is confirmed.
        /// </summary>
        public const string Unconfirmed = "unconfirmed";
        /// <summary>
        /// The value provided for a custom field is too long. The custom field will extend beyond the limits of its container and may not display the way you intended.
        /// </summary>
        public const string CustomFieldValueTooLong = "custom_field_value_too_long";
        /// <summary>
        /// A summary of all values for custom fields that are too long
        /// </summary>
        public const string CustomFieldValuesTooLong = "custom_field_values_too_long";
        /// <summary>
        /// One of the request parameters was ignored because it wasn't being used correctly
        /// </summary>
        public const string ParameterIgnored = "parameter_ignored";
        /// <summary>
        /// Text Tags were enabled for a file that is not a PDF, which may result in imprecise positioning.
        /// </summary>
        public const string NonPdfTextTags = "non_pdf_text_tags";
        /// <summary>
        /// Two or more of the form fields specified are overlapping, which may prevent signers from completing the document.
        /// </summary>
        public const string FormFieldsOverlap = "form_fields_overlap";
        /// <summary>
        /// Form fields must be placed within the document.
        /// </summary>
        public const string FormFieldsPlacement = "form_fields_placement";
        /// <summary>
        /// A parameter was provided which we no longer support. The value will be ignored.
        /// </summary>
        public const string DeprecatedParameter = "deprecated_parameter";
        /// <summary>
        /// Two parameters have been provided which are in conflict. One parameter will be ignored.
        /// </summary>
        public const string ParameterConflict = "parameter_conflict";
        /// <summary>
        /// An essential parameter was missing from the request and has been set to a default value.
        /// </summary>
        public const string ParameterMissing = "parameter_missing";
        /// <summary>
        /// The operation succeeded, but at least one non-essential part of the request failed.
        /// </summary>
        public const string PartialSuccess = "partial_success";
        /// <summary>
        /// A parameter was provided which will affect your app in test mode but will not affect it in production. 
        /// Upgrade your account to use in production.
        /// </summary>
        public const string TestModeOnly = "test_mode_only";
        /// <summary>
        /// A non-essential parameter was provided but it does not have a value. The parameter will be ignored.
        /// </summary>
        public const string EmptyValue = "empty_value";
        /// <summary>
        /// A warning was generated while attempting to add a user to your team.
        /// </summary>
        public const string AddMember = "add_member";
        /// <summary>
        /// A parameter was provided with an invalid value. The parameter will be modified or ignored.
        /// </summary>
        public const string ParameterInvalid = "parameter_invalid";
        /// <summary>
        /// OAuth user access grants have been revoked from this app due to a scope change.
        /// </summary>
        public const string OauthGrantsRevoked = "oauth_grants_revoked";
        /// <summary>
        /// The option to email a copy to the other signers and anyone CC'd is disabled for given account.
        /// </summary>
        public const string CcDisabled = "cc_disabled";
        /// <summary>
        /// A template with signer reassignment was used on an endpoint that does not support it (e.g. bulk send with template). The template will still be used, but without signer reassignment enabled.
        /// </summary>
        public const string ReassignUnsupported = "reassign_unsupported";
    }
}
