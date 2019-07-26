using HelloSignApi.Responses;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HelloSignApi
{
    // this contains account api methods

    partial class HelloSignClient
    {
        const string AccountUrl = "https://api.hellosign.com/v3/account";

        /// <summary>
        /// Returns the properties and settings of your account.
        /// </summary>
        /// <returns></returns>
        public Task<AccountResponse> GetAccountAsync()
        {
            return GetAsync<AccountResponse>(AccountUrl);
        }

        /// <summary>
        /// Updates the properties and settings of your Account.
        /// </summary>
        /// <param name="callbackUrl">The URL that HelloSign should POST events to.</param>
        /// <returns></returns>
        public Task<AccountResponse> UpdateAccountAsync(string callbackUrl)
        {
            MultipartFormDataContent content = null;

            if (!string.IsNullOrEmpty(callbackUrl))
            {
                content = new MultipartFormDataContent();
                content.AddParameter(_log, "callback_url", callbackUrl);
            }

            return PostAsync<AccountResponse>(AccountUrl, content);
        }

        /// <summary>
        /// Creates a new HelloSign Account that is associated with the specified email_address.
        /// </summary>
        /// <param name="emailAddress">The email address to create a new account for.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Email address is required.</exception>
        public Task<AccountResponse> CreateAccountAsync(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress)) { throw new ArgumentException("Email address is required."); }

            var content = new MultipartFormDataContent();
            content.AddParameter(_log, "email_address", emailAddress);

            return PostAsync<AccountResponse>($"{AccountUrl}/create", content);
        }

        /// <summary>
        /// Verifies whether an HelloSign Account exists for the given email address.
        /// This method is restricted to paid API users.
        /// </summary>
        /// <param name="emailAddress">Email address to run the verification for.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Email address is required.</exception>
        public Task<AccountResponse> VerifyAccountAsync(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress)) { throw new ArgumentException("Email address is required."); }

            var content = new MultipartFormDataContent();
            content.AddParameter(_log, "email_address", emailAddress);

            return PostAsync<AccountResponse>($"{AccountUrl}/verify", content);
        }
    }
}
