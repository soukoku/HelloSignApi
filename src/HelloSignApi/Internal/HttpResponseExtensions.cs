using HelloSignApi.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HelloSignApi
{
    static class HttpResponseExtensions
    {
        internal static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public static Task<T> ParseApiResponseAsync<T>(this HttpResponseMessage msg, IApiLog log) where T : ApiResponse
        {
            return msg.Content.ReadAsStringAsync().ContinueWith(t =>
            {
                var json = t.Result;
                log.ResponseRead<T>(json);

                var model = JsonConvert.DeserializeObject<T>(json, JsonSettings);
                if (model == null) { model = Activator.CreateInstance<T>(); }

                model.FillExtraValues(msg);

                return model;
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
}
