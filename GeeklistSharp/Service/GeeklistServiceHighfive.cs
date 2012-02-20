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
    }
}