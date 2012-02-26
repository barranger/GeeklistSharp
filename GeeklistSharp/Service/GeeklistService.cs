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
        private static RestApiWrapper api;

        public GeeklistService(string consumerKey, string consumerSecret, string callback = "oob")
        {
            api = new RestApiWrapper(consumerKey, consumerSecret, callback);
        }
    }
}