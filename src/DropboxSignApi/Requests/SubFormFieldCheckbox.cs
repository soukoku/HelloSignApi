namespace DropboxSignApi.Requests
{
    public class SubFormFieldCheckbox : SubFormFieldsPerDocumentBase
    {
        public override string Type => FieldTypes.CheckBox;

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