using Soukoku.DropboxSignApi.Responses;

namespace Soukoku.DropboxSignApi
{
    /// <summary>
    /// A logger that does nothing.
    /// </summary>
    class NullApiLog : IApiLog
    {
        public static readonly IApiLog Instance = new NullApiLog();

        private NullApiLog() { }

        public void JsonSerialized<T>(string json) { }

        public void MultipartAdded(string key, string value) { }

        public void Requesting(string httpMethod, string apiUrl) { }

        public void ResponseRead<TResp>(string content) where TResp : ResponseWrap { }
    }
}
