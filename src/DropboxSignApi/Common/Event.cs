using Newtonsoft.Json;
using System;

namespace DropboxSignApi.Common
{
    /// <summary>
    /// Represents an event from callback.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// When the event was created.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime EventTime { get; set; }

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
