﻿using DropboxSignApi.Internal;
using DropboxSignApi.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DropboxSignApi
{
    static class HttpResponseExtensions
    {
        public static async Task<T> ParseApiResponseAsync<T>(this HttpResponseMessage msg, IApiLog log) where T : ApiResponse
        {
            var json = await msg.Content.ReadAsStringAsync().ConfigureAwait(false);
            log.ResponseRead<T>(json);

            var model = JsonConvert.DeserializeObject<T>(json, JsonExtensions.JsonSettings);
            if (model == null) { model = Activator.CreateInstance<T>(); }

            model.FillExtraValues(msg);

            return model;
        }
    }
}
