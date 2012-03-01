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
    public class GeeklistServiceMicroTest : GeeklistBaseTest
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
        ///A test for ServiceMicros to get the Micros of the current User
        ///</summary>
        [TestMethod]
        public void GetCurrentUsersMicrosTest()
        {
            MicroData currentUsersMicros = service.GetCurrentUsersMicros();

            Assert.IsNotNull(currentUsersMicros);
        }

        /// <summary>
        ///A test for ServiceMicros to get the Micros of the current User
        ///</summary>
        [TestMethod]
        public void GetCurrentUsersMicrosAsyncTest()
        {
            MicroData currentUsersMicros = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.GetCurrentUsersMicrosAsync((cm) =>
            {
                currentUsersMicros = cm;
                waitHandle.Set();
            });

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(currentUsersMicros);
        }

        /// <summary>
        ///A test for ServiceMicros to get the Micros of the current User
        ///</summary>
        [TestMethod]
        public void GetCurrentUsersMicrosPagedTest()
        {
            MicroData currentUsersMicros = service.GetCurrentUsersMicros(1, null);

            Assert.IsNotNull(currentUsersMicros);
        }

        /// <summary>
        ///A test for ServiceMicros to get the Micros of the current User
        ///</summary>
        [TestMethod]
        public void GetCurrentUsersMicrosAsyncPagedTest()
        {
            MicroData currentUsersMicros = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.GetCurrentUsersMicrosAsync((cm) =>
            {
                currentUsersMicros = cm;
                waitHandle.Set();
            }, 1, null);

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(currentUsersMicros);
        }

        /// <summary>
        ///A test for ServiceMicros to get the Micros of the current User
        ///</summary>
        [TestMethod]
        public void GetCurrentUsersMicrosCountTest()
        {
            MicroData currentUsersMicros = service.GetCurrentUsersMicros(null, 5);

            Assert.IsNotNull(currentUsersMicros);
        }

        /// <summary>
        ///A test for ServiceMicros to get the Micros of the current User
        ///</summary>
        [TestMethod]
        public void GetCurrentUsersMicrosAsyncCountTest()
        {
            MicroData currentUsersMicros = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.GetCurrentUsersMicrosAsync((cm) =>
            {
                currentUsersMicros = cm;
                waitHandle.Set();
            }, null, 5);

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(currentUsersMicros);
        }

        /// <summary>
        ///A test for ServiceMicros to get the Micros of the current User
        ///</summary>
        [TestMethod]
        public void GetCurrentUsersMicrosPagedCountTest()
        {
            MicroData currentUsersMicros = service.GetCurrentUsersMicros(2, 5);

            Assert.IsNotNull(currentUsersMicros);
        }

        /// <summary>
        ///A test for ServiceMicros to get the Micros of the current User
        ///</summary>
        [TestMethod]
        public void GetCurrentUsersMicrosAsyncPagedCountTest()
        {
            MicroData currentUsersMicros = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.GetCurrentUsersMicrosAsync((cm) =>
            {
                currentUsersMicros = cm;
                waitHandle.Set();
            }, 2, 5);

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(currentUsersMicros);
        }

        /// <summary>
        ///A test for ServiceMicros for a specific Micro
        ///</summary>
        [TestMethod]
        public void GetMicroTest()
        {
            Micro micro = service.GetMicro(unitTestMicro.Id);

            Assert.IsNotNull(micro);
            Assert.Equals(micro.Id, unitTestMicro.Id);
        }

        /// <summary>
        ///A test for ServiceMicros for a specific Micro
        ///</summary>
        [TestMethod]
        public void GetMicroAsyncTest()
        {
            Micro micro = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.GetMicroAsync((m) =>
            {
                micro = m;
                waitHandle.Set();
            }, unitTestMicro.Id);

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(micro);
            Assert.Equals(micro.Id, unitTestMicro.Id);
        }

        /// <summary>
        ///A test for ServiceMicros to create a new Micro
        ///</summary>
        [TestMethod]
        public void CreateMicroTest()
        {
            Micro micro = service.CreateMicro("Unit Test Micro" + Guid.NewGuid());

            Assert.IsNotNull(micro);
        }

        /// <summary>
        ///A test for ServiceMicros to create a new Micro
        ///</summary>
        [TestMethod]
        public void CreateMicroAsyncTest()
        {
            Micro micro = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.CreateMicroAsync((m) =>
            {
                micro = m;
                waitHandle.Set();
            }, string.Format("{0} Unit Test Micro", DateTime.Now.Ticks));

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(micro);
        }

        /// <summary>
        ///A test for ServiceMicros to create a new Micro
        ///</summary>
        [TestMethod]
        public void CreateMicroCardTest()
        {
            Micro micro = service.CreateMicro("card", unitTestCard.Id, "Unit Test Micro" + Guid.NewGuid());

            Assert.IsNotNull(micro);
        }

        /// <summary>
        ///A test for ServiceMicros to create a new Micro
        ///</summary>
        [TestMethod]
        public void CreateMicroAsyncCardTest()
        {
            Micro micro = null;

            AutoResetEvent waitHandle = new AutoResetEvent(false);

            service.CreateMicroAsync((m) =>
            {
                micro = m;
                waitHandle.Set();
            }, "card", unitTestCard.Id, "Unit Test Micro" + Guid.NewGuid());

            if (!waitHandle.WaitOne(5000, false))
            {
                Assert.Fail("Test timed out.");
            }

            Assert.IsNotNull(micro);
        }

#region Micro Serialization Tests
        [TestMethod]
        public void DeserializeMicroTest()
        {
            //string returnString =
            //    "{\"status\":\"ok\",\"data\":{\"status\":\"Unit Test Microe96f2127-7c2e-4936-8904-3ac566c02ae3\",\"slug\":\"2156\",\"permalink\":\"/lsmithmier/micro/2156\",\"trending_hist\":[],\"trending_at\":\"2012-02-10T20:23:03.833Z\",\"updated_at\":\"2012-02-10T20:23:03.872Z\",\"created_at\":\"2012-02-10T20:23:03.833Z\",\"reply\":{\"in_reply_to\":{\"id\":\"9b9ebefba8bc41329e5b865efd9f3124ff2d68f0a8c690ecbac2acd74f2841a7\",\"status\":\"Unit Test Microe96f2127-7c2e-4936-8904-3ac566c02ae3\",\"permalink\":\"/lsmithmier/micro/2156\",\"type\":\"micro\"},\"thread\":{\"id\":\"9b9ebefba8bc41329e5b865efd9f3124ff2d68f0a8c690ecbac2acd74f2841a7\",\"status\":\"Unit Test Microe96f2127-7c2e-4936-8904-3ac566c02ae3\",\"permalink\":\"/lsmithmier/micro/2156\",\"type\":\"micro\"}},\"is_active\":true,\"is_trending\":false,\"hashtags\":[],\"mentions\":[],\"stats\":{\"highfives\":0},\"short_code\":{\"id\":\"9b9ebefba8bc41329e5b865efd9f31247f090b9f9dd763b4662d1bbc5a918ab0\",\"gklst_url\":\"http://gkl.st/ubkXS\"},\"user\":{\"id\":\"e47163371a660b6eca2b7935ec31f058648175377b290fb039229b3a08971890\",\"screen_name\":\"lsmithmier\",\"avatar\":{\"small\":\"http://a2.twimg.com/profile_images/493173238/CSharp2_normal.png\",\"large\":\"http://a2.twimg.com/profile_images/493173238/CSharp2.png\"}},\"id\":\"9b9ebefba8bc41329e5b865efd9f3124ff2d68f0a8c690ecbac2acd74f2841a7\"}}";
            Assert.Inconclusive("deserialization not tested");
        }
#endregion Micro Serialization Tests
    }
}
