using DropboxSignApi.Common;
using DropboxSignApi.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DropboxSignApi
{
    /// <summary>
    /// Main client for performaing HelloSign api calls.
    /// </summary>
    public partial class DropboxSignClient
    {
        static readonly ConcurrentDictionary<string, HttpClient> __clientCache = new ConcurrentDictionary<string, HttpClient>();

        readonly string _apiKey;
        readonly HttpClient _client;
        readonly IApiLog _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="DropboxSignClient" /> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="getHttpClientRoutine">Optional custom routine to provide an <see cref="HttpClient" />. A cached version will be used if this is null.</param>
        /// <param name="log">The api logger. Can be null.</param>
        /// <exception cref="ArgumentException">Api key is required.;apiKey</exception>
        public DropboxSignClient(string apiKey, Func<HttpClient> getHttpClientRoutine = null, IApiLog log = null)
        {
            if (string.IsNullOrEmpty(apiKey)) { throw new ArgumentException("Api key is required.", nameof(apiKey)); }

            _apiKey = apiKey;
            _log = log ?? NullApiLog.Instance;

            if (getHttpClientRoutine != null) _client = getHttpClientRoutine();

            if (_client == null)
            {
                _client = __clientCache.GetOrAdd(apiKey, key =>
                 {
                     var client = new HttpClient(new HttpClientHandler
                     {
                         AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip
                     });
                     return client;
                 });
            }

            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(apiKey + ":")));
        }


        /// <summary>
        /// Parsed the data received from the event callback.
        /// </summary>
        /// <param name="eventData">json data from the callback.</param>
        /// <param name="verify">Validate the event for integrity. 
        /// If validation fails the return value is null.</param>
        /// <returns></returns>
        public Event ParseEvent(string eventData, bool verify = true)
        {
            var wrap = JsonConvert.DeserializeObject<EventWrap>(eventData ?? "", HttpResponseExtensions.JsonSettings);
            if (verify && wrap != null && wrap.Event != null)
            {
                var key = Encoding.UTF8.GetBytes(_apiKey);
                var input = Encoding.UTF8.GetBytes($"{wrap.Event.EventTimeRaw}{wrap.Event.EventType}");
                var hash = Hasher.GetHMACSHA256Hash(key, input);
                if (!string.Equals(hash, wrap.Event.EventHash, StringComparison.OrdinalIgnoreCase))
                {
                    wrap = null;
                }
            }
            return wrap?.Unwrap();
        }


        /// <summary>
        /// Performs an http GET opertion to the api.
        /// </summary>
        /// <typeparam name="TResp">Api response type.</typeparam>
        /// <returns></returns>
        async Task<TResp> GetAsync<TResp>(string apiUrl,
            CancellationToken cancellationToken) where TResp : ApiResponse
        {
           _log.Requesting("GET", apiUrl);
            var resp = await _client.GetAsync(apiUrl, cancellationToken).ConfigureAwait(false);
            return await resp.ParseApiResponseAsync<TResp>(_log).ConfigureAwait(false);
        }

        /// <summary>
        /// Performs an http POST opertion to the api.
        /// </summary>
        /// <typeparam name="TResp">Api response type.</typeparam>
        /// <returns></returns>
        async Task<TResp> PostAsync<TResp>(string apiUrl, HttpContent content,
            CancellationToken cancellationToken) where TResp : ApiResponse
        {
            _log.Requesting("POST", apiUrl);
            var resp = await _client.PostAsync(apiUrl, content, cancellationToken).ConfigureAwait(false);
            return await resp.ParseApiResponseAsync<TResp>(_log).ConfigureAwait(false);
        }
    }
}
