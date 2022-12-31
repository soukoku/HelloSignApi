namespace DropboxSignApi.Requests
{
    public class SubFormFieldRadio : SubFormFieldsPerDocumentBase
    {
        public override string Type => FieldTypes.Radio;

        /// <summary>
        /// String referencing group defined in form_field_groups parameter.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// 1 for checking the checkbox field by default, otherwise 0.
        /// </summary>
        public int Checked { get; set; }
    }
}