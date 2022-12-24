using DropboxSignApi.Responses;

namespace DropboxSignApi
{
    /// <summary>
    /// Provides opportunity to catch various things during API calls.
    /// </summary>
    public interface IApiLog
    {
        /// <summary>
        /// Called before requeting an API.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="apiUrl">The API URL.</param>
        void Requesting(string httpMethod, string apiUrl);

        /// <summary>
        /// Called when a single request parameter-value pair has been added to an API request.
        /// This can be useful to troubleshoot the values to be sent.
        /// This excludes file sent as data for obvious reasons.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void ParameterAdded(string key, string value);

        /// <summary>
        /// Called when the API response content has been read and before
        /// deserialization occurs. This does not apply to direct file downloads.
        /// </summary>
        /// <param name="content"></param>
        /// <typeparam name="TResp">The expected response type.</typeparam>
        void ResponseRead<TResp>(string content) where TResp : ApiResponse;
    }
}
