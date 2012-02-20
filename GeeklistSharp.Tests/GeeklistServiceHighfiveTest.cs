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

        [TestInitialize]
        public void Setup()
        {
            service = GetAuthenticatedService();
        }

        /// <summary>
        ///A test for ServiceHighfive to Highfive a given Card
        ///</summary>
        [TestMethod]
        public void HighfiveItemCardTest()
        {
            try
            {
                var returnStatus = service.HighfiveItem(TestConstants.CARDID, Service.GeeklistItemType.Card);
                Assert.IsNotNull(returnStatus);
            }
            catch (GeekListException gle)
            {
                Assert.AreEqual("Duplicate!", gle.Error);
            }
        }

        /// <summary>
        ///A test for ServiceHighfive to Highfive a given Micro
        ///</summary>
        [TestMethod]
        public void HighfiveItemMicroTest()
        {
            try
            {
                var returnStatus = service.HighfiveItem(TestConstants.MICROID, Service.GeeklistItemType.Micro);
                Assert.IsNotNull(returnStatus);
            }
            catch (GeekListException gle)
            {
                Assert.AreEqual("Duplicate!", gle.Error);
            }
        }

    }
}

