using System;
using System.Linq;
using System.Threading;
using GeeklistSharp.Model;
using GeeklistSharp.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeklistSharp.Tests
{
    /// <summary>
    ///This is a test class for GeeklistServiceTest and is intended
    ///to contain all GeeklistServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GeeklistServiceFollowersTest : GeeklistBaseTest
    {
        private GeeklistService service;
        private Card unitTestCard;
        private Micro unitTestMicro;

        [TestInitialize]
        public void Setup()
        {
            service = GetAuthenticatedService();
            unitTestCard = service.CreateCard("Unit Test Card " + Guid.NewGuid());
            unitTestMicro = service.CreateMicro("Unit Test Micro " + Guid.NewGuid());
        }

        /// <summary>
        ///A test for ServiceFollowers to get the Followers of the current User
        ///</summary>
        public void GetFollowersTest()
        {
            FollowersData followersData = service.GetFollowers();

            Assert.IsNotNull(followersData);
        }

        /// <summary>
        ///A test for ServiceFollowers to get the Followers of the current User
        ///</summary>
        [TestMethod]
        public void GetFollowersAsyncTest()
        {
            FollowersData followersData = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.GetFollowersAsync((fd) =>
            {
                followersData = fd;
                waitHandle.Set();
            });

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(followersData);
        }

        /// <summary>
        ///A test for ServiceFollowing to get the users the current user follows
        ///</summary>
        public void GetFollowingTest()
        {
            FollowingData followingData = service.GetFollowing();

            Assert.IsNotNull(followingData);
        }

        /// <summary>
        ///A test for ServiceFollowing to get the users the current user follows
        ///</summary>
        [TestMethod]
        public void GetFollowingAsyncTest()
        {
            FollowingData followingData = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.GetFollowingAsync((fd) =>
            {
                followingData = fd;
                waitHandle.Set();
            });

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(followingData);
        }

        /// <summary>
        ///A test for ServiceFollowing to get the users the current user follows
        ///</summary>
        public void GetFollowingUserTest()
        {
            FollowingData followingData = service.GetFollowing(TestConstants.USERNAME, null, null);

            Assert.IsNotNull(followingData);
        }

        /// <summary>
        ///A test for ServiceFollowing to get the users the current user follows
        ///</summary>
        [TestMethod]
        public void GetFollowingAsyncUserTest()
        {
            FollowingData followingData = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.GetFollowingAsync((fd) =>
            {
                followingData = fd;
                waitHandle.Set();
            }, TestConstants.USERNAME, null, null);

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(followingData);
        }

        /// <summary>
        ///A test for ServiceFollowing to get the users the current user follows
        ///</summary>
        public void GetFollowingUserPageTest()
        {
            FollowingData followingData = service.GetFollowing(TestConstants.USERNAME, 1, null);

            Assert.IsNotNull(followingData);
        }

        /// <summary>
        ///A test for ServiceFollowing to get the users the current user follows
        ///</summary>
        [TestMethod]
        public void GetFollowingAsyncUserPageTest()
        {
            FollowingData followingData = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.GetFollowingAsync((fd) =>
            {
                followingData = fd;
                waitHandle.Set();
            }, TestConstants.USERNAME, 1, null);

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(followingData);
        }

        /// <summary>
        ///A test for ServiceFollowing to get the users the current user follows
        ///</summary>
        public void GetFollowingUserCountTest()
        {
            FollowingData followingData = service.GetFollowing(TestConstants.USERNAME, null, 5);

            Assert.IsNotNull(followingData);
        }

        /// <summary>
        ///A test for ServiceFollowing to get the users the current user follows
        ///</summary>
        [TestMethod]
        public void GetFollowingAsyncUserCountTest()
        {
            FollowingData followingData = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.GetFollowingAsync((fd) =>
            {
                followingData = fd;
                waitHandle.Set();
            }, TestConstants.USERNAME, null, 5);

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(followingData);
        }

        /// <summary>
        ///A test for ServiceFollowing to get the users the current user follows
        ///</summary>
        public void GetFollowingUserPageCountTest()
        {
            FollowingData followingData = service.GetFollowing(TestConstants.USERNAME, 2, 5);

            Assert.IsNotNull(followingData);
        }

        /// <summary>
        ///A test for ServiceFollowing to get the users the current user follows
        ///</summary>
        [TestMethod]
        public void GetFollowingAsyncUserPageCountTest()
        {
            FollowingData followingData = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.GetFollowingAsync((fd) =>
            {
                followingData = fd;
                waitHandle.Set();
            }, TestConstants.USERNAME, 2, 5);

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(followingData);
        }

        /// <summary>
        ///A test for ServiceFollowers to get the Followers of the current User
        ///</summary>
        public void FollowUserTest()
        {
            service.FollowUser(TestConstants.USERID);
            bool contains = false;
            contains = CheckForFollowing(contains);
            Assert.IsTrue(contains);
        }
  
        /// <summary>
        ///A test for ServiceFollowers to get the Followers of the current User
        ///</summary>
        [TestMethod]
        public void FollowUserAsyncTest()
        {
            object followersData = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.FollowUserAsync((fd) =>
            {
                followersData = fd;
                waitHandle.Set();
            }, TestConstants.USERID);

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            bool contains = false;
            contains = CheckForFollowing(contains);
            Assert.IsTrue(contains);
        }

        /// <summary>
        ///A test for ServiceFollowers to get the Followers of the current User
        ///</summary>
        public void UnFollowUserTest()
        {
            service.UnFollowUser(TestConstants.USERID);
            bool contains = false;
            contains = CheckForFollowing(contains);
            Assert.IsFalse(contains);
        }

        /// <summary>
        ///A test for ServiceFollowers to get the Followers of the current User
        ///</summary>
        [TestMethod]
        public void UnFollowUserAsyncTest()
        {
            object followersData = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.UnFollowUserAsync((fd) =>
            {
                followersData = fd;
                waitHandle.Set();
            }, TestConstants.USERID);

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            bool contains = false;
            contains = CheckForFollowing(contains);
            Assert.IsFalse(contains);
        }

        private bool CheckForFollowing(bool contains)
        {
            FollowersData followersData = service.GetFollowers();
            foreach (var item in followersData.Followers)
            {
                if (item.Id.Equals(TestConstants.USERID))
                {
                    contains = true;
                }
            }
            return contains;
        }

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
