using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeeklistSharp.Service;
using System.Diagnostics;
using GeeklistSharp.Model;
using System.Runtime.Serialization.Json;
using System.IO;

namespace GeeklistSharp.Tests
{
    /// <summary>
    ///This is a test class for GeeklistServiceTest and is intended
    ///to contain all GeeklistServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GeeklistServiceCardTest : GeeklistBaseTest
    {

        /// <summary>
        ///A test for ServiceCards to get the Cards of the current User
        ///</summary>
        [TestMethod]
        public void ServiceGetCurrentUsersCardsTest()
        {
            var service = GetAuthenticatedService();

            var currentUsersCards = service.GetCurrentUsersCards();

            Assert.IsNotNull(currentUsersCards);
        }

        /// <summary>
        ///A test for ServiceCards to get the Cards of the current User
        ///</summary>
        [TestMethod]
        public void ServiceGetCurrentUsersCardsPagedTest()
        {
            var service = GetAuthenticatedService();

            var currentUsersCards = service.GetCurrentUsersCards(1,null);

            Assert.IsNotNull(currentUsersCards);
        }

        /// <summary>
        ///A test for ServiceCards to get the Cards of the current User
        ///</summary>
        [TestMethod]
        public void ServiceGetCurrentUsersCardsCountTest()
        {
            var service = GetAuthenticatedService();

            var currentUsersCards = service.GetCurrentUsersCards(null, 5);

            Assert.IsNotNull(currentUsersCards);
        }

        /// <summary>
        ///A test for ServiceCards to get the Cards of the current User
        ///</summary>
        [TestMethod]
        public void ServiceGetCurrentUsersCardsPagedCountTest()
        {
            var service = GetAuthenticatedService();

            var currentUsersCards = service.GetCurrentUsersCards(2, 5);

            Assert.IsNotNull(currentUsersCards);
        }

        /// <summary>
        ///A test for ServiceCards for a specific Card
        ///</summary>
        [TestMethod]
        public void ServiceGetSpecificCardTest()
        {
            var service = GetAuthenticatedService();

            var card = service.GetCard("146a1bcbe95def14a19a5441cbccb17f5b7b06b25b99396ac906872e584b268a");

            Assert.IsNotNull(card);
        }

        /// <summary>
        ///A test for ServiceCards to create a new card
        ///</summary>
        [TestMethod]
        public void ServiceCreateCardTest()
        {
            var service = GetAuthenticatedService();

            var card = service.CreateCard("Unit Test Card") as Card;

            Assert.IsNotNull(card);
            Assert.AreEqual(card.Headline, "Unit Test Card");
        }

#region Card Serialization Tests
        /// <summary>
        ///A test for deserializing Cards
        ///</summary>
        [TestMethod]
        public void CardsDeserializeTest()
        {
            string testCardsJson = @"{""status"":""ok"",""data"":{""total_cards"":2,""cards"":[{""updated_at"":""2012-01-27T03:01:11.827Z"",""permalink"":""/lsmithmier/test-2-for-c-api-wrapper"",""slug"":""test-2-for-c-api-wrapper"",""author_id"":""e47163371a660b6eca2b7935ec31f058648175377b290fb039229b3a08971890"",""headline"":""Test 2 for C# API Wrapper"",""trending_hist"":[],""trending_at"":""2012-01-27T03:01:11.747Z"",""created_at"":""2012-01-27T03:01:11.747Z"",""is_trending"":false,""is_active"":true,""skills"":[],""tasks"":[],""stats"":{""highfives"":0,""views"":0},""short_code"":{""id"":""146a1bcbe95def14a19a5441cbccb17ffd582bc0b674755f2a5aedfdb7843068"",""gklst_url"":""http://gkl.st/Xcxn4""},""id"":""146a1bcbe95def14a19a5441cbccb17f5b7b06b25b99396ac906872e584b268a""},{""author_id"":""e47163371a660b6eca2b7935ec31f058648175377b290fb039229b3a08971890"",""created_at"":""2012-01-27T03:00:46.413Z"",""headline"":""Test for C# API Wrapper"",""is_active"":true,""is_trending"":false,""permalink"":""/lsmithmier/test-for-c-api-wrapper"",""skills"":[""C#"",""Visual Studio""],""slug"":""test-for-c-api-wrapper"",""tasks"":[""did some test data entry"",""tested the code"",""built some more code""],""trending_at"":""2012-01-27T03:00:46.413Z"",""trending_hist"":[],""updated_at"":""2012-01-27T03:49:43.128Z"",""stats"":{""highfives"":0,""views"":0},""short_code"":{""id"":""a55109fad7c9b6a330099bf9d48e13ecfcc688b8dce7a67cf61f56155b66ab71"",""gklst_url"":""http://gkl.st/J1h-i""},""id"":""a55109fad7c9b6a330099bf9d48e13ece0cedf364a511b3b1a06e749a2ab8e1f""}]}}";
            var serializer = new DataContractJsonSerializer(typeof(Response<CardData>));

            MemoryStream memoryStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(testCardsJson));

            var result = serializer.ReadObject(memoryStream) as Response<CardData>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, "ok");
            Assert.AreEqual(result.Data.TotalCards, 2);
        }

        /// <summary>
        ///A test for deserializing CardData
        ///</summary>
        [TestMethod]
        public void CardDataDeserializeTest()
        {
            string testCardDataJson = @"{""total_cards"":2,""cards"":[{""updated_at"":""2012-01-27T03:01:11.827Z"",""permalink"":""/lsmithmier/test-2-for-c-api-wrapper"",""slug"":""test-2-for-c-api-wrapper"",""author_id"":""e47163371a660b6eca2b7935ec31f058648175377b290fb039229b3a08971890"",""headline"":""Test 2 for C# API Wrapper"",""trending_hist"":[],""trending_at"":""2012-01-27T03:01:11.747Z"",""created_at"":""2012-01-27T03:01:11.747Z"",""is_trending"":false,""is_active"":true,""skills"":[],""tasks"":[],""stats"":{""highfives"":0,""views"":0},""short_code"":{""id"":""146a1bcbe95def14a19a5441cbccb17ffd582bc0b674755f2a5aedfdb7843068"",""gklst_url"":""http://gkl.st/Xcxn4""},""id"":""146a1bcbe95def14a19a5441cbccb17f5b7b06b25b99396ac906872e584b268a""},{""author_id"":""e47163371a660b6eca2b7935ec31f058648175377b290fb039229b3a08971890"",""created_at"":""2012-01-27T03:00:46.413Z"",""headline"":""Test for C# API Wrapper"",""is_active"":true,""is_trending"":false,""permalink"":""/lsmithmier/test-for-c-api-wrapper"",""skills"":[""C#"",""Visual Studio""],""slug"":""test-for-c-api-wrapper"",""tasks"":[""did some test data entry"",""tested the code"",""built some more code""],""trending_at"":""2012-01-27T03:00:46.413Z"",""trending_hist"":[],""updated_at"":""2012-01-27T03:49:43.128Z"",""stats"":{""highfives"":0,""views"":0},""short_code"":{""id"":""a55109fad7c9b6a330099bf9d48e13ecfcc688b8dce7a67cf61f56155b66ab71"",""gklst_url"":""http://gkl.st/J1h-i""},""id"":""a55109fad7c9b6a330099bf9d48e13ece0cedf364a511b3b1a06e749a2ab8e1f""}]}";
            var serializer = new DataContractJsonSerializer(typeof(CardData));

            MemoryStream memoryStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(testCardDataJson));

            var result = serializer.ReadObject(memoryStream) as CardData;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Cards[0].UpdatedAt, "2012-01-27T03:01:11.827Z");
            Assert.AreEqual(result.Cards[0].Permalink, "/lsmithmier/test-2-for-c-api-wrapper");
            Assert.AreEqual(result.Cards[0].Slug, "test-2-for-c-api-wrapper");
            Assert.AreEqual(result.Cards[0].AuthorId, "e47163371a660b6eca2b7935ec31f058648175377b290fb039229b3a08971890");
            Assert.AreEqual(result.Cards[0].Headline, "Test 2 for C# API Wrapper");
            Assert.AreEqual(result.Cards[0].TrendingHist.Count, 0);
            Assert.AreEqual(result.Cards[0].TrendingAt, "2012-01-27T03:01:11.747Z");
            Assert.AreEqual(result.Cards[0].CreatedAt, "2012-01-27T03:01:11.747Z");
            Assert.AreEqual(result.Cards[0].IsTrending, false);
            Assert.AreEqual(result.Cards[0].IsActive, true);
            Assert.AreEqual(result.Cards[0].Skills.Count, 0);
            Assert.AreEqual(result.Cards[0].Tasks.Count, 0);
            Assert.AreEqual(result.Cards[0].Stats.HighFives, 0);
            Assert.AreEqual(result.Cards[0].Stats.Views, 0);
            Assert.AreEqual(result.Cards[0].Id, "146a1bcbe95def14a19a5441cbccb17f5b7b06b25b99396ac906872e584b268a");
            Assert.AreEqual(result.Cards[0].ShortCode.Id, "146a1bcbe95def14a19a5441cbccb17ffd582bc0b674755f2a5aedfdb7843068");
            Assert.AreEqual(result.Cards[0].ShortCode.GklstUrl, "http://gkl.st/Xcxn4");
        }

        /// <summary>
        ///A test for deserializing Card
        ///</summary>
        [TestMethod]
        public void CardDeserializeTest()
        {
            string testCardJson = @"{""updated_at"":""2012-01-27T03:01:11.827Z"",""permalink"":""/lsmithmier/test-2-for-c-api-wrapper"",""slug"":""test-2-for-c-api-wrapper"",""author_id"":""e47163371a660b6eca2b7935ec31f058648175377b290fb039229b3a08971890"",""headline"":""Test 2 for C# API Wrapper"",""trending_hist"":[],""trending_at"":""2012-01-27T03:01:11.747Z"",""created_at"":""2012-01-27T03:01:11.747Z"",""is_trending"":false,""is_active"":true,""skills"":[],""tasks"":[],""stats"":{""highfives"":0,""views"":0},""short_code"":{""id"":""146a1bcbe95def14a19a5441cbccb17ffd582bc0b674755f2a5aedfdb7843068"",""gklst_url"":""http://gkl.st/Xcxn4""},""id"":""146a1bcbe95def14a19a5441cbccb17f5b7b06b25b99396ac906872e584b268a""}";
            var serializer = new DataContractJsonSerializer(typeof(Card));

            MemoryStream memoryStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(testCardJson));

            var result = serializer.ReadObject(memoryStream) as Card;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.UpdatedAt, "2012-01-27T03:01:11.827Z");
            Assert.AreEqual(result.Permalink, "/lsmithmier/test-2-for-c-api-wrapper");
            Assert.AreEqual(result.Slug, "test-2-for-c-api-wrapper");
            Assert.AreEqual(result.AuthorId, "e47163371a660b6eca2b7935ec31f058648175377b290fb039229b3a08971890");
            Assert.AreEqual(result.Headline, "Test 2 for C# API Wrapper");
            Assert.AreEqual(result.TrendingHist.Count, 0);
            Assert.AreEqual(result.TrendingAt, "2012-01-27T03:01:11.747Z");
            Assert.AreEqual(result.CreatedAt, "2012-01-27T03:01:11.747Z");
            Assert.AreEqual(result.IsTrending, false);
            Assert.AreEqual(result.IsActive, true);
            Assert.AreEqual(result.Skills.Count, 0);
            Assert.AreEqual(result.Tasks.Count, 0);
            Assert.AreEqual(result.Stats.HighFives, 0);
            Assert.AreEqual(result.Stats.Views, 0);
            Assert.AreEqual(result.Id, "146a1bcbe95def14a19a5441cbccb17f5b7b06b25b99396ac906872e584b268a");
            Assert.AreEqual(result.ShortCode.Id, "146a1bcbe95def14a19a5441cbccb17ffd582bc0b674755f2a5aedfdb7843068");
            Assert.AreEqual(result.ShortCode.GklstUrl, "http://gkl.st/Xcxn4");
        }

        /// <summary>
        ///A test for deserializing Stats
        ///</summary>
        [TestMethod]
        public void StatsDeserializeTest()
        {
            string testStatsJson = @"{""number_of_highfives"":2,""views"":5}";
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Stats));

            MemoryStream memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(testStatsJson));

            Stats result = serializer.ReadObject(memoryStream) as Stats;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.HighFives, 2);
            Assert.AreEqual(result.Views, 5);
        }

        /// <summary>
        ///A test for deserializing ShortCode
        ///</summary>
        [TestMethod]
        public void ShortCodeDeserializeTest()
        {
            string testShortCodeJson = @"{""id"":""146a1bcbe95def14a19a5441cbccb17ffd582bc0b674755f2a5aedfdb7843068"",""gklst_url"":""http://gkl.st/Xcxn4""}";
            var serializer = new DataContractJsonSerializer(typeof(ShortCode));

            MemoryStream memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(testShortCodeJson));

            var result = serializer.ReadObject(memoryStream) as ShortCode;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, "146a1bcbe95def14a19a5441cbccb17ffd582bc0b674755f2a5aedfdb7843068");
            Assert.AreEqual(result.GklstUrl, "http://gkl.st/Xcxn4");
        }
#endregion Card Serialization Tests
    }
}
