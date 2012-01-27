using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeeklistSharp.Service;
using System.Diagnostics;
using GeeklistSharp.Model;

namespace GeeklistSharp.Tests
{
    [TestClass]
    public class GeeklistServiceUserTest
    {
        [TestMethod]
        public void CurrentUserInfoTest()
        {
            var service = GetAndTestAuthenticatedService();

            var currentUser = service.GetUser();

            Assert.IsNotNull(currentUser);
            Assert.IsNotNull(currentUser.Name);
        }

        [TestMethod]
        public void UserByNameInfoTest()
        {
            var service = GetAndTestAuthenticatedService();

            var user = service.GetUser("4mkmobile");

            Assert.IsNotNull(user);
            Assert.AreEqual(user.ScreenName, "4MKMobile");
            Assert.AreEqual(user.Name, "Barranger Ridler");
        }

        private GeeklistService GetAndTestAuthenticatedService()
        {
            string consumerKey = TestConstants.OAUTH_CONSUMER_KEY; // TODO: Initialize to an appropriate value
            string consumerSecret = TestConstants.OAUTH_CONSUMER_SECRET; // TODO: Initialize to an appropriate value
            GeeklistService service = new GeeklistService(consumerKey, consumerSecret);

            var requestToken = service.GetRequestToken();
            Assert.IsNotNull(requestToken);
            Assert.IsFalse(requestToken.Token == "?" || requestToken.TokenSecret == "?");

            var uri = service.GetAuthorizationUrl(requestToken.Token);
            Process.Start(uri.ToString());

            var verifyer = "9623666"; // <-- Debugger breakpoint and edit with the actual verifier

            OAuthAccessToken accessToken = service.GetAccessToken(requestToken, verifyer);
            Assert.IsNotNull(accessToken);
            Assert.IsFalse(accessToken.Token == "?" || accessToken.TokenSecret == "?");

            service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
            return service;
        }
    }
}
