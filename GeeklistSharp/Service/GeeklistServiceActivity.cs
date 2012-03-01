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
        public Card[] GetCurrentUsersActivities()
        {
            return GetCurrentUsersActivities(null, null);
        }

        public void GetCurrentUsersActivitiesAsync(Action<Card[]> callback)
        {
            GetCurrentUsersActivitiesAsync(callback, null, null);
        }

        public Card[] GetCurrentUsersActivities(int? page, int? count)
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

        public void GetCurrentUsersActivitiesAsync(Action<Card[]> callback, int? page, int? count)
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

            api.GetResultsAsync<Card[]>(callback, request);
        }

        public List<Activity> GetUsersActivities(string userName)
        {
            return GetUsersActivities(userName, null, null);
        }

        public void GetUsersActivitiesAsync(Action<List<Activity>> callback, string userName)
        {
            GetUsersActivitiesAsync(callback, userName, null, null);
        }

        public List<Activity> GetUsersActivities(string userName, int? page, int? count)
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

        public void GetUsersActivitiesAsync(Action<List<Activity>> callback, string userName, int? page, int? count)
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

            api.GetResultsAsync<List<Activity>>(callback, request);
        }

        public List<Activity> GetAllActivities()
        {
            return GetAllActivities(null, null);
        }

        public void GetAllActivitiesAsync(Action<List<Activity>> callback)
        {
            GetAllActivitiesAsync(callback, null, null);
        }

        public List<Activity> GetAllActivities(int? page, int? count)
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

        public void GetAllActivitiesAsync(Action<List<Activity>> callback, int? page, int? count)
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

            api.GetResultsAsync<List<Activity>>(callback, request);
        }
    }
}
