using DropboxSignApi.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Data for creating or modifying an api app.
    /// </summary>
    public class ApiAppRequest
    {
        /// <summary>
        /// The name you want to assign to the ApiApp.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The domain names the ApiApp will be associated with.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IList<string> Domains { get; set; }

        /// <summary>
        /// The URL at which the ApiApp should receive event callbacks.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// An image file to use as a custom logo in embedded contexts. (Only applies to some API plans)
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public byte[] CustomLogoFile { get; set; }

        /// <summary>
        /// OAuth related parameters.
        /// </summary>
        [JsonProperty("oauth")]
        public SubOAuth OAuth { get; set; }

        /// <summary>
        /// Additional options supported by API App.
        /// </summary>
        public ApiAppOptions Options { get; set; }

        /// <summary>
        /// White labeling options to be used to customize the app's signer page. (Only applies to some API plans)
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public SubWhiteLabelingOptions WhiteLabelingOptions { get; set; }
    }
}
