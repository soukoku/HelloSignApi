namespace DropboxSignApi
{
    /// <summary>
    /// Metadata in an event callback.
    /// </summary>
    public class EventMetadata
    {
        /// <summary>
        /// Signature associated with this event. Only set when <see cref="EventCallbackRequestEvent.EventType"/> 
        /// is <see cref="EventTypes.SignatureRequestSigned"/> or 
        /// <see cref="EventTypes.SignatureRequestViewed"/>.
        /// </summary>
        public string RelatedSignatureId { get; set; }

        /// <summary>
        /// Id of the account this event is reported for.
        /// </summary>
        public string ReportedForAccountId { get; set; }

        /// <summary>
        /// Client id of the app this event is reported for.
        /// </summary>
        public string ReportedForAppId { get; set; }
    }
}
