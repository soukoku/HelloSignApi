using DropboxSignApi.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    [JsonConverter(typeof(SubFormFieldConverter))]
    public abstract class SubFormFieldBase
    {
        /// <summary>
        /// Represents the integer index of the file the field should be attached to.
        /// </summary>
        public int DocumentIndex { get; set; }

        /// <summary>
        /// An identifier for the field that is unique across all documents in the request.
        /// </summary>
        public string ApiId { get; set; }

        /// <summary>
        /// The type of this form field. See <see cref="DropboxSignApi.FieldTypes"/> values.
        /// </summary>
        public virtual string Type { get => FieldTypes.Text; }

        /// <summary>
        /// Whether this field is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// <para>Signer index identified by the offset in the signers parameter 
        /// (0-based indexing), indicating which signer should fill out the field.
        /// </para>
        /// <para>If type is text-merge or checkbox-merge, 
        /// you must set this to sender in order to use pre-filled data.</para>
        /// </summary>
        public string Signer { get; set; }

        /// <summary>
        /// Size of the field in pixels.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Size of the field in pixels.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Location coordinates of the field in pixels.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Location coordinates of the field in pixels.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Display name for the field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Page in the document where the field 
        /// should be placed (requires documents be PDF files).
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Each text field may contain a validation_type parameter. 
        /// Check out the list of validation types to learn more about the possible values.
        /// </summary>
        public string ValidationType { get; set; }

        public string ValidationCustomRegex { get; set; }

        public string ValidationCustomRegexFormatLabel { get; set; }
    }

    public class SubFormFieldText : SubFormFieldBase
    {
        /// <summary>
        /// Placeholder value for text field.
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// Auto fill type for populating fields automatically. 
        /// Check out the list of auto fill types to learn more about the possible values.
        /// </summary>
        public string AutoFillType { get; set; }

        /// <summary>
        /// Link two or more text fields. Enter data into one linked text field, 
        /// which automatically fill all other linked text fields.
        /// </summary>
        public string LinkId { get; set; }

        /// <summary>
        /// Masks entered data. For more information see Masking sensitive information. 
        /// true for masking the data in a text field, otherwise false.
        /// </summary>
        public bool Masked { get; set; }
    }

    public class SubFormFieldDropdown : SubFormFieldBase
    {
        public override string Type => FieldTypes.Dropdown;

        /// <summary>
        /// Array of string values representing dropdown values.
        /// </summary>
        public IList<string> Options { get; set; } = new List<string>();

        /// <summary>
        /// Selected value in options array. Value must exist in array.
        /// </summary>
        public string Content { get; set; }
    }

    public class SubFormFieldHyperlink : SubFormFieldBase
    {
        public override string Type => FieldTypes.Hyperlink;

        /// <summary>
        /// Link text.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Link URL.
        /// </summary>
        public string ContentUrl { get; set; }
    }

    public class SubFormFieldCheckbox : SubFormFieldBase
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

    public class SubFormFieldRadio : SubFormFieldBase
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

    public class SubFormFieldSignature : SubFormFieldBase
    {
        public override string Type => FieldTypes.Signature;
    }

    public class SubFormFieldDateSigned : SubFormFieldBase
    {
        public override string Type => FieldTypes.DateSigned;
    }

    public class SubFormFieldInitials : SubFormFieldBase
    {
        public override string Type => FieldTypes.Initials;
    }

    public class SubFormFieldTextMerge : SubFormFieldText
    {
        public override string Type => FieldTypes.TextMerge;
    }

    public class SubFormFieldCheckboxMerge : SubFormFieldCheckbox
    {
        public override string Type => FieldTypes.CheckBoxMerge;
    }
}