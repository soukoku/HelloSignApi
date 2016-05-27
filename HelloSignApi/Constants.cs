using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// this file contains constant values only

namespace HelloSignApi
{
    /// <summary>
    /// Contains possible values for <see cref="Field.Type"/>.
    /// </summary>
    public static class FieldTypes
    {
        /// <summary>
        /// A text input field
        /// </summary>
        public const string Text = "text";
        /// <summary>
        /// A yes/no checkbox
        /// </summary>
        public const string CheckBox = "checkbox";
        /// <summary>
        /// A date
        /// </summary>
        public const string DateSigned = "date_signed";
        /// <summary>
        /// An input field for initials
        /// </summary>
        public const string Initials = "initials";
        /// <summary>
        /// A signature input field
        /// </summary>
        public const string Signature = "signature";
    }

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
        /// The operation succeeded, but at least one non-essential part of the request failed.
        /// </summary>
        public const string PartialSuccess = "partial_success";
        /// <summary>
        /// A parameter was provided which will affect your app in test mode but will not affect it in production. Upgrade your account to use in production.
        /// </summary>
        public const string TestModeOnly = "test_mode_only";
    }

    /// <summary>
    /// Contains possible values for <see cref="Event.Name" />.
    /// </summary>
    public static class EventNames
    {
        /// <summary>
        /// The SignatureRequest has been viewed.
        /// </summary>
        public const string signature_request_viewed = "signature_request_viewed";
        /// <summary>
        /// A signer has completed all required fields on the SignatureRequest.
        /// </summary>
        public const string signature_request_signed = "signature_request_signed";
        /// <summary>
        /// The SignatureRequest has been sent successfully.
        /// </summary>
        public const string signature_request_sent = "signature_request_sent";
        /// <summary>
        /// All signers have been sent a reminder to complete the SignatureRequest.
        /// </summary>
        public const string signature_request_remind = "signature_request_remind";
        /// <summary>
        /// All signers have completed all required fields for the SignatureRequest and the final PDF is ready to be downloaded.
        /// </summary>
        public const string signature_request_all_signed = "signature_request_all_signed";
        /// <summary>
        /// We're unable to convert the file you provided.
        /// </summary>
        public const string file_error = "file_error";
        /// <summary>
        /// An unknown error occurred during while processing a signature request.
        /// </summary>
        public const string unknown_error = "unknown_error";
        /// <summary>
        /// An error occurred while processing the signature request data on our back-end.
        /// For example: Invalid text tags
        /// </summary>
        public const string signature_request_invalid = "signature_request_invalid";
        /// <summary>
        /// An account created via one of your apps has been confirmed.
        /// </summary>
        public const string account_confirmed = "account_confirmed";
        /// <summary>
        /// The Template has been created.
        /// </summary>
        public const string template_created = "template_created";
        /// <summary>
        /// There was an error while creating your template.
        /// </summary>
        public const string template_error = "template_error";
    }

    /// <summary>
    /// Contains possible values for <see cref="Signature.StatusCode" />.
    /// </summary>
    public static class SignatureStatusCodes
    {
        /// <summary>
        /// Success
        /// </summary>
        public const string Success = "success";
        /// <summary>
        /// On hold. This could be because the sending account needs to confirm its email address, or because of insufficient funds.
        /// </summary>
        public const string OnHold = "on_hold";
        /// <summary>
        /// Signed
        /// </summary>
        public const string Signed = "signed";
        /// <summary>
        /// Awaiting signature
        /// </summary>
        public const string AwaitingSignature = "awaiting_signature";
        /// <summary>
        /// Unknown error
        /// </summary>
        public const string ErrorUnknown = "error_unknown";
        /// <summary>
        /// File could not be converted
        /// </summary>
        public const string ErrorFile = "error_file";
        /// <summary>
        /// Invalid form fields placement
        /// </summary>
        public const string ErrorComponentPosition = "error_component_position";
        /// <summary>
        /// File contained invalid text tags
        /// </summary>
        public const string ErrorTextTag = "error_text_tag";
    }

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
    }

    /// <summary>
    /// Contains options for <see cref="NewUnclaimedDraft.Type"/>.
    /// </summary>
    public static class UnclaimedDraftTypes
    {
        /// <summary>
        /// Used to create a claimable file.
        /// </summary>
        public const string SendDocument = "send_document";

        /// <summary>
        /// Used to create a claimable signature request.
        /// </summary>
        public const string RequestSignature = "request_signature";

    }
}
