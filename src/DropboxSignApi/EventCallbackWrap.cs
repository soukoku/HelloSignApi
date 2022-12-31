using Soukoku.DropboxSignApi.Responses;

namespace Soukoku.DropboxSignApi
{
    /// <summary>
    /// Deserialized event callback data wrapper.
    /// </summary>
    public class EventCallbackWrap
    {
        /// <summary>
        /// The API event.
        /// </summary>
        public EventCallbackRequestEvent Event { get; set; }

        /// <summary>
        /// The signature request if applicable.
        /// </summary>
        public SignatureRequestResponse SignatureRequest { get; set; }

        /// <summary>
        /// The template info if applicable.
        /// </summary>
        public TemplateResponse Template { get; set; }

        /// <summary>
        /// The account info if applicable.
        /// </summary>
        public AccountResponse Account { get; set; }
    }
}
