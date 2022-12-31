using System;

namespace Soukoku.DropboxSignApi
{
    /// <summary>
    /// Represents an event from API callback.
    /// </summary>
    public class EventCallbackRequestEvent
    {
        /// <summary>
        /// When the event was created.
        /// </summary>
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
    }
}
