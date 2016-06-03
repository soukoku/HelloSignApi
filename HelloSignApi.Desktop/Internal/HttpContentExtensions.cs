using HelloSignApi.Requests;
using Newtonsoft.Json;
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
            // empty string is still passed
            if (value != null)
            {
                var sc = new StringContent(value);
                sc.Headers.ContentType = null;
                if (fileName == null)
                {
                    content.Add(sc, name);
                }
                else
                {
                    content.Add(sc, name, fileName);
                }
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
#if DESKTOP
                    else if (file.LocalPath != null)
                    {
                        var fc = new StreamContent(File.Open(file.LocalPath, FileMode.Open, FileAccess.Read, FileShare.Read));
                        fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                        content.Add(fc, $"file[{i}]", file.FileName);
                    }
#endif
                    else if (file.Stream != null)
                    {
                        var fc = new StreamContent(file.Stream);
                        fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                        content.Add(fc, $"file[{i}]", file.FileName);
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

            if (request.UseTextTags) { content.AddParameter("use_text_tags", "1"); }
            if (request.HideTextTags) { content.AddParameter("hide_text_tags", "1"); }

            content.AddMetadata(request.Metadata);

            content.AddFiles(request.Files);
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

        public static void AddTemplateDraft(this MultipartFormDataContent content, NewEmbeddedTemplateDraft draft)
        {
            content.AddEmbeddedRequest(draft);
            
            int i = 0;
            foreach (var role in draft.SignerRoles)
            {
                content.AddParameter($"signer_roles[{i}][name]", role.Name);
                content.AddParameter($"signer_roles[{i}][order]", role.Order?.ToString());
            }
            i = 0;
            foreach (var role in draft.CcRoles)
            {
                content.AddParameter($"cc_roles[{i}]", role);
            }

            content.AddParameter("merge_fields", JsonConvert.SerializeObject(draft.MergeFields, HttpResponseExtensions.JsonSettings));

            if (draft.UsePreexistingFields) { content.AddParameter("use_preexisting_fields", "1"); }
        }

        public static void AddUnclaimedDraft(this MultipartFormDataContent content, NewUnclaimedDraft draft)
        {
            content.AddRequestBase(draft);

            content.AddParameter("type", draft.Type);
            if (draft.UsePreexistingFields) { content.AddParameter("use_preexisting_fields", "1"); }
        }

        public static void AddEmbeddedUnclaimedDraft(this MultipartFormDataContent content, NewEmbeddedUnclaimedDraft draft)
        {
            content.AddUnclaimedDraft(draft);

            content.AddParameter("client_id", draft.ClientId);
            content.AddParameter("requester_email_address", draft.RequesterEmailAddress);
            content.AddParameter("signing_redirect_url", draft.SigningRedirectUrl);
            if (draft.IsForEmbeddedSigning) { content.AddParameter("is_for_embedded_signing", "1"); }
        }

        public static void AddApiApp(this MultipartFormDataContent content, NewApiApp app)
        {
            content.AddParameter("name", app.Name);
            content.AddParameter("domain", app.Domain);
            content.AddParameter("callback_url", app.CallbackUrl);
            content.AddParameter("custom_logo_file", app.CustomLogoFile);
            content.AddParameter("oauth[callback_url]", app.OAuthCallbackUrl);
            content.AddParameter("oauth[scopes]", app.OAuthScopes);
            content.AddParameter("white_labeling_options", app.WhiteLabelingOptions);
        }
    }
}
