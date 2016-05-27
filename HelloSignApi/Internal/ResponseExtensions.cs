using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloSignApi
{
    static class ResponseExtensions
    {
        internal static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new UnderscoreMappingResolver()
        };

        public static Task<T> ParseApiResponseAsync<T>(this HttpResponseMessage msg) where T : ApiResponse
        {
            return msg.Content.ReadAsStringAsync().ContinueWith(t =>
            {
                var json = t.Result;

                var model = JsonConvert.DeserializeObject<T>(json, JsonSettings);
                if (model == null) { model = Activator.CreateInstance<T>(); }

                model.FillExtraValues(msg);

                return model;
            });
        }
    }
}
