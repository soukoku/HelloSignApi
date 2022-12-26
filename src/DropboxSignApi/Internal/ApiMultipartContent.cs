using DropboxSignApi.Requests;
using System.Collections.Generic;
using System.Net.Http;

namespace DropboxSignApi
{
    /// <summary>
    /// Easy MultipartFormDataContent with custom handling of 
    /// API request models.
    /// </summary>
    partial class ApiMultipartContent : MultipartFormDataContent
    {
        private readonly IApiLog log;

        /// <summary>
        /// Creates a new multipart content with the object data
        /// that's suitable for making API requests.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="log"></param>
        public ApiMultipartContent(object obj, IApiLog log)
        {


            this.log = log;
        }

        /// <summary>
        /// Adds a single parameter value.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="fileName"></param>
        public void AddParameter(string name, string value, string fileName = null)
        {
            // empty string is still passed
            if (value != null)
            {
                log.MultipartAdded(name, value);
                var sc = new StringContent(value);
                sc.Headers.ContentType = null;
                if (fileName == null)
                {
                    Add(sc, name);
                }
                else
                {
                    Add(sc, name, fileName);
                }
            }
        }

        /// <summary>
        /// Adds the metadata value.
        /// </summary>
        /// <param name="metadata"></param>
        public void AddMetadata(IDictionary<string, string> metadata)
        {
            if (metadata == null) return;
            foreach (var kv in metadata)
            {
                AddParameter($"metadata[{kv.Key}]", kv.Value);
            }
        }

        public void AddAttachments(IList<SubAttachment> attachments)
        {
            int i = 0;
            foreach (var att in attachments)
            {
                AddParameter($"attachments[{i}][name]", att.Name);
                AddParameter($"attachments[{i}][instructions]", att.Instructions);
                AddParameter($"attachments[{i}][signer_index]", att.SignerIndex.ToString());
                AddParameter($"attachments[{i}][required]", att.Required ? "1" : "0");
                i++;
            }
        }
    }
}