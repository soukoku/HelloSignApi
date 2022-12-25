using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace DropboxSignApi.Common
{
    /// <summary>
    /// Represents an event from callback.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Actual value of <see cref="EventTime"/>.
        /// </summary>
        [JsonProperty("event_time"), EditorBrowsable(EditorBrowsableState.Never)]
        public long? EventTimeRaw { get; set; }

        /// <summary>
        /// When the event was created.
        /// </summary>
        [JsonIgnore]
        public DateTime? EventTime { get { return EventTimeRaw?.FromUnixTime(); } }

        /// <summary>
        /// Type of event being reported. See <see cref="EventTypes"/> values.
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// Unique hash of this event.
        /// </summary>
        public string EventHash { get; set; }

        /// <summary>
        /// A map of values containing data related to this event.
        /// </summary>
        public EventMetadata EventMetadata { get; set; }

        /// <summary>
        /// Attached signature request if applicable.
        /// </summary>
        public SignatureRequest SignatureRequest { get; set; }

        /// <summary>
        /// Attached template info if applicable.
        /// </summary>
        public Template Template { get; set; }

        /// <summary>
        /// Attached account info if applicable.
        /// </summary>
        public Account Account { get; set; }
    }
}
