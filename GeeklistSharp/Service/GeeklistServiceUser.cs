using System;
using System.Linq;
using GeeklistSharp.Model;

namespace GeeklistSharp.Service
{
    public partial class GeeklistService
    {
        public User GetUser(string name = null)
        {
            var request = api.CreateAuthenticatedRequest(name == null ? "/user" : "/users/" + name);

            return api.GetResults<User>(request);
        }

        public void GetUserAsync(Action<User> callback, string name = null)
        {
            var request = api.CreateAuthenticatedRequest(name == null ? "/user" : "/users/" + name);
            api.GetResultsAsync<User>(callback, request);
        }
    }
}
