using DropboxSignApi.Requests;
using Newtonsoft.Json;
using System;
using System.IO;

namespace DropboxSignApi.Internal
{
    class PendingFileConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is PendingFile file)
            {
                // serialize as byte[] to string
                // could potentially use lots of memory but whatev
                if (file.Stream is MemoryStream ms)
                {
                    serializer.Serialize(writer, ms.ToArray());
                }
                else
                {
                    // TODO make this work
                    throw new NotImplementedException();
                }
            }
        }
    }
}