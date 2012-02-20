using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeeklistSharp.Service;
using System.Diagnostics;
using GeeklistSharp.Model;
using System.Runtime.Serialization.Json;
using System.IO;

namespace GeeklistSharp.Tests
{
    /// <summary>
    ///This is a test class for GeeklistServiceTest and is intended
    ///to contain all GeeklistServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GeeklistServiceFollowersTest
    {
#region Followers Serialization Tests
        [TestMethod]
        public void DeserializeFollowing()
        {
            string testStatsJson = @"{""status"":""ok"",""data"":{""total_following"":1,""following"":[{ }] } }";

            var result = TestConstants.DeserializeFromStream<Response<FollowingData>>(testStatsJson);

            Assert.AreEqual(1, result.Data.TotalFollowing);
            Assert.AreEqual(1, result.Data.Following.Count());
        }

        [TestMethod]
        public void DeserializeFollower()
        {
            string testStatsJson = @"{""status"":""ok"",""data"":{""total_followers"":1,""followers"":[{ }] } }";

            var result = TestConstants.DeserializeFromStream<Response<FollowersData>>(testStatsJson);

            Assert.AreEqual(1, result.Data.TotalFollowers);
            Assert.AreEqual(1, result.Data.Followers.Count());
        }
        //private GeeklistService GetAuthenticatedService()
        //{
        //    string consumerKey = TestConstants.OAUTH_CONSUMER_KEY; // TODO: Initialize to an appropriate value
        //    string consumerSecret = TestConstants.OAUTH_CONSUMER_SECRET; // TODO: Initialize to an appropriate value
        //    string token = TestConstants.TOKEN; // TODO: Initialize to an appropriate value
        //    string tokenSecret = TestConstants.TOKEN_SECRET; // TODO: Initialize to an appropriate value
        //    GeeklistService service = new GeeklistService(consumerKey, consumerSecret);

        //    OAuthAccessToken accessToken = new OAuthAccessToken { Token = token, TokenSecret = tokenSecret };

        //    service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
        //    return service;
        //}
#endregion Followers Serialization Tests
    }
}
