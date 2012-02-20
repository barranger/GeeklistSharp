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
    }
}
