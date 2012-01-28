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
        [TestMethod]
        public void ShouldDeSerializeFollowingData()
        {
            string testStatsJson = @"{""status"":""ok"",""data"":{""total_following"":1,""following"":[{ }] } }";
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Response<FollowingData>));

            MemoryStream memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(testStatsJson));

            var result = serializer.ReadObject(memoryStream) as Response<FollowingData>;

            Assert.AreEqual(1, result.Data.TotalFollowing);
            Assert.AreEqual(1, result.Data.Following.Count());
        }

        [TestMethod]
        public void ShouldDeSerializeFollowerData()
        {
            string testStatsJson = @"{""status"":""ok"",""data"":{""total_followers"":1,""followers"":[{ }] } }";
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Response<FollowersData>));

            MemoryStream memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(testStatsJson));

            var result = serializer.ReadObject(memoryStream) as Response<FollowersData>;

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
    }
}
