using DropboxSignApi.Common;
using DropboxSignApi.Responses;

namespace DropboxSignApi
{
    /// <summary>
    /// Used to deserialize raw event json only.
    /// Unwrap to have all properties put in place.
    /// </summary>
    class EventWrap
    {
        public Event Event { get; set; }

        public SignatureRequest SignatureRequest { get; set; }
        public AccountResponse Account { get; set; }
        public TemplateResponse Template { get; set; }

        public Event Unwrap()
        {
            if (Event != null)
            {
                Event.SignatureRequest = SignatureRequest;
                Event.Account = Account;
                Event.Template = Template;
            }
            return Event;
        }
    }
}
