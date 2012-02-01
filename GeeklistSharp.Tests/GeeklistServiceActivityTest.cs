using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GeeklistSharp.Model;
using GeeklistSharp.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization.Json;

namespace GeeklistSharp.Tests
{
    /// <summary>
    ///This is a test class for GeeklistServiceActivityTest and is intended
    ///to contain all GeeklistServiceActivityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GeeklistServiceActivityTest : GeeklistBaseTest
    {
        private GeeklistService service;

        [TestInitialize]
        public void Setup()
        {
            service = GetAuthenticatedService();
        }

        /// <summary>
        ///A test for ServiceActivities to get the Activities of the current User
        ///</summary>
        [TestMethod]
        public void ServiceGetCurrentUsersActivitiesTest()
        {
            var returnStatus = service.GetCurrentUsersActivities();

            Assert.IsNotNull(returnStatus);
        }

        /// <summary>
        ///A test for ServiceActivities to get the Activities of the current User
        ///</summary>
        [TestMethod]
        public void ServiceGetCurrentUsersActivitiesPagedTest()
        {
            var currentUsersActivities = service.GetCurrentUsersActivities(1, null);

            Assert.IsNotNull(currentUsersActivities);
        }

        /// <summary>
        ///A test for ServiceActivities to get the Activities of the current User
        ///</summary>
        [TestMethod]
        public void ServiceGetCurrentUsersActivitiesCountTest()
        {
            var currentUsersActivities = service.GetCurrentUsersActivities(null, 5);

            Assert.IsNotNull(currentUsersActivities);
        }

        /// <summary>
        ///A test for ServiceActivities to get the Activities of the current User
        ///</summary>
        [TestMethod]
        public void ServiceGetCurrentUsersActivitiesPagedCountTest()
        {
            var currentUsersActivities = service.GetCurrentUsersActivities(2, 5);

            Assert.IsNotNull(currentUsersActivities);
        }

        /// <summary>
        ///A test for ServiceActivities for a specific User
        ///</summary>
        [TestMethod]
        public void ServiceGetUsersActivitiesTest()
        {
            var usersActivities = service.GetUsersActivities("oakcool");

            Assert.IsNotNull(usersActivities);
        }

        /// <summary>
        ///A test for ServiceActivities for a specific User
        ///</summary>
        [TestMethod]
        public void ServiceGetUsersActivitiesPagedTest()
        {
            var usersActivities = service.GetUsersActivities("oakcool", 1, null);

            Assert.IsNotNull(usersActivities);
        }

        /// <summary>
        ///A test for ServiceActivities for a specific User
        ///</summary>
        [TestMethod]
        public void ServiceGetUsersActivitiesCountTest()
        {
            var usersActivities = service.GetUsersActivities("oakcool", null, 5);

            Assert.IsNotNull(usersActivities);
        }

        /// <summary>
        ///A test for ServiceActivities for a specific User
        ///</summary>
        [TestMethod]
        public void ServiceGetUsersActivitiesPagedCountTest()
        {
            var usersActivities = service.GetUsersActivities("oakcool", 2, 5);

            Assert.IsNotNull(usersActivities);
        }

        #region Activity Serialization Tests
        /// <summary>
        ///A test for deserializing Activities
        ///</summary>
        [TestMethod]
        public void ActivitiesDeserializeTest()
        {
            string testActivitysJson = @"{""status"":""ok"",""data"":[{""type"":""micro"",""updated_at"":""2012-01-28T03:45:09.701Z"",""created_at"":""2012-01-28T03:45:09.694Z"",""is_active"":true,""gfk"":{""status"":""Test Micro"",""permalink"":""/lsmithmier/micro/2146"",""id"":""c8a1d5e5d41bbcb6d29f6b63b1e9e6526e78ee25a7a0983ec63ff8a4b2275148"",""reply"":{""thread"":{""is_active"":true,""type"":""micro"",""permalink"":""/lsmithmier/micro/2146"",""status"":""Test Micro"",""id"":""c8a1d5e5d41bbcb6d29f6b63b1e9e6526e78ee25a7a0983ec63ff8a4b2275148""},""in_reply_to"":{""is_active"":true,""type"":""micro"",""permalink"":""/lsmithmier/micro/2146"",""status"":""Test Micro"",""id"":""c8a1d5e5d41bbcb6d29f6b63b1e9e6526e78ee25a7a0983ec63ff8a4b2275148""}},""card"":{""skills"":[],""tasks"":[],""contributors"":[]},""details"":[],""hashtags"":[],""mentions"":[]},""user"":{""id"":""e47163371a660b6eca2b7935ec31f058648175377b290fb039229b3a08971890"",""screen_name"":""lsmithmier"",""avatar"":{""small"":""http://a2.twimg.com/profile_images/493173238/CSharp2_normal.png"",""large"":""http://a2.twimg.com/profile_images/493173238/CSharp2.png""}},""id"":""c8a1d5e5d41bbcb6d29f6b63b1e9e6526380a0262f0bfbb60238883d5514234a""},{""type"":""card"",""updated_at"":""2012-01-28T02:47:36.824Z"",""created_at"":""2012-01-28T02:47:36.821Z"",""is_active"":true,""gfk"":{""headline"":""Unit Test Card"",""permalink"":""/oakcool/unit-test-card"",""id"":""25c31dfce3d67208330a6cb995fc517bc48deda5d63bf6a65b83637cec65f9db"",""card"":{""skills"":[],""tasks"":[],""contributors"":[]},""details"":[],""hashtags"":[],""mentions"":[]},""user"":{""id"":""f08a84a8493272d2ce6d313efa1a07da7f15174dbcff994291dfc77c05195e60"",""screen_name"":""oakcool"",""avatar"":{""small"":""http://a1.twimg.com/profile_images/422722068/twitterProfilePhoto_normal.jpg"",""large"":""http://a1.twimg.com/profile_images/422722068/twitterProfilePhoto.jpg""}},""id"":""25c31dfce3d67208330a6cb995fc517bee8d9b8005a45e9961bb834c8f7398b8""},{""type"":""card"",""updated_at"":""2012-01-28T01:07:12.017Z"",""created_at"":""2012-01-28T01:07:12.013Z"",""is_active"":true,""gfk"":{""headline"":""Unit Test Card8b6476c9-0a98-4fc5-a225-34e546a2e49c"",""permalink"":""/4MKMobile/unit-test-card8b6476c90a984fc5a22534e546a2e49c"",""id"":""5cb59798f982336d107a439bfe3fcc98dab68ad4387cf1baf189cfc84b516681"",""card"":{""skills"":[],""tasks"":[],""contributors"":[]},""details"":[],""hashtags"":[],""mentions"":[]},""user"":{""id"":""4bf438041a5fe8cbbd31599d943034e52a77797d08224051d91cc59ff2b7a6d0"",""screen_name"":""4MKMobile"",""avatar"":{""small"":""http://a0.twimg.com/profile_images/1501858307/twit_rope_normal.jpg"",""large"":""http://a0.twimg.com/profile_images/1501858307/twit_rope.jpg""}},""id"":""f8a39ca658767326d80f5de0d6af3f7689e14f34c1bc1b8c80e2fbcb2c6f37db""},{""type"":""card"",""updated_at"":""2012-01-28T01:06:14.700Z"",""created_at"":""2012-01-28T01:06:14.696Z"",""is_active"":true,""gfk"":{""headline"":""Unit Test Card3b457cf0-0628-4d10-bd05-e3236bac3733"",""permalink"":""/4MKMobile/unit-test-card3b457cf006284d10bd05e3236bac3733"",""id"":""b1eb888994f3a9e5c6fb3eb28dfe0880296d2b8d689258900762cb7dce1414b6"",""card"":{""skills"":[],""tasks"":[],""contributors"":[]},""details"":[],""hashtags"":[],""mentions"":[]},""user"":{""id"":""4bf438041a5fe8cbbd31599d943034e52a77797d08224051d91cc59ff2b7a6d0"",""screen_name"":""4MKMobile"",""avatar"":{""small"":""http://a0.twimg.com/profile_images/1501858307/twit_rope_normal.jpg"",""large"":""http://a0.twimg.com/profile_images/1501858307/twit_rope.jpg""}},""id"":""b1eb888994f3a9e5c6fb3eb28dfe0880298834cfc0cd70ea6fe1b22fe4e67dea""},{""type"":""card"",""updated_at"":""2012-01-28T01:04:47.878Z"",""created_at"":""2012-01-28T01:04:47.874Z"",""is_active"":true,""gfk"":{""headline"":""Unit Test Card1c987eb1-1602-4b9a-9176-a5f2a7ccf1f3"",""permalink"":""/4MKMobile/unit-test-card1c987eb116024b9a9176a5f2a7ccf1f3"",""id"":""7eb3cd294a5fc2ffb15965d429a273a77d551040b788ec1769f2b4e123a54538"",""card"":{""skills"":[],""tasks"":[],""contributors"":[]},""details"":[],""hashtags"":[],""mentions"":[]},""user"":{""id"":""4bf438041a5fe8cbbd31599d943034e52a77797d08224051d91cc59ff2b7a6d0"",""screen_name"":""4MKMobile"",""avatar"":{""small"":""http://a0.twimg.com/profile_images/1501858307/twit_rope_normal.jpg"",""large"":""http://a0.twimg.com/profile_images/1501858307/twit_rope.jpg""}},""id"":""7eb3cd294a5fc2ffb15965d429a273a708594956a3437d35c512c5d87e994b3e""},{""type"":""follow"",""updated_at"":""2012-01-27T22:24:43.144Z"",""created_at"":""2012-01-27T22:24:43.143Z"",""is_active"":true,""gfk"":{""screen_name"":""emostar"",""id"":""d1f04d0175cc199c841c369247c7236788dacbf3863405ddd1e2f664b987b654"",""card"":{""skills"":[],""tasks"":[],""contributors"":[]},""avatar"":{""small"":""http://a3.twimg.com/profile_images/1274729324/184237_10150094541197231_547687230_6690066_5808904_n_normal.jpg"",""large"":""http://a3.twimg.com/profile_images/1274729324/184237_10150094541197231_547687230_6690066_5808904_n.jpg""},""details"":[],""hashtags"":[],""mentions"":[]},""user"":{""id"":""eae07cd5a5ae4ab5892fa9e4514704d831df4250a7992f28b1aaaa86d1eeb28a"",""screen_name"":""kjnilsson"",""avatar"":{""large"":""http://a0.twimg.com/profile_images/1630177710/BigMeanCarl.jpg"",""small"":""http://a0.twimg.com/profile_images/1630177710/BigMeanCarl_normal.jpg""}},""id"":""8da39026d77b77a5e2ac26d6d053b144254897a1cd498f2b1254b86e53c34b22""},{""type"":""follow"",""updated_at"":""2012-01-27T22:24:35.422Z"",""created_at"":""2012-01-27T22:24:35.418Z"",""is_active"":true,""gfk"":{""screen_name"":""paul_irish"",""id"":""6fbfcc0f42d75f775747e9ccd7d8d47ffb3b3664ff22952e40c82ab5b4bd23f2"",""card"":{""skills"":[],""tasks"":[],""contributors"":[]},""avatar"":{""small"":""http://a2.twimg.com/profile_images/1326877605/greenavatar_crop_normal.jpg"",""large"":""http://a2.twimg.com/profile_images/1326877605/greenavatar_crop.jpg""},""details"":[],""hashtags"":[],""mentions"":[]},""user"":{""id"":""eae07cd5a5ae4ab5892fa9e4514704d831df4250a7992f28b1aaaa86d1eeb28a"",""screen_name"":""kjnilsson"",""avatar"":{""large"":""http://a0.twimg.com/profile_images/1630177710/BigMeanCarl.jpg"",""small"":""http://a0.twimg.com/profile_images/1630177710/BigMeanCarl_normal.jpg""}},""id"":""9155bd1c2d4e6a589def013c4dd09997add4e85f72fe07e8f6a692b34a1713e5""},{""type"":""follow"",""updated_at"":""2012-01-27T22:24:28.421Z"",""created_at"":""2012-01-27T22:24:28.417Z"",""is_active"":true,""gfk"":{""screen_name"":""kcorwin"",""id"":""a5627b84a5618f124a76f5bd09052b90166cffc27de039440f7d501b71b86485"",""card"":{""skills"":[],""tasks"":[],""contributors"":[]},""avatar"":{""large"":""http://a2.twimg.com/profile_images/1157530215/image.jpg"",""small"":""http://a2.twimg.com/profile_images/1157530215/image_normal.jpg""},""details"":[],""hashtags"":[],""mentions"":[]},""user"":{""id"":""eae07cd5a5ae4ab5892fa9e4514704d831df4250a7992f28b1aaaa86d1eeb28a"",""screen_name"":""kjnilsson"",""avatar"":{""large"":""http://a0.twimg.com/profile_images/1630177710/BigMeanCarl.jpg"",""small"":""http://a0.twimg.com/profile_images/1630177710/BigMeanCarl_normal.jpg""}},""id"":""a78b5c29b22e1e17c75494d70f7a732dfc321bf04b50b47affdf341160e5d8e1""},{""type"":""follow"",""updated_at"":""2012-01-27T22:24:24.877Z"",""created_at"":""2012-01-27T22:24:24.874Z"",""is_active"":true,""gfk"":{""screen_name"":""hemeon"",""id"":""085b805dea94a17aac9cc2fafd97e1ba4867e436bc24a577977635b96ff6dc63"",""card"":{""skills"":[],""tasks"":[],""contributors"":[]},""avatar"":{""small"":""http://a2.twimg.com/profile_images/1598725755/marc_normal.jpg"",""large"":""http://a2.twimg.com/profile_images/1598725755/marc.jpg""},""details"":[],""hashtags"":[],""mentions"":[]},""user"":{""id"":""eae07cd5a5ae4ab5892fa9e4514704d831df4250a7992f28b1aaaa86d1eeb28a"",""screen_name"":""kjnilsson"",""avatar"":{""large"":""http://a0.twimg.com/profile_images/1630177710/BigMeanCarl.jpg"",""small"":""http://a0.twimg.com/profile_images/1630177710/BigMeanCarl_normal.jpg""}},""id"":""6aa4a44e48c42132f0a46d4c60c7d630120fcbf3e4108eab22da63ffea0a67ad""},{""type"":""follow"",""updated_at"":""2012-01-27T22:24:20.967Z"",""created_at"":""2012-01-27T22:24:20.964Z"",""is_active"":true,""gfk"":{""screen_name"":""creationix"",""id"":""aea7ab4769a7732338a5eb33243c9e2ad1e1612ce434bf5a4bf83016a7a41c2a"",""card"":{""skills"":[],""tasks"":[],""contributors"":[]},""avatar"":{""small"":""http://a1.twimg.com/profile_images/774817444/c953ddd239707998340e1a6fbb3eeb46_normal.jpeg"",""large"":""http://a1.twimg.com/profile_images/774817444/c953ddd239707998340e1a6fbb3eeb46.jpeg""},""details"":[],""hashtags"":[],""mentions"":[]},""user"":{""id"":""eae07cd5a5ae4ab5892fa9e4514704d831df4250a7992f28b1aaaa86d1eeb28a"",""screen_name"":""kjnilsson"",""avatar"":{""large"":""http://a0.twimg.com/profile_images/1630177710/BigMeanCarl.jpg"",""small"":""http://a0.twimg.com/profile_images/1630177710/BigMeanCarl_normal.jpg""}},""id"":""8045db581e64d35daa0f7e7146eb052242f58d044a1192a041a1b897bae20af5""}]}";

            var result = TestConstants.DeserializeFromStream<Response<List<Activity>>>(testActivitysJson);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, "ok");
            Assert.AreEqual(result.Data.Count, 10);
        }
        #endregion Activity Serialization Tests
    }
}
