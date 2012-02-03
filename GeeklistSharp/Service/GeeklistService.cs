using System;
using System.Collections.Generic;
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
    public class GeeklistService
    {
        private static RestApiWrapper api;

        static readonly Newtonsoft.Json.JsonSerializer serializer;

        static GeeklistService()
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings
            {
            };

            serializer = Newtonsoft.Json.JsonSerializer.Create(settings);
        }

        public GeeklistService(string consumerKey, string consumerSecret, string callback = "oob")
        {
            api = new RestApiWrapper(consumerKey, consumerSecret, callback);
        }

        #region login
        public OAuthRequestToken GetRequestToken()
        {

            var request = api.CreateAuthenticatedRequest("/oauth/request_token", OAuthType.RequestToken);
            
            var response = api.Request(request);

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
            var request = api.CreateAuthenticatedRequest("/oauth/access_token", OAuthType.AccessToken);
            var cred = request.Credentials as OAuthCredentials;
            cred.Verifier = verifyer;

            var response = api.Request(request);

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
            api.Token = token;
            api.TokenSecret = tokenSecret;
        }
        #endregion login

        #region user
        public User GetUser(string name = null)
        {
            var request = api.CreateAuthenticatedRequest(name == null ? "/user" : "/users/" + name);

            var response = api.Request(request);

            var result = GetResponse<User>(response.ContentStream);

            if (result.Status != "ok")
            {
                throw new GeekListException(result.Status, result.Error);
            }

            return result.Data;
        }
        #endregion user

        #region Cards

        public object GetCurrentUsersCards()
        {
            return GetCurrentUsersCards(null, null);
        }

        public object GetCurrentUsersCards(int? page, int? count)
        {
            var request = api.CreateAuthenticatedRequest("/user/cards");

            if (page.HasValue)
            {
                request.AddParameter("page", page.Value.ToString());
            }
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value.ToString());
            }

            var response = api.Request(request);

            var result = GetResponse<CardData>(response.ContentStream);

            if (result.Status != "ok")
            {
                throw new GeekListException(result.Status, result.Error);
            }

            return result.Data;
        }

        public object GetUsersCards(string userName)
        {
            return GetUsersCards(userName, null, null);
        }

        public object GetUsersCards(string userName, int? page, int? count)
        {
            var request = api.CreateAuthenticatedRequest(string.Format("/users/{0}/cards", userName));

            if (page.HasValue)
            {
                request.AddParameter("page", page.Value.ToString());
            }
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value.ToString());
            }

            var response = api.Request(request);

            var result = GetResponse<CardData>(response.ContentStream);

            if (result.Status != "ok")
            {
                throw new GeekListException(result.Status, result.Error);
            }

            return result.Data;
        }

        public object GetCard(string id)
        {
            var request = api.CreateAuthenticatedRequest(string.Format("/cards/{0}", id));

            var response = api.Request(request);

            var result = GetResponse<Card>(response.ContentStream);

            if (result.Status != "ok")
            {
                throw new GeekListException(result.Status, result.Error);
            }

            return result.Data;
        }

        public object CreateCard(string headline)
        {
            var request = api.CreateAuthenticatedRequest("/cards", WebMethod.Post);

            request.AddParameter("headline", headline);
            var response = api.Request(request);

            var result = GetResponse<Card>(response.ContentStream);

            if (result.Status != "ok")
            {
                throw new GeekListException(result.Status, result.Error);
            }

            return result.Data;
        }

        #endregion Cards

        #region Followers

        public FollowersData GetFollowers()
        {
            return GetFollowers(null);
        }

        public FollowersData GetFollowers(string user)
        {
            return GetFollowers(user, 1, 10);
        }

        public FollowersData GetFollowers(string user, int page, int pageSize)
        {
            var path = string.IsNullOrEmpty(user) ? "/user/followers" : string.Format("/users/{0}/followers", user);

            var request = api.CreateAuthenticatedRequest(path);

            request.AddParameter("page", page.ToString());

            request.AddParameter("count", pageSize.ToString());

            var response = api.Request(request);

            var result = GetResponse<FollowersData>(response.ContentStream);

            EnsureResponseOk(result);

            result.Data.PageNumber = page;
            result.Data.PageSize = pageSize;

            return result.Data;
        }

        public FollowingData GetFollowing()
        {
            return GetFollowing(null);
        }

        public FollowingData GetFollowing(string user)
        {
            return GetFollowing(user, 1, 10);
        }

        public FollowingData GetFollowing(string user, int page, int pageSize)
        {
            var path = string.IsNullOrEmpty(user) ? "/user/following" : string.Format("/users/{0}/following", user);

            var request = api.CreateAuthenticatedRequest(path);

            request.AddParameter("page", page.ToString());

            request.AddParameter("count", pageSize.ToString());

            var response = api.Request(request);

            var result = GetResponse<FollowingData>(response.ContentStream);

            EnsureResponseOk(result);

            result.Data.PageNumber = page;
            result.Data.PageSize = pageSize;

            return result.Data;
        }

        protected virtual Response<T> GetResponse<T>(Stream jsonStream)
        {
            var streamReader = new StreamReader(jsonStream);

            var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader);

            var result = serializer.Deserialize<Response<T>>(jsonTextReader);

            return result;
        }

        public void FollowUser(string userId)
        {
            var request = api.CreateAuthenticatedRequest("/follow", WebMethod.Post);

            request.AddParameter("user", userId);
            request.AddParameter("action", "follow");

            var response = api.Request(request);

            var result = GetResponse<object>(response.ContentStream);

            EnsureResponseOk(result);

        }

        public void UnFollowUser(string userId)
        {
            var request = api.CreateAuthenticatedRequest("/follow", WebMethod.Post);

            request.AddParameter("user", userId);

            var response = api.Request(request);

            var result = GetResponse<object>(response.ContentStream);

            EnsureResponseOk(result);

        }
        #endregion followers

        private static void EnsureResponseOk<T>(Response<T> result)
        {
            if (result.Status != "ok")
            {
                throw new GeekListException(result.Status, result.Error);
            }
        }

        #region Activity
        public object GetCurrentUsersActivities()
        {
            return GetCurrentUsersActivities(null, null);
        }

        public object GetCurrentUsersActivities(int? page, int? count)
        {
            var request = api.CreateAuthenticatedRequest("/user/activity");

            if (page.HasValue)
            {
                request.AddParameter("page", page.Value.ToString());
            }
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value.ToString());
            }

            var response = api.Request(request);

            var result = GetResponse<Card[]>(response.ContentStream);

            if (result.Status != "ok")
            {
                throw new GeekListException(result.Status, result.Error);
            }
            return result.Data;
        }

        public object GetUsersActivities(string userName)
        {
            return GetUsersActivities(userName, null, null);
        }

        public object GetUsersActivities(string userName, int? page, int? count)
        {
            var request = api.CreateAuthenticatedRequest(string.Format("/users/{0}/activity", userName));

            if (page.HasValue)
            {
                request.AddParameter("page", page.Value.ToString());
            }
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value.ToString());
            }

            var response = api.Request(request);

            var result = GetResponse<List<Activity>>(response.ContentStream);

            if (result.Status != "ok")
            {
                throw new GeekListException(result.Status, result.Error);
            }

            return result.Data;
        }
        public object GetAllActivities()
        {
            return GetAllActivities(null, null);
        }

        public object GetAllActivities(int? page, int? count)
        {
            var request = api.CreateAuthenticatedRequest("/activity");

            if (page.HasValue)
            {
                request.AddParameter("page", page.Value.ToString());
            }
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value.ToString());
            }

            var response = api.Request(request);

            var result = GetResponse<List<Activity>>(response.ContentStream);

            if (result.Status != "ok")
            {
                throw new GeekListException(result.Status, result.Error);
            }

            return result.Data;
        }
        #endregion

        #region HighFive
        public object HighfiveItem(string id, string type)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Invalid id", "id");
            }
            var request = api.CreateAuthenticatedRequest("/highfive", WebMethod.Post);

            request.AddParameter("type", type);
            request.AddParameter("gfk", id);
            var response = api.Request(request);

            var result = GetResponse<Card>(response.ContentStream);

            if (result.Status != "ok")
            {
                throw new GeekListException(result.Status, result.Error);

            }
            return result.Data;
        }
        #endregion
    }
}