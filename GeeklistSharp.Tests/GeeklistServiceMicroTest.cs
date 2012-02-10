using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class GeeklistServiceMicroTest : GeeklistBaseTest
    {
        private GeeklistService service;

        [TestInitialize]
        public void Setup()
        {
            service = GetAuthenticatedService();
        }

        /// <summary>
        ///A test for ServiceMicros to get the Micros of the current User
        ///</summary>
        [TestMethod]
        public void ServiceGetCurrentUsersMicrosTest()
        {
            var currentUsersMicros = service.GetCurrentUsersMicros();

            Assert.IsNotNull(currentUsersMicros);
        }

        /// <summary>
        ///A test for ServiceMicros to get the Micros of the current User
        ///</summary>
        [TestMethod]
        public void ServiceGetCurrentUsersMicrosPagedTest()
        {
            var currentUsersMicros = service.GetCurrentUsersMicros(1, null);

            Assert.IsNotNull(currentUsersMicros);
        }

        /// <summary>
        ///A test for ServiceMicros to get the Micros of the current User
        ///</summary>
        [TestMethod]
        public void ServiceGetCurrentUsersMicrosCountTest()
        {

            var currentUsersMicros = service.GetCurrentUsersMicros(null, 5);

            Assert.IsNotNull(currentUsersMicros);
        }

        /// <summary>
        ///A test for ServiceMicros to get the Micros of the current User
        ///</summary>
        [TestMethod]
        public void ServiceGetCurrentUsersMicrosPagedCountTest()
        {

            var currentUsersMicros = service.GetCurrentUsersMicros(2, 5);

            Assert.IsNotNull(currentUsersMicros);
        }

        /// <summary>
        ///A test for ServiceMicros for a specific Micro
        ///</summary>
        [TestMethod]
        public void ServiceGetSpecificMicroTest()
        {
            var micro = service.GetMicro(TestConstants.MICROID);

            Assert.IsNotNull(micro);
        }

        /// <summary>
        ///A test for ServiceMicros to create a new Micro
        ///</summary>
        [TestMethod]
        public void ServiceCreateMicroTest()
        {

            var micro = service.CreateMicro("Unit Test Micro" + Guid.NewGuid()) as Micro;

            Assert.IsNotNull(micro);
        }

        /// <summary>
        ///A test for ServiceMicros to create a new Micro
        ///</summary>
        [TestMethod]
        public void ServiceCreateMicroForCardTest()
        {

            var micro = service.CreateMicro("card",TestConstants.CARDID,"Unit Test Micro" + Guid.NewGuid()) as Micro;

            Assert.IsNotNull(micro);
        }

        [TestMethod]
        public void DeserializeMicroTest()
        {
            string returnString =
                "{\"status\":\"ok\",\"data\":{\"status\":\"Unit Test Microe96f2127-7c2e-4936-8904-3ac566c02ae3\",\"slug\":\"2156\",\"permalink\":\"/lsmithmier/micro/2156\",\"trending_hist\":[],\"trending_at\":\"2012-02-10T20:23:03.833Z\",\"updated_at\":\"2012-02-10T20:23:03.872Z\",\"created_at\":\"2012-02-10T20:23:03.833Z\",\"reply\":{\"in_reply_to\":{\"id\":\"9b9ebefba8bc41329e5b865efd9f3124ff2d68f0a8c690ecbac2acd74f2841a7\",\"status\":\"Unit Test Microe96f2127-7c2e-4936-8904-3ac566c02ae3\",\"permalink\":\"/lsmithmier/micro/2156\",\"type\":\"micro\"},\"thread\":{\"id\":\"9b9ebefba8bc41329e5b865efd9f3124ff2d68f0a8c690ecbac2acd74f2841a7\",\"status\":\"Unit Test Microe96f2127-7c2e-4936-8904-3ac566c02ae3\",\"permalink\":\"/lsmithmier/micro/2156\",\"type\":\"micro\"}},\"is_active\":true,\"is_trending\":false,\"hashtags\":[],\"mentions\":[],\"stats\":{\"highfives\":0},\"short_code\":{\"id\":\"9b9ebefba8bc41329e5b865efd9f31247f090b9f9dd763b4662d1bbc5a918ab0\",\"gklst_url\":\"http://gkl.st/ubkXS\"},\"user\":{\"id\":\"e47163371a660b6eca2b7935ec31f058648175377b290fb039229b3a08971890\",\"screen_name\":\"lsmithmier\",\"avatar\":{\"small\":\"http://a2.twimg.com/profile_images/493173238/CSharp2_normal.png\",\"large\":\"http://a2.twimg.com/profile_images/493173238/CSharp2.png\"}},\"id\":\"9b9ebefba8bc41329e5b865efd9f3124ff2d68f0a8c690ecbac2acd74f2841a7\"}}";

        }
    }
}
