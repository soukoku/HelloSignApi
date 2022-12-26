using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;

namespace DropboxSignApi.Internal
{
    static class JsonExtensions
    {
        /// <summary>
        /// The json settings used to serialize/deserize API models.
        /// </summary>
        public static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        /// <summary>
        /// Serializes the object into json and wraps it in
        /// an <see cref="HttpContent"/>.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HttpContent ToJsonContent(this object data)
        {
            var json = JsonConvert.SerializeObject(data, JsonSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
