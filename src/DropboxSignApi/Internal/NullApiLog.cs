using DropboxSignApi.Responses;

namespace DropboxSignApi
{
    // this class does nothing.

    class NullApiLog : IApiLog
    {
        public static readonly IApiLog Instance = new NullApiLog();

        public void ParameterAdded(string key, string value) { }

        public void Requesting(string httpMethod, string apiUrl) { }

        public void ResponseRead<TResp>(string content) where TResp : ApiResponse
        {
        }
    }
}
