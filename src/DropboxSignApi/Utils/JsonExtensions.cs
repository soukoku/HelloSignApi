using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;

namespace Soukoku.DropboxSignApi.Utils
{
    /// <summary>
    /// Contains methods for converting to/from json according to the API's rules.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// The json settings used to serialize/deserize API models.
        /// </summary>
        internal static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            Converters = new[] { new UnixDateTimeConverter() },
#if DEBUG
            Formatting = Formatting.Indented,
#endif
        };

        /// <summary>
        /// Serializes the object into json and wraps it in
        /// an <see cref="HttpContent"/>.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        internal static HttpContent ToJsonContent<T>(this T data, IApiLog log)
        {
            var json = data.ToJson();

            log.JsonSerialized<T>(json);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Serializes an object using the settings for
        /// the Dropbox Sign API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T data)
        {
            return JsonConvert.SerializeObject(data, JsonSettings);
        }

        /// <summary>
        /// Deserializes into an object using the settings for
        /// the Dropbox Sign API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonSettings);
        }
    }
}
