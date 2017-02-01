using HelloSignApi.Requests;
using HelloSignApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// this file contains constant values only

namespace HelloSignApi
{
    /// <summary>
    /// Contains possible values for field types.
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

#if !PORTABLE
    /// <summary>
    /// Contains possible values for <see cref="Event.EventType" />.
    /// </summary>
    public static class EventTypes
    {
        /// <summary>
        /// The SignatureRequest has been viewed.
        /// </summary>
        public const string SignatureRequestViewed = "signature_request_viewed";
        /// <summary>
        /// A signer has completed all required fields on the SignatureRequest.
        /// </summary>
        public const string SignatureRequestSigned = "signature_request_signed";
        /// <summary>
        /// The SignatureRequest has been sent successfully.
        /// </summary>
        public const string SignatureRequestSent = "signature_request_sent";
        /// <summary>
        /// The SignatureRequest was declined by a signer.
        /// </summary>
        public const string SignatureRequestDeclined = "signature_request_declined";
        /// <summary>
        /// All signers have been sent a reminder to complete the SignatureRequest.
        /// </summary>
        public const string SignatureRequestRemind = "signature_request_remind";
        /// <summary>
        /// All signers have completed all required fields for the SignatureRequest and the final PDF is ready to be downloaded.
        /// </summary>
        public const string SignatureRequestAllSigned = "signature_request_all_signed";
        /// <summary>
        /// We're unable to convert the file you provided.
        /// </summary>
        public const string FileError = "file_error";
        /// <summary>
        /// An unknown error occurred during while processing a signature request.
        /// </summary>
        public const string UnknownError = "unknown_error";
        /// <summary>
        /// An email address for one of the signers on your signature request has bounced. May be correctable by updating
        /// the request.
        /// </summary>
        public const string SignatureRequestEmailBounce = "signature_request_email_bounce";
        /// <summary>
        /// An error occurred while processing the signature request data on our back-end.
        /// For example: Invalid text tags
        /// </summary>
        public const string SignatureRequestInvalid = "signature_request_invalid";
        /// <summary>
        /// An account created via one of your apps has been confirmed.
        /// </summary>
        public const string AccountConfirmed = "account_confirmed";
        /// <summary>
        /// The Template has been created.
        /// </summary>
        public const string TemplateCreated = "template_created";
        /// <summary>
        /// There was an error while creating your template.
        /// </summary>
        public const string TemplateError = "template_error";
    }
#endif

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
        /// Declined
        /// </summary>
        public const string Declined = "declined";
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
