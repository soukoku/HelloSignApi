using DropboxSignApi.Internal;
using DropboxSignApi.Requests;
using DropboxSignApi.Responses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DropboxSignApi
{
    // this contains template api methods

    partial class DropboxSignClient
    {
        const string TemplateUrl = "https://api.hellosign.com/v3/template";

        /// <summary>
        /// Returns the Template specified by the id.
        /// </summary>
        /// <param name="templateId">The id of the Template to retrieve.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<TemplateResponse> GetTemplateAsync(string templateId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            return GetAsync<TemplateResponse>($"{TemplateUrl}/{templateId}", cancellationToken);
        }

        /// <summary>
        /// Returns a list of the Templates that are accessible by you.
        /// </summary>
        /// <param name="accountId">Which account to return Templates for. Must be a team member. Use "all" to indicate all team members. Defaults to your account.</param>
        /// <param name="page">Which page number of the Template List to return. Defaults to 1.</param>
        /// <param name="pageSize">Number of objects to be returned per page. Must be between 1 and 100. Default is 20.</param>
        /// <param name="query">String that includes search terms and/or fields to be used to filter the Template objects. 
        /// You can use <see cref="ListQueyBuilder"/> to generate it.</param>
        /// <returns></returns>
        public Task<TemplateListResponse> GetTemplateListAsync(string accountId = null, int page = 1, int pageSize = 20, string query = null,
            CancellationToken cancellationToken = default)
        {
            page = Math.Max(1, page);
            pageSize = Math.Min(100, Math.Max(1, pageSize));

            return GetAsync<TemplateListResponse>($"{TemplateUrl}/list?account_id={accountId}&page={page}&page_size={pageSize}&query={query}", cancellationToken);
        }

        /// <summary>
        /// Gives the specified Account access to the specified Template. The specified Account must be a part of your Team.
        /// </summary>
        /// <param name="templateId">The id of the Template to give the Account access to.</param>
        /// <param name="accountId">The account id. Exclusive with emailAddress parameter.</param>
        /// <param name="emailAddress">The email address. Exclusive with accountId parameter.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<TemplateResponse> AddTemplateUserAsync(string templateId, string accountId, string emailAddress,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var request = new
            {
                accountId,
                emailAddress
            };

            return PostAsync<TemplateResponse>($"{TemplateUrl}/add_user/{templateId}", request.ToJsonContent(), cancellationToken);
        }

        /// <summary>
        /// Removes the specified Account's access to the specified Template.
        /// </summary>
        /// <param name="templateId">The id of the Template to remove the Account's access to.</param>
        /// <param name="accountId">The account id. Exclusive with emailAddress parameter.</param>
        /// <param name="emailAddress">The email address. Exclusive with accountId parameter.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<TemplateResponse> RemoveTemplateUserAsync(string templateId, string accountId, string emailAddress,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var request = new
            {
                accountId,
                emailAddress
            };

            return PostAsync<TemplateResponse>($"{TemplateUrl}/remove_user/{templateId}", request.ToJsonContent(), cancellationToken);
        }

        /// <summary>
        /// The first step in an embedded template workflow. Creates a draft template that can then be further set up in the template 'edit' stage.
        /// </summary>
        /// <param name="draft">The draft.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">request</exception>
        public Task<NewTemplateResponse> CreateEmbeddedTemplateDraftAsync(NewEmbeddedTemplateDraft draft,
            CancellationToken cancellationToken = default)
        {
            if (draft == null) { throw new ArgumentNullException(nameof(draft)); }

            return PostAsync<NewTemplateResponse>($"{TemplateUrl}/create_embedded_draft", new ApiMultipartContent(draft, _log), cancellationToken);
        }

        /// <summary>
        /// Completely deletes the template specified from the account.
        /// </summary>
        /// <param name="templateId">The id of the Template to delete.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<ApiResponse> DeleteTemplateAsync(string templateId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            return PostAsync<ApiResponse>($"{TemplateUrl}/delete/{templateId}", null, cancellationToken);
        }

        /// <summary>
        /// Obtain a copy of the original files specified by the template id parameter.
        /// </summary>
        /// <param name="templateId">The id of the template files to retrieve.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public async Task<DownloadInfoResponse> GetTemplateFileUrlAsync(string templateId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var url = $"{TemplateUrl}/files/{templateId}?get_url=1";
            _log.Requesting("GET", url);
            var resp = await _client.GetAsync(url, cancellationToken).ConfigureAwait(false);

            var dir = new DownloadInfoResponse();
            dir.FillExtraValues(resp);

            var json = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);

            var model = JsonConvert.DeserializeObject<DownloadInfo>(json, JsonExtensions.JsonSettings);
            dir.DownloadInfo = model;
            return dir;
        }

        /// <summary>
        /// Obtain a copy of the original files specified by the template id parameter.
        /// </summary>
        /// <param name="templateId">The id of the template files to retrieve.</param>
        /// <param name="fileType">Set to <see cref="FileType.Pdf" /> for a single merged document or
        /// <see cref="FileType.Zip" /> for a collection of individual documents.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public async Task<DownloadDataResponse> GetTemplateFilesAsync(string templateId, FileType fileType,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var ft = fileType == FileType.Zip ? "zip" : "pdf";

            var url = $"{TemplateUrl}/files/{templateId}?file_type={ft}";
            _log.Requesting("GET", url);
            var resp = await _client.GetAsync(url, cancellationToken).ConfigureAwait(false);

            var apiR = new DownloadDataResponse();
            apiR.FillExtraValues(resp);
            apiR.FileResponse = resp;
            return apiR;
        }

    }
}
