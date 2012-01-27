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

        [TestMethod]
        public void test_followers()
        {
            var result = @"{
    status: ""ok"",
    data: {
        total_followers: 1,
        followers: 
            [
                {
                    id: ""3aea9cb8ee5c93fdec2a84156cf4a69b8f3c15bc6e8f763ee19599db252bda8a"",
                    name: ""Christian Sanz"",
                    screen_name: ""csanz"",
                    avatar: {
                        small: ""http://a3.twimg.com/profile_images/1645650920/281699_10150253991022411_626637410_7803630_8323075_n_normal.jpg"",
                        large: ""http://a3.twimg.com/profile_images/1645650920/281699_10150253991022411_626637410_7803630_8323075_n.jpg""
                    },
                    blog_link: ""http://about.me/csanz"",
                    company: {
                        title: ""CTO & Co-founder"",
                        name: ""Geeklist""
                    },
                    location: ""San Francisco, CA"",
                    bio: ""Node.js Hacker / Creator/Founder of the Geeklist Movement, former CTO at Storify.com, founding Chief Architect at Break.com, Software guy at Disney"",
                    social_links: [
                        ""http://twitter.com/csanz"",
                        ""http://about.me/csanz"",
                        ""http://csanz.posterous.com/"",
                        ""https://github.com/csanz"",
                        ""http://geekli.st/csanz""
                    ],
                    social: {
                        twitter_screen_name: ""csanz"",
                        twitter_friends_count: 688,
                        twitter_followers_count: 762
                    },
                    criteria: {
                        looking_for: [
                            ""html/css devs"",
                            "" nodejs hackers"",
                            ""javascript hackers""
                        ],
                        available_for: [
                            ""advising"",
                            "" hacking"",
                            ""beer drinking""
                        ]
                    },
                    stats: {
                        number_of_pings: 22,
                        number_of_highfives: 323,
                        number_of_contributions: 30,
                        number_of_cards: 15
                    },
                    is_beta: true,
                    created_at: ""2011-07-03T00:38:43.853Z"",
                    updated_at: ""2011-12-15T20:29:41.091Z"",
                    active_at: ""2011-10-28T14:30:30.707Z"",
                    trending_at: ""2011-12-17T07:46:00.981Z"",
                    trending_hist: [ ]
                }
            ]

    }
}";

            MemoryStream memStream = new MemoryStream();
            byte[] data = Encoding.Unicode.GetBytes(result);
            memStream.Write(data, 0, data.Length);

            var serializer = new DataContractJsonSerializer(typeof(FollowersData));

            var followers = (FollowersData)serializer.ReadObject(memStream);

            Assert.IsNotNull(followers);


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

            var verifyer = "3935346"; // <-- Debugger breakpoint and edit with the actual verifier

            OAuthAccessToken accessToken = service.GetAccessToken(requestToken, verifyer);
            Assert.IsNotNull(accessToken);
            Assert.IsFalse(accessToken.Token == "?" || accessToken.TokenSecret == "?");

            service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
            return service;
        }
    }
}
