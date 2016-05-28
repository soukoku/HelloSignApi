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
        public static void AddParameter(this MultipartFormDataContent content, string name, string value, string fileName = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                var sc = new StringContent(value);
                sc.Headers.ContentType = null;
                content.Add(sc, name, fileName);
            }
        }

        static void AddMetadata(this MultipartFormDataContent content, IDictionary<string, string> metadata)
        {
            foreach (var kv in metadata)
            {
                content.AddParameter($"metadata[{kv.Key}]", kv.Value);
            }
        }

        static void AddSigners(this MultipartFormDataContent content, IList<Signer> signers)
        {
            int i = 0;
            foreach (var signer in signers)
            {
                content.AddParameter($"signers[{i}][name]", signer.Name ?? signer.Email);
                content.AddParameter($"signers[{i}][email_address]", signer.Email);
                if (signer.Order.HasValue)
                {
                    content.AddParameter($"signers[{i}][order]", signer.Order.ToString());
                }
                content.AddParameter($"signers[{i}][pin]", signer.Pin);
                i++;
            }
        }

        static void AddFiles(this MultipartFormDataContent content, IList<PendingFile> files)
        {
            try
            {
                int i = 0;
                foreach (var file in files)
                {
                    if (file.RemotePath != null)
                    {
                        content.AddParameter($"file_url[{i}]", file.RemotePath.ToString(), file.FileName);
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

        static void AddRequestBase(this MultipartFormDataContent content, NewRequestBase request)
        {
            if (request.TestMode) { content.AddParameter("test_mode", "1"); }

            content.AddParameter("subject", request.Subject);
            content.AddParameter("message", request.Message);
            content.AddSigners(request.Signers);
            int i = 0;
            foreach (var cc in request.CcEmailAddresses)
            {
                content.AddParameter($"cc_email_addresses[{i++}]", cc);
            }
            content.AddMetadata(request.Metadata);
        }

        public static void AddRequest(this MultipartFormDataContent content, NewSignatureRequest request)
        {
            content.AddRequestBase(request);

            content.AddParameter("client_id", request.ClientId);
        }

        public static void AddEmbeddedRequest(this MultipartFormDataContent content, NewEmbeddedSignatureRequest request)
        {
            content.AddRequest(request);

            content.AddParameter("title", request.Title);
        }

        public static void AddUnclaimedDraft(this MultipartFormDataContent content, NewUnclaimedDraft draft)
        {
            content.AddRequestBase(draft);

            content.AddParameter("type", draft.Type);
        }

        public static void AddEmbeddedUnclaimedDraft(this MultipartFormDataContent content, NewEmbeddedUnclaimedDraft draft)
        {
            content.AddUnclaimedDraft(draft);

            content.AddParameter("client_id", draft.ClientId);
            content.AddParameter("requester_email_address", draft.RequesterEmailAddress);
            content.AddParameter("signing_redirect_url", draft.SigningRedirectUrl);
            if (draft.IsForEmbeddedSigning) { content.AddParameter("is_for_embedded_signing", "1"); }


        }
    }
}
