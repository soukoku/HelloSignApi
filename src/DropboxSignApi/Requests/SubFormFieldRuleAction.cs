namespace DropboxSignApi.Requests
{
    public class SubFormFieldRuleAction
    {
        /// <summary>
        /// true to hide the target field when rule is satisfied, otherwise false.
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// "change-field-visibility" "change-group-visibility"
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// field_id or group_id is required, but not both.
        /// Must reference the api_id of an existing field defined within form_fields_per_document.
        /// Cannot use with group_id. Trigger and action fields must belong to the same signer.
        /// </summary>
        public string FieldId { get; set; }

        /// <summary>
        /// group_id or field_id is required, but not both.
        /// Must reference the ID of an existing group defined within form_field_groups.
        /// Cannot use with field_id. Trigger and action fields and groups must belong to the same signer.
        /// </summary>
        public string GroupId { get; set; }
    }
}