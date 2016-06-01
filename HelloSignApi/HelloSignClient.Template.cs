using HelloSignApi.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloSignApi
{
    // this contains template api methods

    partial class HelloSignClient
    {
        const string TemplateUrl = "https://api.hellosign.com/v3/template";

        /// <summary>
        /// Returns the Template specified by the id.
        /// </summary>
        /// <param name="templateId">The id of the Template to retrieve.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<TemplateResponse> GetTemplateAsync(string templateId)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var resp = _client.GetAsync($"{TemplateUrl}/{templateId}")
                .ContinueWith(t => t.Result.ParseApiResponseAsync<TemplateResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Returns a list of the Templates that are accessible by you.
        /// </summary>
        /// <param name="accountId">Which account to return Templates for. Must be a team member. Use "all" to indicate all team members. Defaults to your account.</param>
        /// <param name="page">Which page number of the Template List to return. Defaults to 1.</param>
        /// <param name="pageSize">Number of objects to be returned per page. Must be between 1 and 100. Default is 20.</param>
        /// <param name="query">String that includes search terms and/or fields to be used to filter the Template objects.</param>
        /// <returns></returns>
        public Task<TemplateListResponse> GetTemplateListAsync(string accountId = null, int page = 1, int pageSize = 20, string query = null)
        {
            page = Math.Max(1, page);
            pageSize = Math.Min(100, Math.Max(1, pageSize));

            var resp = _client.GetAsync($"{TemplateUrl}/list?account_id={accountId}&page={page}&page_size={pageSize}&query={query}")
                 .ContinueWith(t => t.Result.ParseApiResponseAsync<TemplateListResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Gives the specified Account access to the specified Template. The specified Account must be a part of your Team.
        /// </summary>
        /// <param name="templateId">The id of the Template to give the Account access to.</param>
        /// <param name="accountId">The account id. Exclusive with emailAddress parameter.</param>
        /// <param name="emailAddress">The email address. Exclusive with accountId parameter.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<TemplateResponse> AddTemplateUserAsync(string templateId, string accountId, string emailAddress)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var content = new MultipartFormDataContent();
            content.AddParameter("account_id", accountId);
            content.AddParameter("email_address", emailAddress);

            var resp = _client.PostAsync($"{TemplateUrl}/add_user/{templateId}", content)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<TemplateResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Removes the specified Account's access to the specified Template.
        /// </summary>
        /// <param name="templateId">The id of the Template to remove the Account's access to.</param>
        /// <param name="accountId">The account id. Exclusive with emailAddress parameter.</param>
        /// <param name="emailAddress">The email address. Exclusive with accountId parameter.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<TemplateResponse> RemoveTemplateUserAsync(string templateId, string accountId, string emailAddress)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var content = new MultipartFormDataContent();
            content.AddParameter("account_id", accountId);
            content.AddParameter("email_address", emailAddress);

            var resp = _client.PostAsync($"{TemplateUrl}/remove_user/{templateId}", content)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<TemplateResponse>());
            return resp.Unwrap();
        }


        /// <summary>
        /// The first step in an embedded template workflow. Creates a draft template that can then be further set up in the template 'edit' stage.
        /// </summary>
        /// <param name="draft">The draft.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">request</exception>
        public Task<TemplateResponse> CreateEmbeddedTemplateDraftAsync(NewEmbeddedTemplateDraft draft)
        {
            return CreateEmbeddedTemplateDraftAsync(draft, CancellationToken.None);
        }
        /// <summary>
        /// The first step in an embedded template workflow. Creates a draft template that can then be further set up in the template 'edit' stage.
        /// </summary>
        /// <param name="draft">The draft.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">request</exception>
        public Task<TemplateResponse> CreateEmbeddedTemplateDraftAsync(NewEmbeddedTemplateDraft draft, CancellationToken cancellationToken)
        {
            if (draft == null) { throw new ArgumentNullException("request"); }

            var content = new MultipartFormDataContent();
            content.AddTemplateDraft(draft);

            var resp = _client.PostAsync($"{TemplateUrl}/create_embedded_draft", content, cancellationToken)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<TemplateResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Completely deletes the template specified from the account.
        /// </summary>
        /// <param name="templateId">The id of the Template to delete.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<ApiResponse> DeleteTemplateAsync(string templateId)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var resp = _client.PostAsync($"{TemplateUrl}/delete/{templateId}", null)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<ApiResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Obtain a copy of the original files specified by the template id parameter.
        /// </summary>
        /// <param name="templateId">The id of the template files to retrieve.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<DownloadInfoResponse> GetTemplateFilesAsync(string templateId)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var resp = _client.GetAsync($"{TemplateUrl}/files/{templateId}?get_url=1")
                .ContinueWith(t =>
                {
                    var dir = new DownloadInfoResponse();
                    dir.FillExtraValues(t.Result);

                    return t.Result.Content.ReadAsStringAsync().ContinueWith(t2 =>
                    {
                        var json = t2.Result;

                        var model = JsonConvert.DeserializeObject<DownloadInfo>(json, HttpResponseExtensions.JsonSettings);
                        dir.DownloadInfo = model;
                        return dir;
                    });
                });
            return resp.Unwrap();
        }

        /// <summary>
        /// Obtain a copy of the original files specified by the template id parameter.
        /// </summary>
        /// <param name="templateId">The id of the template files to retrieve.</param>
        /// <param name="fileType">Set to <see cref="FileType.Pdf" /> for a single merged document or
        /// <see cref="FileType.Zip" /> for a collection of individual documents.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<HttpResponseMessage> GetTemplateFilesAsync(string templateId, FileType fileType)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var ft = fileType == FileType.Zip ? "zip" : "pdf";

            return _client.GetAsync($"{TemplateUrl}/files/{templateId}?file_type={ft}");
        }

    }
}
