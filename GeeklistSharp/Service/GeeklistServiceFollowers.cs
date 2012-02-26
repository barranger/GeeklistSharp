using System;
using System.Collections.Generic;
using System.Linq;
using GeeklistSharp.Model;
using Hammock;
using Hammock.Web;

namespace GeeklistSharp.Service
{
    public partial class GeeklistService
    {
        public FollowersData GetFollowers()
        {
            return GetFollowers(null);
        }

        public void GetFollowersAsync(Action<FollowersData> callback)
        {
            GetFollowersAsync(callback, null);
        }

        public FollowersData GetFollowers(string user)
        {
            return GetFollowers(user, null, null);
        }

        public void GetFollowersAsync(Action<FollowersData> callback, string user)
        {
            GetFollowersAsync(callback, user, null, null);
        }

        public FollowersData GetFollowers(string user, int? page, int? count)
        {
            var path = string.IsNullOrEmpty(user) ? "/user/followers" : string.Format("/users/{0}/followers", user);

            var request = api.CreateAuthenticatedRequest(path);

            if (page.HasValue)
            {
                request.AddParameter("page", page.Value.ToString());
            }
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value.ToString());
            }

            var result = api.GetResults<FollowersData>(request);

            if (page.HasValue)
            {
                result.PageNumber = page.Value;
            }
            if (count.HasValue)
            {
                result.PageSize = count.Value;
            }
            return result;
        }

        public void GetFollowersAsync(Action<FollowersData> callback, string user, int? page, int? count)
        {
            var path = string.IsNullOrEmpty(user) ? "/user/followers" : string.Format("/users/{0}/followers", user);

            var request = api.CreateAuthenticatedRequest(path);

            if (page.HasValue)
            {
                request.AddParameter("page", page.Value.ToString());
            }
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value.ToString());
            }

            api.GetResultsAsync<FollowersData>(callback, request);
        }

        public FollowingData GetFollowing()
        {
            return GetFollowing(null);
        }

        public void GetFollowingAsync(Action<FollowingData> callback)
        {
            GetFollowingAsync(callback, null);
        }

        public FollowingData GetFollowing(string user)
        {
            return GetFollowing(user, null, null);
        }

        public void GetFollowingAsync(Action<FollowingData> callback, string user)
        {
            GetFollowingAsync(callback, user, null, null);
        }

        public FollowingData GetFollowing(string user, int? page, int? count)
        {
            var path = string.IsNullOrEmpty(user) ? "/user/following" : string.Format("/users/{0}/following", user);

            var request = api.CreateAuthenticatedRequest(path);

            if (page.HasValue)
            {
                request.AddParameter("page", page.Value.ToString());
            }
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value.ToString());
            }

            var result = api.GetResults<FollowingData>(request);

            if (page.HasValue)
            {
                result.PageNumber = page.Value;
            }
            if (count.HasValue)
            {
                result.PageSize = count.Value;
            }

            return result;
        }

        public void GetFollowingAsync(Action<FollowingData> callback, string user, int? page, int? count)
        {
            var path = string.IsNullOrEmpty(user) ? "/user/following" : string.Format("/users/{0}/following", user);

            var request = api.CreateAuthenticatedRequest(path);

            if (page.HasValue)
            {
                request.AddParameter("page", page.Value.ToString());
            }
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value.ToString());
            }

            api.GetResultsAsync<FollowingData>(callback, request);
        }

        public void FollowUser(string userId)
        {
            var request = api.CreateAuthenticatedRequest("/follow", WebMethod.Post);

            request.AddParameter("user", userId);
            request.AddParameter("action", "follow");

            var response = api.GetResults<object>(request);
        }

        public void FollowUserAsync(Action<object> callback, string userId)
        {
            var request = api.CreateAuthenticatedRequest("/follow", WebMethod.Post);

            request.AddParameter("user", userId);
            request.AddParameter("action", "follow");

            api.GetResultsAsync<object>(callback, request);
        }

        public void UnFollowUser(string userId)
        {
            var request = api.CreateAuthenticatedRequest("/follow", WebMethod.Post);
            request.AddParameter("user", userId);
            var response = api.GetResults<object>(request);
        }

        public void UnFollowUserAsync(Action<object> callback, string userId)
        {
            var request = api.CreateAuthenticatedRequest("/follow", WebMethod.Post);
            request.AddParameter("user", userId);
            api.GetResultsAsync<object>(callback, request);
        }
    }
}
