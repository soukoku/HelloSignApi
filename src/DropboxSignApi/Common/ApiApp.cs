using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace DropboxSignApi.Common
{
    /// <summary>
    /// Contains information about an API App.
    /// </summary>
    public class ApiApp
    {
        /// <summary>
        /// The app's callback URL (for events).
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// The app's client ID.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Actual value of <see cref="CreatedAt"/>.
        /// </summary>
        [JsonProperty("created_at"), EditorBrowsable(EditorBrowsableState.Never)]
        public long CreatedAtRaw { get; set; }

        /// <summary>
        /// The time that the app was created.
        /// </summary>
        [JsonIgnore]
        public DateTime CreatedAt { get { return CreatedAtRaw.FromUnixTime(); } }

        /// <summary>
        /// The domain name(s) associated with the app.
        /// </summary>
        public string[] Domains { get; set; }

        /// <summary>
        /// The name of the app.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Boolean to indicate if the app has been approved.
        /// </summary>
        public bool? IsApproved { get; set; }

        /// <summary>
        /// An object describing the app's OAuth properties, or null if OAuth is not configured for the app.
        /// </summary>
        [JsonProperty("oauth")]
        public OAuth OAuth { get; set; }

        /// <summary>
        /// An object with options that override account settings.
        /// </summary>
        public ApiAppOptions Options { get; set; }

        /// <summary>
        /// An object describing the app's owner.
        /// </summary>
        public AccountMin OwnerAccount { get; set; }

        /// <summary>
        /// An object with options to customize the app's signer page.
        /// </summary>
        public WhiteLabelingOptions WhiteLabelingOptions { get; set; }
    }
}
