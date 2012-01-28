using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeeklistSharp.Model;
using GeeklistSharp.Service;

namespace GeeklistSharp.Tests
{
    public class GeeklistBaseTest
    {
        public GeeklistService GetAuthenticatedService()
        {
            string consumerKey = TestConstants.OAUTH_CONSUMER_KEY; // TODO: Initialize to an appropriate value
            string consumerSecret = TestConstants.OAUTH_CONSUMER_SECRET; // TODO: Initialize to an appropriate value
            string token = TestConstants.TOKEN; // TODO: Initialize to an appropriate value
            string tokenSecret = TestConstants.TOKEN_SECRET; // TODO: Initialize to an appropriate value
            GeeklistService service = new GeeklistService(consumerKey, consumerSecret);

            OAuthAccessToken accessToken = new OAuthAccessToken { Token = token, TokenSecret = tokenSecret };

            service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
            return service;
        }
    }
}
