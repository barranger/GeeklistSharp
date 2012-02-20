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
        public object GetCurrentUsersMicros()
        {
            return GetCurrentUsersMicros(null, null);
        }

        public object GetCurrentUsersMicros(int? page, int? count)
        {
            var request = api.CreateAuthenticatedRequest("/user/micros");

            if (page.HasValue)
            {
                request.AddParameter("page", page.Value.ToString());
            }
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value.ToString());
            }

            return api.GetResults<MicroData>(request);
        }

        public object GetMicro(string id)
        {
            var request = api.CreateAuthenticatedRequest(string.Format("/micros/{0}", id));

            return api.GetResults<Micro>(request);
        }

        public object CreateMicro(string status)
        {
            return CreateMicro(string.Empty, string.Empty, status);
        }

        public object CreateMicro(string type, string in_reply_to, string status)
        {
            var request = api.CreateAuthenticatedRequest("/micros", WebMethod.Post);

            if (!string.IsNullOrEmpty(type) || !string.IsNullOrEmpty(in_reply_to))
            {
                request.AddParameter("type", type);
                request.AddParameter("in_reply_to", in_reply_to);
            }
            request.AddParameter("status", status);
            return api.GetResults<Micro>(request);
        }
    }
}
