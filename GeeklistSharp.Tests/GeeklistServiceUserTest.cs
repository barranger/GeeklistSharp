using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeeklistSharp.Service;
using System.Diagnostics;
using GeeklistSharp.Model;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;

namespace GeeklistSharp.Tests
{
    [TestClass]
    public class GeeklistServiceUserTest : GeeklistBaseTest
    {
        private GeeklistService service;

        [TestInitialize]
        public void Setup()
        {
            service = GetAuthenticatedService();
        }

        [TestMethod]
        public void GetUserTest()
        {
            var currentUser = service.GetUser();

            Assert.IsNotNull(currentUser);
            Assert.IsNotNull(currentUser.Name);
            //Assert.AreNotEqual(currentUser.Stats.Views, 0);
        }

        [TestMethod]
        public void GetUserAsyncTest()
        {
            User currentUser =null;
            AutoResetEvent waitHandle = new AutoResetEvent(false);
            
            service.GetUserAsync((u) =>
            {
                currentUser = u;
                waitHandle.Set();
            });

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }
            Assert.IsNotNull(currentUser);
            Assert.IsNotNull(currentUser.Name);
            //Assert.AreNotEqual(currentUser.Stats.Views, 0);
        }

        [TestMethod]
        public void GetUserNameTest()
        {
            var user = service.GetUser(TestConstants.USERID);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.ScreenName, TestConstants.USERID);
            Assert.AreEqual(user.Name, TestConstants.USERNAME);
            //Assert.IsNotNull(user.Stats);
            //Assert.AreNotEqual(user.Stats.Views, 0);
        }

        [TestMethod]
        public void GetUserAsyncNameTest()
        {
            User user = null;
            AutoResetEvent waitHandle = new AutoResetEvent(false); 

            service.GetUserAsync( (u) => 
                {
                    user = u;
                    waitHandle.Set();
                }, TestConstants.USERID);
            
            if (!waitHandle.WaitOne(5000, false))  
            {  
                Assert.Fail("Test timed out.");  
            }

            Assert.IsNotNull(user);
            Assert.AreEqual(user.ScreenName, TestConstants.USERID);
            Assert.AreEqual(user.Name, TestConstants.USERNAME);

        }

        //private GeeklistService GetAndTestAuthenticatedService()
        //{
        //    string consumerKey = TestConstants.OAUTH_CONSUMER_KEY; // TODO: Initialize to an appropriate value
        //    string consumerSecret = TestConstants.OAUTH_CONSUMER_SECRET; // TODO: Initialize to an appropriate value
        //    GeeklistService service = new GeeklistService(consumerKey, consumerSecret);

        //    var requestToken = service.GetRequestToken();
        //    Assert.IsNotNull(requestToken);
        //    Assert.IsFalse(requestToken.Token == "?" || requestToken.TokenSecret == "?");

        //    var uri = service.GetAuthorizationUrl(requestToken.Token);
        //    Process.Start(uri.ToString());

//            var verifyer = "3935346"; // <-- Debugger breakpoint and edit with the actual verifier

        //    OAuthAccessToken accessToken = service.GetAccessToken(requestToken, verifyer);
        //    Assert.IsNotNull(accessToken);
        //    Assert.IsFalse(accessToken.Token == "?" || accessToken.TokenSecret == "?");

        //    service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
        //    return service;
        //}

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
