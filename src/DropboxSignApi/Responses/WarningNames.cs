namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Contains possible values for <see cref="WarningResponse.Name" />.
    /// </summary>
    public static class WarningNames
    {
        /// <summary>
        /// The email address of the account making the Signature Request has not been confirmed. 
        /// The Signature Request will be placed on hold until it is confirmed.
        /// </summary>
        public const string Unconfirmed = "unconfirmed";
        /// <summary>
        /// The value provided for a custom field is too long. 
        /// The custom field will extend beyond the limits of its container and may not display the way you intended.
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
        /// Two or more of the form fields specified are overlapping, 
        /// which may prevent signers from completing the document.
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
        /// A template with signer reassignment was used on an endpoint that does not support it (e.g. bulk send with template). 
        /// The template will still be used, but without signer reassignment enabled.
        /// </summary>
        public const string ReassignUnsupported = "reassign_unsupported";
        /// <summary>
        /// Templates can only be used once in a signature request. A duplicated template ids was passed in the request.
        /// </summary>
        public const string DuplicateTemplateIds = "duplicate_template_ids";
        /// <summary>
        /// The value for the parameter had a level of precision too high 
        /// (e.g. expires_at have seconds level of granularity, instead of hour for time).
        /// </summary>
        public const string ValueTooPrecise = "value_too_precise";
    }
}
