//using DropboxSignApi.Internal;
//using DropboxSignApi.Requests;
//using Newtonsoft.Json;
//using System.Collections.Generic;
//using System.IO;
//using System.Net.Http;

//namespace DropboxSignApi
//{
//    static partial class HttpContentExtensions
//    {


//        static void AddSigners(this ApiMultipartContent content, IApiLog log, IList<Signer> signers)
//        {
//            int i = 0;
//            foreach (var signer in signers)
//            {
//                if (signer.Role == null)
//                {
//                    content.AddParameter($"signers[{i}][name]", signer.Name ?? signer.Email);
//                    content.AddParameter($"signers[{i}][email_address]", signer.Email);
//                    if (signer.Order.HasValue)
//                    {
//                        content.AddParameter($"signers[{i}][order]", signer.Order.ToString());
//                    }
//                    content.AddParameter($"signers[{i}][pin]", signer.Pin);
//                }
//                else
//                {
//                    content.AddParameter($"signers[{signer.Role}][name]", signer.Name ?? signer.Email);
//                    content.AddParameter($"signers[{signer.Role}][email_address]", signer.Email);
//                    content.AddParameter($"signers[{signer.Role}][pin]", signer.Pin);
//                }
//                i++;
//            }
//        }

//        static void AddFiles(this ApiMultipartContent content, IApiLog log, IList<PendingFile> files)
//        {
//            try
//            {
//                int i = 0;
//                foreach (var file in files)
//                {
//                    if (file.RemotePath != null)
//                    {
//                        content.AddParameter($"file_url[{i}]", file.RemotePath.ToString());
//                    }
//                    else if (file.LocalPath != null)
//                    {
//                        var fc = new StreamContent(File.Open(file.LocalPath, FileMode.Open, FileAccess.Read, FileShare.Read));
//                        fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
//                        content.Add(fc, $"file[{i}]", file.FileName);
//                    }
//                    else if (file.Data != null)
//                    {
//                        var fc = new ByteArrayContent(file.Data);
//                        fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
//                        content.Add(fc, $"file[{i}]", file.FileName);
//                    }
//                    else if (file.Stream != null)
//                    {
//                        var fc = new StreamContent(file.Stream);
//                        fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
//                        content.Add(fc, $"file[{i}]", file.FileName);
//                    }
//                    i++;
//                }
//            }
//            catch
//            {
//                content.Dispose();
//                throw;
//            }
//        }

//        static void AddRequestBase(this ApiMultipartContent content, IApiLog log, NewRequestBase request)
//        {
//            if (request.TestMode) { content.AddParameter("test_mode", "1"); }
//            if (request.AllowDecline) { content.AddParameter("allow_decline", "1"); }

//            content.AddParameter("subject", request.Subject);
//            content.AddParameter("message", request.Message);
//            content.AddParameter("signing_redirect_url", request.SigningRedirectUrl);
//            content.AddSigners(log, request.Signers);
//            content.AddMetadata(request.Metadata);
//            content.AddAttachments(request.Attachments);
//        }

//        public static void AddRequest(this ApiMultipartContent content, IApiLog log, NewSignatureRequest request)
//        {
//            content.AddRequestBase(log, request);

//            content.AddParameter("client_id", request.ClientId);
//            content.AddFiles(log, request.Files);
//            content.AddParameter("title", request.Title);


//            int i = 0;
//            foreach (var cc in request.CcEmailAddresses)
//            {
//                content.AddParameter($"cc_email_addresses[{i++}]", cc);
//            }

//            if (request.UseTextTags) { content.AddParameter("use_text_tags", "1"); }
//            if (request.HideTextTags) { content.AddParameter("hide_text_tags", "1"); }
//            if (request.FormFieldsPerDocument.Count > 0)
//            {
//                content.AddParameter("form_fields_per_document", JsonConvert.SerializeObject(request.FormFieldsPerDocument, JsonExtensions.JsonSettings));
//            }

//        }

//        public static void AddTemplatedRequest(this ApiMultipartContent content, IApiLog log, NewTemplatedSignatureRequest request)
//        {
//            content.AddRequestBase(log, request);

//            content.AddParameter("client_id", request.ClientId);
//            int i = 0;
//            foreach (var tid in request.TemplateIds)
//            {
//                content.AddParameter($"template_ids[{i++}]", tid);
//            }
//            content.AddParameter("title", request.Title);
//            foreach (var cc in request.Ccs)
//            {
//                content.AddParameter($"ccs[{cc.Role}][email_address]", cc.Email);
//            }
//            if (request.CustomFields.Count > 0)
//            {
//                content.AddParameter("custom_fields", JsonConvert.SerializeObject(request.CustomFields, JsonExtensions.JsonSettings));
//            }
//        }

//        public static void AddTemplateDraft(this ApiMultipartContent content, IApiLog log, NewEmbeddedTemplateDraft draft)
//        {
//            if (draft.TestMode) { content.AddParameter("test_mode", "1"); }

//            content.AddFiles(log, draft.Files);
//            content.AddAttachments(draft.Attachments);

//            content.AddParameter("title", draft.Title);
//            content.AddParameter("subject", draft.Subject);
//            content.AddParameter("message", draft.Message);

//            int i = 0;
//            foreach (var role in draft.SignerRoles)
//            {
//                content.AddParameter($"signer_roles[{i}][name]", role.Name);
//                content.AddParameter($"signer_roles[{i}][order]", role.Order?.ToString());
//            }
//            i = 0;
//            foreach (var role in draft.CcRoles)
//            {
//                content.AddParameter($"cc_roles[{i}]", role);
//            }

//            if (draft.MergeFields.Count > 0)
//            {
//                content.AddParameter("merge_fields", JsonConvert.SerializeObject(draft.MergeFields, JsonExtensions.JsonSettings));
//            }
//            if (draft.UsePreexistingFields) { content.AddParameter("use_preexisting_fields", "1"); }
//            content.AddMetadata(draft.Metadata);
//            content.AddParameter("client_id", draft.ClientId);
//        }



//        public static void AddEmbeddedUnclaimedDraft(this ApiMultipartContent content, IApiLog log, NewEmbeddedUnclaimedDraftRequest draft)
//        {
//            content.AddDraftBase(log, draft);

//            content.AddParameter("client_id", draft.ClientId);
//            content.AddParameter("requester_email_address", draft.RequesterEmailAddress);
//            if (draft.IsForEmbeddedSigning) { content.AddParameter("is_for_embedded_signing", "1"); }
//        }

//        public static void AddTemplatedEmbeddedUnclaimedDraft(this ApiMultipartContent content, IApiLog log, NewTemplatedEmbeddedUnclaimedDraftRequest draft)
//        {
//            content.AddDraftBase(log, draft);

//            content.AddParameter("client_id", draft.ClientId);
//            int i = 0;
//            foreach (var tid in draft.TemplateIds)
//            {
//                content.AddParameter($"template_ids[{i++}]", tid);
//            }
//            content.AddParameter("title", draft.Title);
//            content.AddParameter("requesting_redirect_url", draft.RequestingRedirectUrl);
//            foreach (var cc in draft.CCs)
//            {
//                content.AddParameter($"ccs[{cc.Role}][email_address]", cc.EmailAddress);
//            }
//            if (draft.CustomFields.Count > 0)
//            {
//                content.AddParameter("custom_fields", JsonConvert.SerializeObject(draft.CustomFields, JsonExtensions.JsonSettings));
//            }
//            if (draft.IsForEmbeddedSigning) { content.AddParameter("is_for_embedded_signing", "1"); }
//        }

//        public static void AddUnclaimedDraft(this ApiMultipartContent content, IApiLog log, NewUnclaimedDraftRequest draft)
//        {
//            content.AddDraftBase(log, draft);

//            content.AddFiles(log, draft.Files);
//            content.AddParameter("type", draft.Type);
//            if (draft.UsePreexistingFields) { content.AddParameter("use_preexisting_fields", "1"); }

//            int i = 0;
//            foreach (var cc in draft.CcEmailAddresses)
//            {
//                content.AddParameter($"cc_email_addresses[{i++}]", cc);
//            }

//            if (draft.UseTextTags) { content.AddParameter("use_text_tags", "1"); }
//            if (draft.HideTextTags) { content.AddParameter("hide_text_tags", "1"); }
//            if (draft.FormFieldsPerDocument.Count > 0)
//            {
//                content.AddParameter("form_fields_per_document", JsonConvert.SerializeObject(draft.FormFieldsPerDocument, JsonExtensions.JsonSettings));
//            }

//        }

//        static void AddDraftBase(this ApiMultipartContent content, IApiLog log, NewUnclaimedDraftBase draft)
//        {

//        }
//        //public static void AddApiApp(this ApiMultipartContent content, IApiLog log, ApiAppRequest app)
//        //{
//        //    content.AddParameter("name", app.Name);
//        //    content.AddParameter("domain", app.Domain);
//        //    content.AddParameter("callback_url", app.CallbackUrl);
//        //    content.AddParameter("custom_logo_file", app.CustomLogoFile);
//        //    content.AddParameter("oauth[callback_url]", app.OAuthCallbackUrl);
//        //    content.AddParameter("oauth[scopes]", app.OAuthScopes);
//        //    content.AddParameter("white_labeling_options", app.WhiteLabelingOptions);
//        //}
//    }
//}
