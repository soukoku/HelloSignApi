using Soukoku.DropboxSignApi.Requests;
using Soukoku.DropboxSignApi.Responses;
using Soukoku.DropboxSignApi.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soukoku.DropboxSignApi
{
    // this contains template api methods

    partial class DropboxSignClient
    {
        const string TemplateUrl = "https://api.hellosign.com/v3/template";

        /// <summary>
        /// Returns the Template specified by the id.
        /// </summary>
        /// <param name="templateId">The id of the Template to retrieve.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<TemplateResponseWrap> GetTemplateAsync(string templateId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            return GetAsync<TemplateResponseWrap>($"{TemplateUrl}/{Uri.EscapeDataString(templateId)}", cancellationToken);
        }

        /// <summary>
        /// Returns a list of the Templates that are accessible by you.
        /// </summary>
        /// <param name="accountId">Which account to return Templates for. Must be a team member. 
        /// Use "all" to indicate all team members. Defaults to your account.</param>
        /// <param name="page">Which page number of the Template List to return. Defaults to 1.</param>
        /// <param name="pageSize">Number of objects to be returned per page. Must be between 1 and 100. Default is 20.</param>
        /// <param name="query">String that includes search terms and/or fields to be used to filter the Template objects. 
        /// You can use <see cref="ListQueyBuilder"/> to generate it.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TemplateListResponseWrap> GetTemplateListAsync(string accountId = null, int page = 1, int pageSize = 20, string query = null,
            CancellationToken cancellationToken = default)
        {
            page = Math.Max(1, page);
            pageSize = Math.Min(100, Math.Max(1, pageSize));

            return GetAsync<TemplateListResponseWrap>($"{TemplateUrl}/list?account_id={accountId}&page={page}&page_size={pageSize}&query={query}", cancellationToken);
        }

        /// <summary>
        /// The first step in an embedded template workflow. Creates a draft template that can then be further set up in the template 'edit' stage.
        /// </summary>
        /// <param name="draft">The draft.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">request</exception>
        public Task<NewTemplateResponse> CreateEmbeddedTemplateDraftAsync(CreateEmbeddedTemplateDraftRequest draft,
            CancellationToken cancellationToken = default)
        {
            if (draft == null) { throw new ArgumentNullException(nameof(draft)); }

            return PostAsync<NewTemplateResponse>($"{TemplateUrl}/create_embedded_draft", new ApiMultipartContent(draft, _log), cancellationToken);
        }

        /// <summary>
        /// Completely deletes the template specified from the account.
        /// </summary>
        /// <param name="templateId">The id of the Template to delete.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<ResponseWrap> DeleteTemplateAsync(string templateId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            return PostAsync<ResponseWrap>($"{TemplateUrl}/delete/{Uri.EscapeDataString(templateId)}", null, cancellationToken);
        }

        /// <summary>
        /// <para>Obtain a copy of the current documents specified by the templateId parameter. 
        /// Returns a PDF or ZIP file.</para>
        /// <para>If the files are currently being prepared, a status code of 409 will be returned instead. 
        /// In this case please wait for the template_created callback event.</para>
        /// </summary>
        /// <param name="templateId">The id of the template files to retrieve.</param>
        /// <param name="fileType">Set to <see cref="FileType.Pdf" /> for a single merged document or
        /// <see cref="FileType.Zip" /> for a collection of individual documents.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public async Task<FileDownloadResponseWrap> GetTemplateFilesAsync(string templateId, FileType fileType,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var ft = fileType == FileType.Zip ? "zip" : "pdf";

            var url = $"{TemplateUrl}/files/{Uri.EscapeDataString(templateId)}?file_type={ft}";
            _log.Requesting("GET", url);
            var resp = await _client.GetAsync(url, cancellationToken).ConfigureAwait(false);

            var apiR = new FileDownloadResponseWrap();
            apiR.FillExtraValues(resp);
            apiR.FileResponse = resp;
            return apiR;
        }


        /// <summary>
        /// <para>Obtain a copy of the current documents specified by the templateId parameter (PDFs only).</para>
        /// <para>If the files are currently being prepared, a status code of 409 will be returned instead. 
        /// In this case please wait for the template_created callback event.</para>
        /// </summary>
        /// <param name="templateId">The id of the template files to retrieve.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<FileDataUriResponseWrap> GetTemplateFileDataUriAsync(string templateId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var url = $"{TemplateUrl}/files_as_data_uri/{Uri.EscapeDataString(templateId)}";
            return GetAsync<FileDataUriResponseWrap>(url, cancellationToken);
        }

        /// <summary>
        /// <para>Obtain a copy of the current documents specified by the template_id parameter (PDFs only).</para>
        /// <para>If the files are currently being prepared, a status code of 409 will be returned instead. 
        /// In this case please wait for the template_created callback event.</para>
        /// </summary>
        /// <param name="templateId">The id of the template files to retrieve.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<FileUrlResponseWrap> GetTemplateFileUrlAsync(string templateId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var url = $"{TemplateUrl}/files_as_file_url/{Uri.EscapeDataString(templateId)}";
            return GetAsync<FileUrlResponseWrap>(url, cancellationToken);
        }

        /// <summary>
        /// Overlays a new file with the overlay of an existing template.
        /// </summary>
        /// <param name="templateId">The ID of the template whose files to update.</param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TemplateUpdateFilesResponseWrap> UpdateTemplateFilesAsync(string templateId,
            UpdateTemplateFileRequest request,
            CancellationToken cancellationToken = default)
        {
            var url = $"{TemplateUrl}/update_files/{Uri.EscapeDataString(templateId)}";

            return PostAsync<TemplateUpdateFilesResponseWrap>(url, new ApiMultipartContent(request, _log), cancellationToken);
        }

        /// <summary>
        /// Gives the specified Account access to the specified Template. The specified Account must be a part of your Team.
        /// </summary>
        /// <param name="templateId">The id of the Template to give the Account access to.</param>
        /// <param name="accountId">The account id. Exclusive with emailAddress parameter.</param>
        /// <param name="emailAddress">The email address. Exclusive with accountId parameter.</param>
        /// <param name="skipNotification">If set to true, the user does not receive an email notification when 
        /// a template has been shared with them. Defaults to false.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<TemplateResponseWrap> AddUserToTemplateAsync(string templateId,
            string accountId, string emailAddress, bool skipNotification = false,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var request = new
            {
                accountId,
                emailAddress,
                skipNotification
            };

            return PostAsync<TemplateResponseWrap>($"{TemplateUrl}/add_user/{Uri.EscapeDataString(templateId)}", request.ToJsonContent(_log), cancellationToken);
        }

        /// <summary>
        /// Removes the specified Account's access to the specified Template.
        /// </summary>
        /// <param name="templateId">The id of the Template to remove the Account's access to.</param>
        /// <param name="accountId">The account id. Exclusive with emailAddress parameter.</param>
        /// <param name="emailAddress">The email address. Exclusive with accountId parameter.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Template id is required.</exception>
        public Task<TemplateResponseWrap> RemoveUserFromTemplateAsync(string templateId,
            string accountId, string emailAddress,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(templateId)) { throw new ArgumentException("Template id is required."); }

            var request = new
            {
                accountId,
                emailAddress
            };

            return PostAsync<TemplateResponseWrap>($"{TemplateUrl}/remove_user/{Uri.EscapeDataString(templateId)}", request.ToJsonContent(_log), cancellationToken);
        }

    }
}
