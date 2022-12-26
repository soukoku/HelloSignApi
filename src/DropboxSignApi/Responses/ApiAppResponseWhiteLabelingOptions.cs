namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Represents the white labeling options for the document view.
    /// </summary>
    public class ApiAppResponseWhiteLabelingOptions
    {
        ///// <summary>
        ///// Deserializes the serialized data into a <see cref="WhiteLabelingOptions"/>.
        ///// </summary>
        ///// <param name="serializedData">The serialized data.</param>
        ///// <returns></returns>
        //public static WhiteLabelingOptions Deserialize(string serializedData)
        //{
        //    return JsonConvert.DeserializeObject<WhiteLabelingOptions>(serializedData ?? string.Empty, HttpResponseExtensions.JsonSettings);
        //}

        ///// <summary>
        ///// Serializes this instance for use with the api.
        ///// </summary>
        ///// <returns></returns>
        //public string Serialize()
        //{
        //    return JsonConvert.SerializeObject(this, HttpResponseExtensions.JsonSettings);
        //}

        /// <summary>
        /// 
        /// </summary>
        public string HeaderBackgroundColor { get; set; } = "#1A1A1A";

        /// <summary>
        /// Terms of service to display (terms1 or terms2).
        /// </summary>
        public string LegalVersion { get; set; } = "terms1";

        /// <summary>
        /// 
        /// </summary>
        public string PageBackgroundColor { get; set; } = "#F7F8F9";

        /// <summary>
        /// 
        /// </summary>
        public string LinkColor { get; set; } = "#00B3E6";

        /// <summary>
        /// 
        /// </summary>
        public string PrimaryButtonColor { get; set; } = "#00B3E6";

        /// <summary>
        /// 
        /// </summary>
        public string PrimaryButtonColorHover { get; set; } = "#00B3E6";

        /// <summary>
        /// 
        /// </summary>
        public string PrimaryButtonTextColor { get; set; } = "#FFFFFF";

        /// <summary>
        /// 
        /// </summary>
        public string PrimaryButtonTextColorHover { get; set; } = "#FFFFFF";

        /// <summary>
        /// 
        /// </summary>
        public string SecondaryButtonColor { get; set; } = "#FFFFFF";

        /// <summary>
        /// 
        /// </summary>
        public string SecondaryButtonColorHover { get; set; } = "#FFFFFF";

        /// <summary>
        /// 
        /// </summary>
        public string SecondaryButtonTextColor { get; set; } = "#00B3E6";

        /// <summary>
        /// 
        /// </summary>
        public string SecondaryButtonTextColorHover { get; set; } = "#00B3E6";

        /// <summary>
        /// 
        /// </summary>
        public string TextColor1 { get; set; } = "#808080";

        /// <summary>
        /// 
        /// </summary>
        public string TextColor2 { get; set; } = "#FFFFFF";

    }

    /// <summary>
    /// White labeling options for API app requests.
    /// </summary>
    public class SubWhiteLabelingOptions : ApiAppResponseWhiteLabelingOptions
    {
        /// <summary>
        /// Resets white labeling options to defaults. Only useful when updating an API App.
        /// </summary>
        public bool ResetToDefault { get; set; }
    }
}
