using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hammock;
using Hammock.Web;
using Hammock.Authentication.OAuth;
using GeeklistSharp.Model;
using System.IO;

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
        static readonly Newtonsoft.Json.JsonSerializer serializer;

        static RestApiWrapper()
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings
            {
            };

            serializer = Newtonsoft.Json.JsonSerializer.Create(settings);
        }

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

        internal T GetResults<T>(RestRequest request)
        {
            var response = Request(request);
            var result = GetResponse<T>(response.ContentStream);

            if (result.Status != "ok")
            {
                throw new GeekListException(result.Status, result.Error);
            }

            return result.Data;
        }

        protected virtual Response<T> GetResponse<T>(Stream jsonStream)
        {
            var streamReader = new StreamReader(jsonStream);

            var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader);

            var result = serializer.Deserialize<Response<T>>(jsonTextReader);

            return result;
        }
    }
}
