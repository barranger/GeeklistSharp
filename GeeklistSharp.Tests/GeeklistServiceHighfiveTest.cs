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
    ///This is a test class for GeeklistServiceHighfiveTest and is intended
    ///to contain all GeeklistServiceHighfiveTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GeeklistServiceHighfiveTest : GeeklistBaseTest
    {
        private GeeklistService service;
        private Card card;
        


        //const string _testCardId = "25c31dfce3d67208330a6cb995fc517bc48deda5d63bf6a65b83637cec65f9db";
        const string _testMicroId = "c8a1d5e5d41bbcb6d29f6b63b1e9e6526e78ee25a7a0983ec63ff8a4b2275148";

        [TestInitialize]
        public void Setup()
        {
            service = GetAuthenticatedService();
            card = (Card)service.CreateCard("Test Card " + Guid.NewGuid());
        }
        /// <summary>
        ///A test for ServiceHighfive to Highfive a given Card
        ///</summary>
        [TestMethod]
        public void ServiceHighfiveCardTest()
        {

            var returnStatus = service.HighfiveItem(card.Id, Service.GeeklistItemType.Card);

            Assert.IsNotNull(returnStatus);
        }

        /// <summary>
        ///A test for ServiceHighfive to Highfive a given Micro
        ///</summary>
        [TestMethod]
        public void ServiceHighfiveMicroTest()
        {
            var returnStatus = service.HighfiveItem(_testMicroId, Service.GeeklistItemType.Micro);

            Assert.IsNotNull(returnStatus);
        }

    }
}
