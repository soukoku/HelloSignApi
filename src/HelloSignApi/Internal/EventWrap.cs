namespace HelloSignApi
{
    /// <summary>
    /// Used to deserialize raw event only.
    /// </summary>
    class EventWrap
    {
        public Event Event { get; set; }

        public SignatureRequest SignatureRequest { get; set; }
        public Account Account { get; set; }
        public Template Template { get; set; }

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
