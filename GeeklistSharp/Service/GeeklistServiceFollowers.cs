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

    }
}
