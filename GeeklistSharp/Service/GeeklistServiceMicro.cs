using System;
using System.Linq;
using GeeklistSharp.Model;
using Hammock.Web;

namespace GeeklistSharp.Service
{
    public partial class GeeklistService
    {
        public MicroData GetCurrentUsersMicros()
        {
            return GetCurrentUsersMicros(null, null);
        }

        public void GetCurrentUsersMicrosAsync(Action<MicroData> callback)
        {
            GetCurrentUsersMicrosAsync(callback, null, null);
        }

        public MicroData GetCurrentUsersMicros(int? page, int? count)
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

        public void GetCurrentUsersMicrosAsync(Action<MicroData> callback, int? page, int? count)
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

            api.GetResultsAsync<MicroData>(callback, request);
        }

        public Micro GetMicro(string id)
        {
            var request = api.CreateAuthenticatedRequest(string.Format("/micros/{0}", id));

            return api.GetResults<Micro>(request);
        }

        public void GetMicroAsync(Action<Micro> callback, string id)
        {
            var request = api.CreateAuthenticatedRequest(string.Format("/micros/{0}", id));

            api.GetResultsAsync<Micro>(callback, request);
        }

        public Micro CreateMicro(string status)
        {
            return CreateMicro(string.Empty, string.Empty, status);
        }

        public void CreateMicroAsync(Action<Micro> callback, string status)
        {
            CreateMicroAsync(callback, string.Empty, string.Empty, status);
        }

        public Micro CreateMicro(string type, string inReplyTo, string status)
        {
            var request = api.CreateAuthenticatedRequest("/micros", WebMethod.Post);

            if (!string.IsNullOrEmpty(type) || !string.IsNullOrEmpty(inReplyTo))
            {
                request.AddParameter("type", type);
                request.AddParameter("in_reply_to", inReplyTo);
            }
            request.AddParameter("status", status);
            return api.GetResults<Micro>(request);
        }

        public void CreateMicroAsync(Action<Micro> callback, string type, string inReplyTo, string status)
        {
            var request = api.CreateAuthenticatedRequest("/micros", WebMethod.Post);

            if (!string.IsNullOrEmpty(type) || !string.IsNullOrEmpty(inReplyTo))
            {
                request.AddParameter("type", type);
                request.AddParameter("in_reply_to", inReplyTo);
            }
            request.AddParameter("status", status);
            api.GetResultsAsync<Micro>(callback, request);
        }
    }
}
