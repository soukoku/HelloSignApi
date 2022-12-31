using DropboxSignApi.Responses;
using DropboxSignApi.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DropboxSignApi
{
    static class HttpResponseExtensions
    {
        public static async Task<T> ParseApiResponseAsync<T>(this HttpResponseMessage msg, IApiLog log) where T : ResponseWrap
        {
            var json = await msg.Content.ReadAsStringAsync().ConfigureAwait(false);
            log.ResponseRead<T>(json);

            var model = json.FromJson<T>();
            if (model == null) { model = Activator.CreateInstance<T>(); }

            model.FillExtraValues(msg);

            return model;
        }
    }
}
