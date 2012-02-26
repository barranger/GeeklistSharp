using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        ///A test for ServiceHighfive to Highfive a given Card
        ///</summary>
        [TestMethod]
        public void HighfiveItemCardTest()
        {
            try
            {
                var returnStatus = service.HighfiveItem(unitTestCard.Id, Service.GeeklistItemType.Card);
                Assert.IsNotNull(returnStatus);
            }
            catch (GeekListException gle)
            {
                Assert.AreEqual("Duplicate!", gle.Error);
            }
        }

        /// <summary>
        ///A test for ServiceHighfive to Highfive a given Card
        ///</summary>
        [TestMethod]
        public void HighfiveItemAsyncCardTest()
        {
            try
            {
                object returnStatus = null;
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                service.HighfiveItemAsync((rs) =>
                {
                    returnStatus = rs;
                    waitHandle.Set();
                }, unitTestCard.Id, Service.GeeklistItemType.Card);
                
                if (!waitHandle.WaitOne(5000, false))
                {
                    Assert.Fail("Test timed out.");
                }

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
                var returnStatus = service.HighfiveItem(unitTestMicro.Id, Service.GeeklistItemType.Micro);
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
        public void HighfiveItemAsyncMicroTest()
        {
            try
            {
                object returnStatus = null;
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                service.HighfiveItemAsync((rs) =>
                {
                    returnStatus = rs;
                    waitHandle.Set();
                }, unitTestMicro.Id, Service.GeeklistItemType.Micro);

                if (!waitHandle.WaitOne(5000, false))
                {
                    Assert.Fail("Test timed out.");
                }

                Assert.IsNotNull(returnStatus);
            }
            catch (GeekListException gle)
            {
                Assert.AreEqual("Duplicate!", gle.Error);
            }
        }
    }
}

