using System.Diagnostics;
using IdentityModel.OidcClient.Browser;

namespace MauiOidc.Services
{
    internal class WebAuthenticatorBrowser : IdentityModel.OidcClient.Browser.IBrowser
    {
        private readonly string _callbackUrl;

        public WebAuthenticatorBrowser(string? callbackUrl = null)
        {
            _callbackUrl = callbackUrl ?? "";
        }

        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {
            try
            {
                var callbackUrl = string.IsNullOrEmpty(_callbackUrl) ? options.EndUrl : _callbackUrl;
                WebAuthenticatorResult authResult =
                     await WebAuthenticator.AuthenticateAsync(new Uri(options.StartUrl), new Uri(callbackUrl));

                    //await WebAuthenticator.AuthenticateAsync(new WebAuthenticatorOptions
                    //{
                    //    Url = new Uri(options.StartUrl),
                    //    CallbackUrl = new Uri(callbackUrl),
                    //    PrefersEphemeralWebBrowserSession = true
                    //});
                var authorizeResponse = ToRawIdentityUrl(options.EndUrl, authResult);

                return new BrowserResult
                {
                    Response = authorizeResponse
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new BrowserResult()
                {
                    ResultType = BrowserResultType.UnknownError,
                    Error = ex.ToString()
                };
            }
        }

        public string ToRawIdentityUrl(string redirectUrl, WebAuthenticatorResult result)
        {
            IEnumerable<string> parameters = result.Properties.Select(pair => $"{pair.Key}={pair.Value}");
            var values = string.Join("&", parameters);

            return $"{redirectUrl}#{values}";
        }
    }
}