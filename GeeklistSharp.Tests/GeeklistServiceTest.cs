using GeeklistSharp.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using GeeklistSharp.Model;

namespace GeeklistSharp.Tests
{
    
    
    /// <summary>
    ///This is a test class for GeeklistServiceTest and is intended
    ///to contain all GeeklistServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GeeklistServiceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetRequestToken
        ///</summary>
        [TestMethod()]
        public void GetRequestTokenTest()
        {
            string consumerKey = TestConstants.OAUTH_CONSUMER_KEY; // TODO: Initialize to an appropriate value
            string consumerSecret = TestConstants.OAUTH_CONSUMER_SECRET; // TODO: Initialize to an appropriate value
            GeeklistService target = new GeeklistService(consumerKey, consumerSecret, "http://geekli.st");

            var token = target.GetRequestToken();
            Assert.IsNotNull(token);
            Assert.IsFalse( token.Token == "?" || token.TokenSecret == "?" );
        }

        /// <summary>
        ///A test for GetRequestToken
        ///</summary>
        [TestMethod()]
        public void GetOOBRequestTokenTest()
        {
            string consumerKey = TestConstants.OAUTH_CONSUMER_KEY; // TODO: Initialize to an appropriate value
            string consumerSecret = TestConstants.OAUTH_CONSUMER_SECRET; // TODO: Initialize to an appropriate value
            GeeklistService target = new GeeklistService(consumerKey, consumerSecret);

            var token = target.GetRequestToken();
            Assert.IsNotNull(token);
            Assert.IsFalse(token.Token == "?" || token.TokenSecret == "?");
        }

        /// <summary>
        ///A test for GetRequestToken
        ///</summary>
        [TestMethod()]
        public void GetAccessTokenTest()
        {
            string consumerKey = TestConstants.OAUTH_CONSUMER_KEY; // TODO: Initialize to an appropriate value
            string consumerSecret = TestConstants.OAUTH_CONSUMER_SECRET; // TODO: Initialize to an appropriate value
            GeeklistService target = new GeeklistService(consumerKey, consumerSecret);

            var requestToken = target.GetRequestToken();
            Assert.IsNotNull(requestToken);
            Assert.IsFalse(requestToken.Token == "?" || requestToken.TokenSecret == "?");

            var uri = target.GetAuthorizationUrl(requestToken.Token);
            Process.Start(uri.ToString());

            var verifyer = "5444526"; // <-- Debugger breakpoint and edit with the actual verifier

            OAuthAccessToken accessToken = target.GetAccessToken(requestToken, verifyer);
            Assert.IsNotNull(accessToken);
            Assert.IsFalse(accessToken.Token == "?" || accessToken.TokenSecret == "?");
        }

    }
}
