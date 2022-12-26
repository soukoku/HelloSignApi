﻿using DropboxSignApi.Internal;
using DropboxSignApi.Requests;
using DropboxSignApi.Responses;
using DropboxSignApi.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DropboxSignApi
{
    // this contains account api methods

    partial class DropboxSignClient
    {
        const string AccountUrl = "https://api.hellosign.com/v3/account";

        /// <summary>
        /// Returns the properties and settings of your account.
        /// Either account_id or email_address is required. If both are provided, the account id prevails.
        /// </summary>
        /// <param name="accountId">The ID of the Account.</param>
        /// <param name="emailAddress">The email address of the Account.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AccountResponseWrap> GetAccountAsync(
            string accountId, string emailAddress,
            CancellationToken cancellationToken = default)
        {
            var url = AccountUrl;
            if (!string.IsNullOrEmpty(accountId))
            {
                url += $"?account_id={Uri.EscapeDataString(accountId)}";
            }
            else if (!string.IsNullOrEmpty(emailAddress))
            {
                url += $"?email_address={Uri.EscapeDataString(emailAddress)}";
            }
            return GetAsync<AccountResponseWrap>(url, cancellationToken);
        }

        /// <summary>
        /// Updates the properties and settings of your Account.
        /// Currently only allows for updates to the Callback URL and locale.
        /// </summary>
        /// <param name="request">Updated account info.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AccountResponseWrap> UpdateAccountAsync(UpdateAccountRequest request,
            CancellationToken cancellationToken = default)
        {
            return PutAsync<AccountResponseWrap>(AccountUrl, request.ToJsonContent(_log), cancellationToken);
        }

        /// <summary>
        /// Creates a new Dropbox Sign Account that is associated with the specified email_address.
        /// </summary>
        /// <param name="request">New account info.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AccountCreateResponseWrap> CreateAccountAsync(NewAccountRequest request,
            CancellationToken cancellationToken = default)
        {
            return PostAsync<AccountCreateResponseWrap>($"{AccountUrl}/create", request.ToJsonContent(_log), cancellationToken);
        }

        /// <summary>
        /// Verifies whether a Dropbox Account exists for the given email address.
        /// </summary>
        /// <param name="emailAddress">Email address to run the verification for.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AccountVerifyResponseWrap> VerifyAccountAsync(string emailAddress,
            CancellationToken cancellationToken = default)
        {
            return PostAsync<AccountVerifyResponseWrap>($"{AccountUrl}/verify", new { emailAddress }.ToJsonContent(_log), cancellationToken);
        }
    }
}
