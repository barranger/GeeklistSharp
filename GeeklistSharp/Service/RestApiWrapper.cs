using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hammock;
using Hammock.Web;
using Hammock.Authentication.OAuth;

namespace GeeklistSharp.Service
{
    public class RestApiWrapper
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string Callback { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }


        private readonly RestClient _oauth;

        public RestApiWrapper(string consumerKey, string consumerSecret, string callback)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Callback = callback;

            _oauth = new RestClient
            {
                Authority = Globals.RestAPIAuthority,
                VersionPath = "v1",
                UserAgent = "GeeklistSharp",
            };
        }

        public RestRequest CreateAuthenticatedRequest(string path)
        {
            return CreateAuthenticatedRequest(path, WebMethod.Get, OAuthType.ProtectedResource);
        }
        public RestRequest CreateAuthenticatedRequest(string path, WebMethod method)
        {
            return CreateAuthenticatedRequest(path, method, OAuthType.ProtectedResource);
        }
        public RestRequest CreateAuthenticatedRequest(string path, OAuthType type)
        {
            return CreateAuthenticatedRequest(path, WebMethod.Get, type);
        }
        public RestRequest CreateAuthenticatedRequest(string path, WebMethod method, OAuthType type)
        {
            var request = new RestRequest
            {
                Credentials = new OAuthCredentials
                {
                    ConsumerKey = ConsumerKey,
                    ConsumerSecret = ConsumerSecret,
                    SignatureMethod = OAuthSignatureMethod.HmacSha1,
                    Token = Token,
                    TokenSecret = TokenSecret,
                    Type = OAuthType.ProtectedResource
                },
                Method = method,
                Path = path
            };
            return request;
        }

        public RestResponse Request(RestRequest request)
        {
            return _oauth.Request(request);
        }
    }
}
