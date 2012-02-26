using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Hammock;
using Hammock.Authentication.OAuth;
using Hammock.Web;
using System.Compat.Web;
using GeeklistSharp.Model;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Diagnostics;

namespace GeeklistSharp.Service
{
    public partial class GeeklistService
    {
        public OAuthRequestToken GetRequestToken()
        {
            var request = api.CreateAuthenticatedRequest("/oauth/request_token", OAuthType.RequestToken);

            var response = api.Request(request);

            OAuthRequestToken oauth = CreateOAuthRequestTokenFromResponse(response);
            return oauth;
        }

        //public void GetRequestTokenAsync(Action<Hammock.RestResponse> callback)
        //{
        //    var request = api.CreateAuthenticatedRequest("/oauth/request_token", OAuthType.RequestToken);
        //    api.GetResultsAsync<Hammock.RestResponse>(callback, request);
        //}

        public static OAuthRequestToken CreateOAuthRequestTokenFromResponse(Hammock.RestResponse response)
        {
            NameValueCollection query = HttpUtility.ParseQueryString(response.Content);

            OAuthRequestToken oauth = new OAuthRequestToken
            {
                Token = query["oauth_token"] ?? "?",
                TokenSecret = query["oauth_token_secret"] ?? "?"
            };

            return oauth;
        }

        public OAuthAccessToken GetAccessToken(OAuthRequestToken requestToken, string verifyer)
        {
            var request = CreateAccessTokenRequest(verifyer);

            var response = api.Request(request);

            var query = HttpUtility.ParseQueryString(response.Content);
            var oauth = new OAuthAccessToken
            {
                Token = query["oauth_token"] ?? "?",
                TokenSecret = query["oauth_token_secret"] ?? "?"
            };

            return oauth;
        }

        public void GetAccessTokenAsync(Action<OAuthAccessToken> callback, OAuthRequestToken requestToken, string verifyer)
        {
            var request = CreateAccessTokenRequest(verifyer);
            api.GetResultsAsync<OAuthAccessToken>(callback, request);
        }

        public Uri GetAuthorizationUrl(string token)
        {
            return new Uri("http://sandbox.geekli.st/oauth/authorize?oauth_token=" + token);
        }

        private RestRequest CreateAccessTokenRequest(string verifyer)
        {
            var request = api.CreateAuthenticatedRequest("/oauth/access_token", OAuthType.AccessToken);
            var cred = request.Credentials as OAuthCredentials;
            if (cred != null)
            {
                cred.Verifier = verifyer;
            }
            return request;
        }

        public void AuthenticateWith(string token, string tokenSecret)
        {
            api.Token = token;
            api.TokenSecret = tokenSecret;
        }
    }
}
