using HelloSignApi.Requests;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace HelloSignApi
{
    static class HttpContentExtensions
    {
        public static void AddParameter(this MultipartFormDataContent content, IApiLog log, string name, string value, string fileName = null)
        {
            // empty string is still passed
            if (value != null)
            {
                log.ParameterAdded(name, value);
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

        static void AddMetadata(this MultipartFormDataContent content, IApiLog log, IDictionary<string, string> metadata)
        {
            foreach (var kv in metadata)
            {
                content.AddParameter(log, $"metadata[{kv.Key}]", kv.Value);
            }
        }

        static void AddSigners(this MultipartFormDataContent content, IApiLog log, IList<Signer> signers)
        {
            int i = 0;
            foreach (var signer in signers)
            {
                if (signer.Role == null)
                {
                    content.AddParameter(log, $"signers[{i}][name]", signer.Name ?? signer.Email);
                    content.AddParameter(log, $"signers[{i}][email_address]", signer.Email);
                    if (signer.Order.HasValue)
                    {
                        content.AddParameter(log, $"signers[{i}][order]", signer.Order.ToString());
                    }
                    content.AddParameter(log, $"signers[{i}][pin]", signer.Pin);
                }
                else
                {
                    content.AddParameter(log, $"signers[{signer.Role}][name]", signer.Name ?? signer.Email);
                    content.AddParameter(log, $"signers[{signer.Role}][email_address]", signer.Email);
                    content.AddParameter(log, $"signers[{signer.Role}][pin]", signer.Pin);
                }
                i++;
            }
        }

        static void AddAttachments(this MultipartFormDataContent content, IApiLog log, IList<NewAttachment> attachments)
        {
            int i = 0;
            foreach (var att in attachments)
            {
                content.AddParameter(log, $"attachments[{i}][name]", att.Name);
                content.AddParameter(log, $"attachments[{i}][instructions]", att.Instructions);
                content.AddParameter(log, $"attachments[{i}][signer_index]", att.SignerIndex.ToString());
                content.AddParameter(log, $"attachments[{i}][required]", att.Required ? "1" : "0");
                i++;
            }
        }

        static void AddFiles(this MultipartFormDataContent content, IApiLog log, IList<PendingFile> files)
        {
            try
            {
                int i = 0;
                foreach (var file in files)
                {
                    if (file.RemotePath != null)
                    {
                        content.AddParameter(log, $"file_url[{i}]", file.RemotePath.ToString());
                    }
                    else if (file.LocalPath != null)
                    {
                        var fc = new StreamContent(File.Open(file.LocalPath, FileMode.Open, FileAccess.Read, FileShare.Read));
                        fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                        content.Add(fc, $"file[{i}]", file.FileName);
                    }
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

        static void AddRequestBase(this MultipartFormDataContent content, IApiLog log, NewRequestBase request)
        {
            if (request.TestMode) { content.AddParameter(log, "test_mode", "1"); }
            if (request.AllowDecline) { content.AddParameter(log, "allow_decline", "1"); }

            content.AddParameter(log, "subject", request.Subject);
            content.AddParameter(log, "message", request.Message);
            content.AddParameter(log, "signing_redirect_url", request.SigningRedirectUrl);
            content.AddSigners(log, request.Signers);
            content.AddMetadata(log, request.Metadata);
            content.AddAttachments(log, request.Attachments);
        }

        public static void AddRequest(this MultipartFormDataContent content, IApiLog log, NewSignatureRequest request)
        {
            content.AddRequestBase(log, request);

            content.AddParameter(log, "client_id", request.ClientId);
            content.AddFiles(log, request.Files);
            content.AddParameter(log, "title", request.Title);


            int i = 0;
            foreach (var cc in request.CcEmailAddresses)
            {
                content.AddParameter(log, $"cc_email_addresses[{i++}]", cc);
            }

            if (request.UseTextTags) { content.AddParameter(log, "use_text_tags", "1"); }
            if (request.HideTextTags) { content.AddParameter(log, "hide_text_tags", "1"); }
            if (request.FormFieldsPerDocument.Count > 0)
            {
                content.AddParameter(log, "form_fields_per_document", JsonConvert.SerializeObject(request.FormFieldsPerDocument, HttpResponseExtensions.JsonSettings));
            }

        }

        public static void AddTemplatedRequest(this MultipartFormDataContent content, IApiLog log, NewTemplatedSignatureRequest request)
        {
            content.AddRequestBase(log, request);

            content.AddParameter(log, "client_id", request.ClientId);
            int i = 0;
            foreach (var tid in request.TemplateIds)
            {
                content.AddParameter(log, $"template_ids[{i++}]", tid);
            }
            content.AddParameter(log, "title", request.Title);
            foreach (var cc in request.Ccs)
            {
                content.AddParameter(log, $"ccs[{cc.Role}][email_address]", cc.Email);
            }
            if (request.CustomFields.Count > 0)
            {
                content.AddParameter(log, "custom_fields", JsonConvert.SerializeObject(request.CustomFields, HttpResponseExtensions.JsonSettings));
            }
        }

        public static void AddTemplateDraft(this MultipartFormDataContent content, IApiLog log, NewEmbeddedTemplateDraft draft)
        {
            if (draft.TestMode) { content.AddParameter(log, "test_mode", "1"); }

            content.AddFiles(log, draft.Files);
            content.AddAttachments(log, draft.Attachments);

            content.AddParameter(log, "title", draft.Title);
            content.AddParameter(log, "subject", draft.Subject);
            content.AddParameter(log, "message", draft.Message);

            int i = 0;
            foreach (var role in draft.SignerRoles)
            {
                content.AddParameter(log, $"signer_roles[{i}][name]", role.Name);
                content.AddParameter(log, $"signer_roles[{i}][order]", role.Order?.ToString());
            }
            i = 0;
            foreach (var role in draft.CcRoles)
            {
                content.AddParameter(log, $"cc_roles[{i}]", role);
            }

            if (draft.MergeFields.Count > 0)
            {
                content.AddParameter(log, "merge_fields", JsonConvert.SerializeObject(draft.MergeFields, HttpResponseExtensions.JsonSettings));
            }
            if (draft.UsePreexistingFields) { content.AddParameter(log, "use_preexisting_fields", "1"); }
            content.AddMetadata(log, draft.Metadata);
            content.AddParameter(log, "client_id", draft.ClientId);
        }

        public static void AddUnclaimedDraft(this MultipartFormDataContent content, IApiLog log, NewUnclaimedDraft draft)
        {
            content.AddRequestBase(log, draft);

            content.AddFiles(log, draft.Files);
            content.AddParameter(log, "type", draft.Type);
            if (draft.UsePreexistingFields) { content.AddParameter(log, "use_preexisting_fields", "1"); }

            int i = 0;
            foreach (var cc in draft.CcEmailAddresses)
            {
                content.AddParameter(log, $"cc_email_addresses[{i++}]", cc);
            }

            if (draft.UseTextTags) { content.AddParameter(log, "use_text_tags", "1"); }
            if (draft.HideTextTags) { content.AddParameter(log, "hide_text_tags", "1"); }
            if (draft.FormFieldsPerDocument.Count > 0)
            {
                content.AddParameter(log, "form_fields_per_document", JsonConvert.SerializeObject(draft.FormFieldsPerDocument, HttpResponseExtensions.JsonSettings));
            }

        }

        public static void AddEmbeddedUnclaimedDraft(this MultipartFormDataContent content, IApiLog log, NewEmbeddedUnclaimedDraft draft)
        {
            content.AddUnclaimedDraft(log, draft);

            content.AddParameter(log, "client_id", draft.ClientId);
            content.AddParameter(log, "requester_email_address", draft.RequesterEmailAddress);
            if (draft.IsForEmbeddedSigning) { content.AddParameter(log, "is_for_embedded_signing", "1"); }
        }

        public static void AddTemplatedEmbeddedUnclaimedDraft(this MultipartFormDataContent content, IApiLog log, NewTemplatedEmbeddedUnclaimedDraft draft)
        {
            content.AddRequestBase(log, draft);

            content.AddParameter(log, "client_id", draft.ClientId);
            int i = 0;
            foreach (var tid in draft.TemplateIds)
            {
                content.AddParameter(log, $"template_ids[{i++}]", tid);
            }
            content.AddParameter(log, "title", draft.Title);
            content.AddParameter(log, "requesting_redirect_url", draft.RequestingRedirectUrl);
            foreach (var cc in draft.Ccs)
            {
                content.AddParameter(log, $"ccs[{cc.Role}][email_address]", cc.Email);
            }
            if (draft.CustomFields.Count > 0)
            {
                content.AddParameter(log, "custom_fields", JsonConvert.SerializeObject(draft.CustomFields, HttpResponseExtensions.JsonSettings));
            }
            if (draft.IsForEmbeddedSigning) { content.AddParameter(log, "is_for_embedded_signing", "1"); }
        }

        public static void AddApiApp(this MultipartFormDataContent content, IApiLog log, NewApiApp app)
        {
            content.AddParameter(log, "name", app.Name);
            content.AddParameter(log, "domain", app.Domain);
            content.AddParameter(log, "callback_url", app.CallbackUrl);
            content.AddParameter(log, "custom_logo_file", app.CustomLogoFile);
            content.AddParameter(log, "oauth[callback_url]", app.OAuthCallbackUrl);
            content.AddParameter(log, "oauth[scopes]", app.OAuthScopes);
            content.AddParameter(log, "white_labeling_options", app.WhiteLabelingOptions);
        }
    }
}
