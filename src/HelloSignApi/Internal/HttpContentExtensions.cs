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
                if (signer.Role == null)
                {
                    content.AddParameter($"signers[{i}][name]", signer.Name ?? signer.Email);
                    content.AddParameter($"signers[{i}][email_address]", signer.Email);
                    if (signer.Order.HasValue)
                    {
                        content.AddParameter($"signers[{i}][order]", signer.Order.ToString());
                    }
                    content.AddParameter($"signers[{i}][pin]", signer.Pin);
                }
                else
                {
                    content.AddParameter($"signers[{signer.Role}][name]", signer.Name ?? signer.Email);
                    content.AddParameter($"signers[{signer.Role}][email_address]", signer.Email);
                    content.AddParameter($"signers[{signer.Role}][pin]", signer.Pin);
                }
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
#if !PORTABLE
                    else if (file.LocalPath != null)
                    {
                        var fc = new StreamContent(File.Open(file.LocalPath, FileMode.Open, FileAccess.Read, FileShare.Read));
                        fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                        content.Add(fc, $"file[{i}]", file.FileName);
                    }
#endif
                    else if (file.Data != null)
                    {
                        var fc = new ByteArrayContent(file.Data);
                        fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                        content.Add(fc, $"file[{i}]", file.FileName);
                    }
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
            content.AddParameter("signing_redirect_url", request.SigningRedirectUrl);
            content.AddSigners(request.Signers);
            content.AddMetadata(request.Metadata);
        }

        public static void AddRequest(this MultipartFormDataContent content, NewSignatureRequest request)
        {
            content.AddRequestBase(request);

            content.AddParameter("client_id", request.ClientId);
            content.AddFiles(request.Files);
            content.AddParameter("title", request.Title);

            int i = 0;
            foreach (var cc in request.CcEmailAddresses)
            {
                content.AddParameter($"cc_email_addresses[{i++}]", cc);
            }

            if (request.UseTextTags) { content.AddParameter("use_text_tags", "1"); }
            if (request.HideTextTags) { content.AddParameter("hide_text_tags", "1"); }
            if (request.FormFieldsPerDocument.Count > 0)
            {
                content.AddParameter("form_fields_per_document", JsonConvert.SerializeObject(request.FormFieldsPerDocument, HttpResponseExtensions.JsonSettings));
            }

        }

        public static void AddTemplatedRequest(this MultipartFormDataContent content, NewTemplatedSignatureRequest request)
        {
            content.AddRequestBase(request);

            content.AddParameter("client_id", request.ClientId);
            int i = 0;
            foreach (var tid in request.TemplateIds)
            {
                content.AddParameter($"template_ids[{i++}]", tid);
            }
            content.AddParameter("title", request.Title);
            foreach (var cc in request.Ccs)
            {
                content.AddParameter($"ccs[{cc.Role}]", cc.Email);
            }
            content.AddParameter("custom_fields", JsonConvert.SerializeObject(request.CustomFields, HttpResponseExtensions.JsonSettings));
        }

        public static void AddTemplateDraft(this MultipartFormDataContent content, NewEmbeddedTemplateDraft draft)
        {
            if (draft.TestMode) { content.AddParameter("test_mode", "1"); }

            content.AddFiles(draft.Files);
            content.AddParameter("title", draft.Title);
            content.AddParameter("subject", draft.Subject);
            content.AddParameter("message", draft.Message);

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
            content.AddMetadata(draft.Metadata);
            content.AddParameter("client_id", draft.ClientId);
        }

        public static void AddUnclaimedDraft(this MultipartFormDataContent content, NewUnclaimedDraft draft)
        {
            content.AddRequestBase(draft);

            content.AddFiles(draft.Files);
            content.AddParameter("type", draft.Type);
            if (draft.UsePreexistingFields) { content.AddParameter("use_preexisting_fields", "1"); }

            int i = 0;
            foreach (var cc in draft.CcEmailAddresses)
            {
                content.AddParameter($"cc_email_addresses[{i++}]", cc);
            }

            if (draft.UseTextTags) { content.AddParameter("use_text_tags", "1"); }
            if (draft.HideTextTags) { content.AddParameter("hide_text_tags", "1"); }
            if (draft.FormFieldsPerDocument.Count > 0)
            {
                content.AddParameter("form_fields_per_document", JsonConvert.SerializeObject(draft.FormFieldsPerDocument, HttpResponseExtensions.JsonSettings));
            }

        }

        public static void AddEmbeddedUnclaimedDraft(this MultipartFormDataContent content, NewEmbeddedUnclaimedDraft draft)
        {
            content.AddUnclaimedDraft(draft);

            content.AddParameter("client_id", draft.ClientId);
            content.AddParameter("requester_email_address", draft.RequesterEmailAddress);
            if (draft.IsForEmbeddedSigning) { content.AddParameter("is_for_embedded_signing", "1"); }
        }

        public static void AddTemplatedEmbeddedUnclaimedDraft(this MultipartFormDataContent content, NewTemplatedEmbeddedUnclaimedDraft draft)
        {
            content.AddRequestBase(draft);

            content.AddParameter("client_id", draft.ClientId);
            int i = 0;
            foreach (var tid in draft.TemplateIds)
            {
                content.AddParameter($"template_ids[{i++}]", tid);
            }
            content.AddParameter("title", draft.Title);
            content.AddParameter("requesting_redirect_url", draft.RequestingRedirectUrl);
            foreach (var cc in draft.Ccs)
            {
                content.AddParameter($"ccs[{cc.Role}]", cc.Email);
            }
            content.AddParameter("custom_fields", JsonConvert.SerializeObject(draft.CustomFields, HttpResponseExtensions.JsonSettings));
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
