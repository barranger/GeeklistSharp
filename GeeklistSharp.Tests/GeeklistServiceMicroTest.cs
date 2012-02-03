using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}
