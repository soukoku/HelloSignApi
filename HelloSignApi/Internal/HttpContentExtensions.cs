using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace HelloSignApi
{
    static class HttpContentExtensions
    {
        public static void AddFormValue(this MultipartFormDataContent content, string name, string value, string fileName = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                var sc = new StringContent(value);
                sc.Headers.ContentType = null;
                content.Add(sc, name, fileName);
            }
        }

        public static void AddFormValue(this MultipartFormDataContent content, IDictionary<string, string> metadata)
        {
            foreach (var kv in metadata)
            {
                content.AddFormValue($"metadata[{kv.Key}]", kv.Value);
            }
        }

        public static void AddFormValue(this MultipartFormDataContent content, IList<Signer> signers)
        {
            int i = 0;
            foreach (var signer in signers)
            {
                content.AddFormValue($"signers[{i}][name]", signer.Name ?? signer.Email);
                content.AddFormValue($"signers[{i}][email_address]", signer.Email);
                content.AddFormValue($"signers[{i}][order]", signer.Order.ToString());
                i++;
            }
        }

        public static void AddFormValue(this MultipartFormDataContent content, IList<PendingFile> files)
        {
            try
            {
                int i = 0;
                foreach (var file in files)
                {
                    if (file.RemotePath != null)
                    {
                        content.AddFormValue($"file_url[{i}]", file.RemotePath.ToString(), file.FileName);
                    }
                    else if (file.LocalPath != null)
                    {
                        var fc = new StreamContent(File.Open(file.LocalPath, FileMode.Open, FileAccess.Read, FileShare.Read));
                        content.Add(fc, $"file_url[{i}]", file.FileName);
                    }
                    else if (file.Stream != null)
                    {
                        var fc = new StreamContent(file.Stream);
                        content.Add(fc, $"file_url[{i}]", file.FileName);
                    }
                    i++;
                }
            }
            catch
            {
                content.Dispose();
                throw;
            }
        }

        public static void AddFormValue(this MultipartFormDataContent content, NewUnclaimedDraft draft)
        {
            if (draft.TestMode) { content.AddFormValue("test_mode", "1"); }

            content.AddFormValue("type", draft.Type);
            content.AddFormValue("subject", draft.Subject);
            content.AddFormValue("message", draft.Message);
            content.AddFormValue(draft.Signers);
            int i = 0;
            foreach (var cc in draft.CcEmailAddresses)
            {
                content.AddFormValue($"cc_email_addresses[{i++}]", cc);
            }
            content.AddFormValue(draft.Metadata);
        }

        public static void AddFormValue(this MultipartFormDataContent content, NewEmbeddedUnclaimedDraft draft)
        {
            content.AddFormValue((NewUnclaimedDraft)draft);

            content.AddFormValue("client_id", draft.ClientId);
            content.AddFormValue("requester_email_address", draft.RequesterEmailAddress);
            content.AddFormValue("signing_redirect_url", draft.SigningRedirectUrl);
            if (draft.IsForEmbeddedSigning) { content.AddFormValue("is_for_embedded_signing", "1"); }


        }
    }
}
