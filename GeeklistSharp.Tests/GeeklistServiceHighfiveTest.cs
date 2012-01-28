using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeklistSharp.Tests
{
    /// <summary>
    ///This is a test class for GeeklistServiceHighfiveTest and is intended
    ///to contain all GeeklistServiceHighfiveTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GeeklistServiceHighfiveTest : GeeklistBaseTest
    {
        const string testCardId = "25c31dfce3d67208330a6cb995fc517bc48deda5d63bf6a65b83637cec65f9db";
        const string testMicroId = "c8a1d5e5d41bbcb6d29f6b63b1e9e6526e78ee25a7a0983ec63ff8a4b2275148";

        /// <summary>
        ///A test for ServiceHighfive to Highfive a given Card
        ///</summary>
        [TestMethod]
        public void ServiceHighfiveCardTest()
        {
            var service = GetAuthenticatedService();

            var returnStatus = service.HighfiveItem(testCardId, Service.GeeklistItemType.Card);

            Assert.IsNotNull(returnStatus);
        }

        /// <summary>
        ///A test for ServiceHighfive to Highfive a given Micro
        ///</summary>
        [TestMethod]
        public void ServiceHighfiveMicroTest()
        {
            var service = GetAuthenticatedService();

            var returnStatus = service.HighfiveItem(testMicroId, Service.GeeklistItemType.Micro);

            Assert.IsNotNull(returnStatus);
        }

    }
}
