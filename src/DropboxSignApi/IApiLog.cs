using Soukoku.DropboxSignApi.Responses;

namespace Soukoku.DropboxSignApi
{
    /// <summary>
    /// A log that provides opportunity to catch various things during API calls.
    /// </summary>
    public interface IApiLog
    {
        /// <summary>
        /// Called when a single request parameter-value pair has been added 
        /// to a multipart request before making an API call.
        /// This can be useful to troubleshoot the values to be sent.
        /// This excludes file sent as data for size reasons.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void MultipartAdded(string key, string value);

        /// <summary>
        /// Called when the request has been serialized into JSON
        /// before making an API call.
        /// </summary>
        /// <typeparam name="TReq">The requesting type info.</typeparam>
        /// <param name="json">The serialized JSON string.</param>
        void JsonSerialized<TReq>(string json);

        /// <summary>
        /// Called right before making an API call.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="apiUrl">The API URL.</param>
        void Requesting(string httpMethod, string apiUrl);

        /// <summary>
        /// Called when the API response content has been read and before
        /// deserialization occurs. This does not apply to direct file downloads.
        /// </summary>
        /// <param name="content">The string content before deserialization.</param>
        /// <typeparam name="TResp">The response type to deserialize into.</typeparam>
        void ResponseRead<TResp>(string content) where TResp : ResponseWrap;
    }
}
