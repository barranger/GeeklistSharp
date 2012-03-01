using System;
using System.Collections.Generic;
using System.Linq;
using GeeklistSharp.Model;
using Hammock;
using Hammock.Web;

namespace GeeklistSharp.Service
{
    public partial class GeeklistService
    {
#region GetCurrentUsersCards
        public CardData GetCurrentUsersCards()
        {
            return GetCurrentUsersCards(null, null);
        }

        public void GetCurrentUsersCardsAsync(Action<CardData> callback)
        {
            GetCurrentUsersCardsAsync(callback, null, null);
        }

        public CardData GetCurrentUsersCards(int? page, int? count)
        {
            var request = CreateGetCurrentUsersCardsRestRequest(page, count);

            return api.GetResults<CardData>(request);
        }

        public void GetCurrentUsersCardsAsync(Action<CardData> callback, int? page, int? count)
        {
            var request = CreateGetCurrentUsersCardsRestRequest(page, count);

            api.GetResultsAsync<CardData>(callback, request);
        }

        private RestRequest CreateGetCurrentUsersCardsRestRequest(int? page, int? count)
        {
            var request = api.CreateAuthenticatedRequest("/user/cards");

            if (page.HasValue)
            {
                request.AddParameter("page", page.Value.ToString());
            }
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value.ToString());
            }
            return request;
        }
#endregion GetCurrentUsersCards

#region GetUsersCards
        public CardData GetUsersCards(string userName)
        {
            return GetUsersCards(userName, null, null);
        }

        public void GetUsersCardsAsync(Action<CardData> callback, string userName)
        {
            var request = CreateGetUsersCardsRestRequest(userName, null, null);

            api.GetResultsAsync<CardData>(callback, request);
        }

        public CardData GetUsersCards(string userName, int? page, int? count)
        {
            var request = CreateGetUsersCardsRestRequest(userName, page, count);

            return api.GetResults<CardData>(request);
        }

        public void GetUsersCardsAsync(Action<CardData> callback, string userName, int? page, int? count)
        {
            var request = CreateGetUsersCardsRestRequest(userName, page, count);

            api.GetResultsAsync<CardData>(callback, request);
        }

        private static RestRequest CreateGetUsersCardsRestRequest(string userName, int? page, int? count)
        {
            var request = api.CreateAuthenticatedRequest(string.Format("/users/{0}/cards", userName));

            if (page.HasValue)
            {
                request.AddParameter("page", page.Value.ToString());
            }
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value.ToString());
            }
            return request;
        }
#endregion GetUsersCards

#region GetCard
        public Card GetCard(string id)
        {
            var request = api.CreateAuthenticatedRequest(string.Format("/cards/{0}", id));

            return api.GetResults<Card>(request);
        }

        public void GetCardAsync(Action<Card> callback, string id)
        {
            var request = api.CreateAuthenticatedRequest(string.Format("/cards/{0}", id));

            api.GetResultsAsync<Card>(callback, request);
        }
#endregion GetCard

#region CreateCard
        public Card CreateCard(string headline)
        {
            var request = api.CreateAuthenticatedRequest("/cards", WebMethod.Post);

            request.AddParameter("headline", headline);
            return api.GetResults<Card>(request);
        }

        public void CreateCardAsync(Action<Card> callback, string headline)
        {
            var request = api.CreateAuthenticatedRequest("/cards", WebMethod.Post);

            request.AddParameter("headline", headline);
            api.GetResultsAsync<Card>(callback, request);
        }
#endregion CreateCard
    }
}
