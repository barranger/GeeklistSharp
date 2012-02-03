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

            return api.GetResults<User>(request);
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

            return api.GetResults<CardData>(request);
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

            return api.GetResults<CardData>(request);
        }

        public object GetCard(string id)
        {
            var request = api.CreateAuthenticatedRequest(string.Format("/cards/{0}", id));

            return api.GetResults<Card>(request);
        }

        public object CreateCard(string headline)
        {
            var request = api.CreateAuthenticatedRequest("/cards", WebMethod.Post);

            request.AddParameter("headline", headline);
            return api.GetResults<Card>(request);
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

            var result = api.GetResults<FollowersData>(request);

            result.PageNumber = page;
            result.PageSize = pageSize;

            return result;
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

            var result = api.GetResults<FollowingData>(request);

            result.PageNumber = page;
            result.PageSize = pageSize;

            return result;
        }

        public void FollowUser(string userId)
        {
            var request = api.CreateAuthenticatedRequest("/follow", WebMethod.Post);

            request.AddParameter("user", userId);
            request.AddParameter("action", "follow");

            var response = api.GetResults<object>(request);

        }

        public void UnFollowUser(string userId)
        {
            var request = api.CreateAuthenticatedRequest("/follow", WebMethod.Post);
            request.AddParameter("user", userId);
            var response = api.GetResults<object>(request);

        }
        #endregion followers

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

            return api.GetResults<Card[]>(request);
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

            return api.GetResults<List<Activity>>(request);
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

            return api.GetResults<List<Activity>>(request);
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
            return api.GetResults<Card>(request);
        }
        #endregion
    }
}