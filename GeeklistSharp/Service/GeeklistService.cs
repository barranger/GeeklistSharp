using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hammock;
using Hammock.Authentication.OAuth;
using Hammock.Web;
using System.Compat.Web;
using GeeklistSharp.Model;

namespace GeeklistSharp.Service
{
    public class GeeklistService
    {
        private static string _consumerKey;
        private static string _consumerSecret;
        private static string _callback;

        private static string _token;
        private static string _tokenSecret;

        private readonly RestClient _oauth;


        public GeeklistService(string consumerKey, string consumerSecret, string callback = "oob")
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _callback = callback;

            _oauth = new RestClient
                        {
                            Authority = Globals.RestAPIAuthority,
                            VersionPath = "v1",
                            UserAgent = "GeeklistSharp",
                        };
        }

        public OAuthRequestToken GetRequestToken()
        {

            var request = new RestRequest
            {
                Credentials = new OAuthCredentials
                {
                    ConsumerKey = _consumerKey,
                    ConsumerSecret = _consumerSecret,
                    SignatureMethod = OAuthSignatureMethod.HmacSha1,
                    CallbackUrl = _callback,
                    Type = OAuthType.RequestToken
                },
                Method = WebMethod.Get,
                Path = "/oauth/request_token"
            };

            var response = _oauth.Request(request);

            var query = HttpUtility.ParseQueryString(response.Content);
            var oauth = new OAuthRequestToken
            {
                Token = query["oauth_token"] ?? "?",
                TokenSecret = query["oauth_token_secret"] ?? "?"
            };

            return oauth;
        }



        public Uri GetAuthorizationUrl(string token)
        {
            return new Uri("http://sandbox.geekli.st/oauth/authorize?oauth_token=" + token);
        }

        public OAuthAccessToken GetAccessToken(OAuthRequestToken requestToken, string verifyer)
        {
            var request = new RestRequest
            {
                Credentials = new OAuthCredentials
                {
                    ConsumerKey = _consumerKey,
                    ConsumerSecret = _consumerSecret,
                    SignatureMethod = OAuthSignatureMethod.HmacSha1,
                    Token = requestToken.Token,
                    TokenSecret = requestToken.TokenSecret,
                    Verifier = verifyer,
                    Type = OAuthType.AccessToken
                },
                Method = WebMethod.Get,
                Path = "/oauth/access_token"
            };

            var response = _oauth.Request(request);

            var query = HttpUtility.ParseQueryString(response.Content);
            var oauth = new OAuthAccessToken
            {
                Token = query["oauth_token"] ?? "?",
                TokenSecret = query["oauth_token_secret"] ?? "?"
            };

            return oauth;
        }

        public void AuthenticateWith(string token, string tokenSecret)
        {
            _token = token;
            _tokenSecret = tokenSecret;
        }



        public object GetCurrentUser()
        {
            var request = new RestRequest
            {
                Credentials = new OAuthCredentials
                {
                    ConsumerKey = _consumerKey,
                    ConsumerSecret = _consumerSecret,
                    SignatureMethod = OAuthSignatureMethod.HmacSha1,
                    Token = _token,
                    TokenSecret = _tokenSecret,
                    Type = OAuthType.ProtectedResource
                },
                Method = WebMethod.Get,
                Path = "/user"
            };

            var response = _oauth.Request(request);

            //TODO: Parse this json string and convert it into the object we are looking for.

            return response.Content;
        }
    }
}
