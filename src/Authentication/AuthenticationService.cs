using System;
using System.Linq;

namespace InstagramWrapper.Authentication
{
    public class AuthenticationService
    {
        private const string ImplicitAuthorizationApi = "https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&scope={2}&response_type=token";

        public string ClientId { get; set; }
        public string RedirectUri { get; set; }
        public LoginPermissionScope[] LoginPermissionScopes { get; set; }

        private string PermissionScopeString
        {
            get
            {
                var result = LoginPermissionScope.basic.ToString();

                foreach (var loginPermissionScope in LoginPermissionScopes.Distinct().Where(p => p != LoginPermissionScope.basic))
                    result += "+" + Enum.GetName(typeof(LoginPermissionScope), loginPermissionScope);

                return result;
            }
        }

        public AuthenticationService(string clientId, string redirectUri, params LoginPermissionScope[] loginPermissionScopes)
        {
            ClientId = clientId;
            RedirectUri = redirectUri;
            LoginPermissionScopes = loginPermissionScopes;
        }

        public Uri AuthenticationApiUri()
        {
            return new Uri(string.Format(ImplicitAuthorizationApi, ClientId, RedirectUri, PermissionScopeString));
        }
        public bool IsRedirectedToMyRedirectUri(Uri redirectUri)
        {
            return redirectUri.AbsoluteUri.StartsWith(RedirectUri);
        }
        public string GetAccessTokenFromRedirectUri(Uri redirectUri)
        {
            var absoluteUri = redirectUri.AbsoluteUri;
            if (this.IsRedirectedToMyRedirectUri(redirectUri))
            {
                if (absoluteUri.Contains("#access_token="))
                    return absoluteUri.Replace(RedirectUri + "#access_token=", "").Trim();
                else if (absoluteUri.Contains(RedirectUri + "?error"))
                    throw new Exception("The user denied your request.");
                else
                    throw new Exception("Unknown error occurred in redirect uri.\n" + absoluteUri);
            }
            else
                throw new Exception("Redirect uri is not yours!\n" + absoluteUri);
        }
    }
}
