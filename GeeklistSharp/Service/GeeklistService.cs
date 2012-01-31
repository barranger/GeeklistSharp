using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Hammock;
using Hammock.Authentication.OAuth;
using Hammock.Web;
using System.Compat.Web;
using GeeklistSharp.Model;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Diagnostics;

namespace GeeklistSharp.Service
{
	public class GeeklistService
	{
		private static string _consumerKey;
		private static string _consumerSecret;
		private static string _callback;

		private static string _token;
		private static string _tokenSecret;

		private readonly RestClient _oauth;

		public GeeklistService(string consumerKey, string consumerSecret, string callback = "oob")
		{
			_consumerKey = consumerKey;
			_consumerSecret = consumerSecret;
			_callback = callback;

			_oauth = new RestClient
						{
							Authority = Globals.RestAPIAuthority,
							VersionPath = "v1",
							UserAgent = "GeeklistSharp",
						};
		}

		public OAuthRequestToken GetRequestToken()
		{

			var request = new RestRequest
			{
				Credentials = new OAuthCredentials
				{
					ConsumerKey = _consumerKey,
					ConsumerSecret = _consumerSecret,
					SignatureMethod = OAuthSignatureMethod.HmacSha1,
					CallbackUrl = _callback,
					Type = OAuthType.RequestToken
				},
				Method = WebMethod.Get,
				Path = "/oauth/request_token"
			};

			var response = _oauth.Request(request);

			var query = HttpUtility.ParseQueryString(response.Content);
			var oauth = new OAuthRequestToken
			{
				Token = query["oauth_token"] ?? "?",
				TokenSecret = query["oauth_token_secret"] ?? "?"
			};

			return oauth;
		}

		public Uri GetAuthorizationUrl(string token)
		{
			return new Uri("http://sandbox.geekli.st/oauth/authorize?oauth_token=" + token);
		}

		public OAuthAccessToken GetAccessToken(OAuthRequestToken requestToken, string verifyer)
		{
			var request = new RestRequest
			{
				Credentials = new OAuthCredentials
				{
					ConsumerKey = _consumerKey,
					ConsumerSecret = _consumerSecret,
					SignatureMethod = OAuthSignatureMethod.HmacSha1,
					Token = requestToken.Token,
					TokenSecret = requestToken.TokenSecret,
					Verifier = verifyer,
					Type = OAuthType.AccessToken
				},
				Method = WebMethod.Get,
				Path = "/oauth/access_token"
			};

			var response = _oauth.Request(request);

			var query = HttpUtility.ParseQueryString(response.Content);
			var oauth = new OAuthAccessToken
			{
				Token = query["oauth_token"] ?? "?",
				TokenSecret = query["oauth_token_secret"] ?? "?"
			};

			return oauth;
		}

		public void AuthenticateWith(string token, string tokenSecret)
		{
			_token = token;
			_tokenSecret = tokenSecret;
		}

		public User GetUser(string name = null)
		{
			var path = name == null ? "/user" : "/users/" + name;
			var request = new RestRequest
			{
				Credentials = new OAuthCredentials
				{
					ConsumerKey = _consumerKey,
					ConsumerSecret = _consumerSecret,
					SignatureMethod = OAuthSignatureMethod.HmacSha1,
					Token = _token,
					TokenSecret = _tokenSecret,
					Type = OAuthType.ProtectedResource
				},
				Method = WebMethod.Get,
				Path = path
			};

			var response = _oauth.Request(request);

			var result = GetResponse<User>(response.ContentStream);

			if (result.Status != "ok")
			{
				throw new GeekListException(result.Status, result.Error);
			}

			return result.Data;
		}
		
#region Cards

		public object GetCurrentUsersCards()
		{
			return GetCurrentUsersCards(null,null);
		}

		public object GetCurrentUsersCards(int? page,int? count)
		{
			var request = new RestRequest
			{
				Credentials = new OAuthCredentials
				{
					ConsumerKey = _consumerKey,
					ConsumerSecret = _consumerSecret,
					SignatureMethod = OAuthSignatureMethod.HmacSha1,
					Token = _token,
					TokenSecret = _tokenSecret,
					Type = OAuthType.ProtectedResource
				},
				Method = WebMethod.Get,
				Path = "/user/cards"
			};

			if (page.HasValue)
			{
				request.AddParameter("page",page.Value.ToString());
			}
			if (count.HasValue)
			{
				request.AddParameter("count", count.Value.ToString());
			}

			var response = _oauth.Request(request);

			var result = GetResponse<CardData>(response.ContentStream);

			if (result.Status != "ok")
			{
				throw new GeekListException(result.Status, result.Error);
			}

			return result.Data;
		}

		public object GetUsersCards(string userName)
		{
			return GetUsersCards(userName, null, null);
		}

		public object GetUsersCards(string userName, int? page, int? count)
		{
			var request = new RestRequest
			{
				Credentials = new OAuthCredentials
				{
					ConsumerKey = _consumerKey,
					ConsumerSecret = _consumerSecret,
					SignatureMethod = OAuthSignatureMethod.HmacSha1,
					Token = _token,
					TokenSecret = _tokenSecret,
					Type = OAuthType.ProtectedResource
				},
				Method = WebMethod.Get,
				Path = string.Format("/users/{0}/cards", userName)
			};

			if (page.HasValue)
			{
				request.AddParameter("page", page.Value.ToString());
			}
			if (count.HasValue)
			{
				request.AddParameter("count", count.Value.ToString());
			}

			var response = _oauth.Request(request);

			var result = GetResponse<CardData>(response.ContentStream);

			if (result.Status != "ok")
			{
				throw new GeekListException(result.Status, result.Error);
			}

			return result.Data;
		}

		public object GetCard(string id)
		{
			var request = new RestRequest
			{
				Credentials = new OAuthCredentials
				{
					ConsumerKey = _consumerKey,
					ConsumerSecret = _consumerSecret,
					SignatureMethod = OAuthSignatureMethod.HmacSha1,
					Token = _token,
					TokenSecret = _tokenSecret,
					Type = OAuthType.ProtectedResource
				},
				Method = WebMethod.Get,
				Path = string.Format("/cards/{0}", id)
			};

			var response = _oauth.Request(request);
		    
            try
            {
                var result = GetResponse<Card>(response.ContentStream);

                if (result.Status != "ok")
                {
                    throw new GeekListException(result.Status, result.Error);
                }

                return result.Data;
            }
            catch (SerializationException err)
            {
                string s = String.Empty;
                //var result = GetResponse<Erro>()
                //throw new GeekListException(resu);
            }
		    return null;
		}

		public object CreateCard(string headline)
		{
			var request = new RestRequest
			{
				Credentials = new OAuthCredentials
				{
					ConsumerKey = _consumerKey,
					ConsumerSecret = _consumerSecret,
					SignatureMethod = OAuthSignatureMethod.HmacSha1,
					Token = _token,
					TokenSecret = _tokenSecret,
					Type = OAuthType.ProtectedResource
				},
				Method = WebMethod.Post,
				Path = "/cards"
			};

			request.AddParameter("headline", headline);
			var response = _oauth.Request(request);

			var result = GetResponse<Card>(response.ContentStream);

			if (result.Status != "ok")
			{
				throw new GeekListException(result.Status, result.Error);
			}

			return result.Data;
		}

#endregion Cards

#region Followers

		public FollowersData GetFollowers()
		{
			return GetFollowers(null);
		}

		public FollowersData GetFollowers(string user)
		{
			return GetFollowers(user, 1, 10);
		}

		public FollowersData GetFollowers(string user, int page, int pageSize)
		{
			var path = string.IsNullOrEmpty(user) ? "/user/followers" : string.Format("/users/{0}/followers", user);

			var request = GetRequest(path);

			request.AddParameter("page", page.ToString());

			request.AddParameter("count", pageSize.ToString());

			var response = _oauth.Request(request);

			var result = GetResponse<FollowersData>(response.ContentStream);

			EnsureResponseOk(result);

			result.Data.PageNumber = page;
			result.Data.PageSize = pageSize;

			return result.Data;
		}

		public FollowingData GetFollowing()
		{
			return GetFollowing(null);
		}

		public FollowingData GetFollowing(string user)
		{
			return GetFollowing(user, 1, 10);
		}

		public FollowingData GetFollowing(string user, int page, int pageSize)
		{
			var path = string.IsNullOrEmpty(user) ? "/user/following" : string.Format("/users/{0}/following", user);

			var request = GetRequest(path);

			request.AddParameter("page", page.ToString());

			request.AddParameter("count", pageSize.ToString());
			
			var response = _oauth.Request(request);
			
			var result = GetResponse<FollowingData>(response.ContentStream);

			EnsureResponseOk(result);

			result.Data.PageNumber = page;
			result.Data.PageSize = pageSize;

			return result.Data;
		}
		
		protected virtual Response<T> GetResponse<T>(Stream jsonStream)
			where T : new()
		{
			var serializer = new DataContractJsonSerializer(typeof(Response<T>));

			var result = (Response<T>)serializer.ReadObject(jsonStream);

			return result;
		}

		public void FollowUser(string userId)
		{
			var request = PostRequest("/follow");

			request.AddParameter("user", userId);
			request.AddParameter("action", "follow");

			var response = _oauth.Request(request);

			var result = GetResponse<object>(response.ContentStream);

			EnsureResponseOk(result);
			
		}

		public void UnFollowUser(string userId)
		{
			var request = PostRequest("/follow");

			request.AddParameter("user", userId);
			
			var response = _oauth.Request(request);

			var result = GetResponse<object>(response.ContentStream);

			EnsureResponseOk(result);

		}
#endregion followers
		private static void EnsureResponseOk<T>(Response<T> result)
		{
			if (result.Status != "ok")
			{
				throw new GeekListException(result.Status, result.Error);
			}
		}

		private static RestRequest PostRequest(string path)
		{
			var request = new RestRequest
			{
				Credentials = new OAuthCredentials
				{
					ConsumerKey = _consumerKey,
					ConsumerSecret = _consumerSecret,
					SignatureMethod = OAuthSignatureMethod.HmacSha1,
					Token = _token,
					TokenSecret = _tokenSecret,
					Type = OAuthType.ProtectedResource
				},
				Method = WebMethod.Post,
				Path = path
			};

			return request;
		}

		private static RestRequest GetRequest(string path)
		{
			var request = new RestRequest
			{
				Credentials = new OAuthCredentials
				{
					ConsumerKey = _consumerKey,
					ConsumerSecret = _consumerSecret,
					SignatureMethod = OAuthSignatureMethod.HmacSha1,
					Token = _token,
					TokenSecret = _tokenSecret,
					Type = OAuthType.ProtectedResource
				},
				Method = WebMethod.Get,
				Path = path
			};

			return request;
		}
		
		#region Activity
		public object GetCurrentUsersActivities()
		{
			return GetCurrentUsersActivities(null, null);
		}

		public object GetCurrentUsersActivities(int? page, int? count)
		{
			var request = new RestRequest
			{
				Credentials = new OAuthCredentials
				{
					ConsumerKey = _consumerKey,
					ConsumerSecret = _consumerSecret,
					SignatureMethod = OAuthSignatureMethod.HmacSha1,
					Token = _token,
					TokenSecret = _tokenSecret,
					Type = OAuthType.ProtectedResource
				},
				Method = WebMethod.Get,
				Path = "/user/activity"
			};

			if (page.HasValue)
			{
				request.AddParameter("page", page.Value.ToString());
			}
			if (count.HasValue)
			{
				request.AddParameter("count", count.Value.ToString());
			}

			var response = _oauth.Request(request);

			var result = GetResponse<CardData>(response.ContentStream);

			if (result.Status != "ok")
			{
				throw new GeekListException(result.Status, result.Error);
			}
			return result.Data;
		}

		public object GetUsersActivities(string userName)
		{
			return GetUsersActivities(userName, null, null);
		}

		public object GetUsersActivities(string userName, int? page, int? count)
		{
			var request = new RestRequest
			{
				Credentials = new OAuthCredentials
				{
					ConsumerKey = _consumerKey,
					ConsumerSecret = _consumerSecret,
					SignatureMethod = OAuthSignatureMethod.HmacSha1,
					Token = _token,
					TokenSecret = _tokenSecret,
					Type = OAuthType.ProtectedResource
				},
				Method = WebMethod.Get,
				Path = string.Format("/users/{0}/activity", userName)
			};

			if (page.HasValue)
			{
				request.AddParameter("page", page.Value.ToString());
			}
			if (count.HasValue)
			{
				request.AddParameter("count", count.Value.ToString());
			}

			var response = _oauth.Request(request);

			var result = GetResponse<List<Activity>>(response.ContentStream);

			if (result.Status != "ok")
			{
				throw new GeekListException(result.Status, result.Error);
			}

			return result.Data;
		}       
		public object GetAllActivities()
		{
			return GetAllActivities(null, null);
		}

		public object GetAllActivities(int? page, int? count)
		{
			var request = GetRequest("/activity");

			if (page.HasValue)
			{
				request.AddParameter("page", page.Value.ToString());
			}
			if (count.HasValue)
			{
				request.AddParameter("count", count.Value.ToString());
			}

			var response = _oauth.Request(request);

			var result = GetResponse<List<Activity>>(response.ContentStream);

			if (result.Status != "ok")
			{
				throw new GeekListException(result.Status, result.Error);
			}

			return result.Data;
		}
		#endregion

		#region HighFive
		public object HighfiveItem(string id, string type)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException("Invalid id","id");
			}

            var request = PostRequest("/highfive");
			  
			string typeParameter;
			switch(type){
				case GeeklistItemType.Micro:
					typeParameter="micro";
					break;
				case GeeklistItemType.Card:
				default:
					typeParameter="card";
					break;
			}

			request.AddParameter("type", typeParameter);

			request.AddParameter("gfk", id);
			var response = _oauth.Request(request);

			var result = GetResponse<Card>(response.ContentStream);

			if (result.Status != "ok")
			{
				throw new GeekListException(result.Status, result.Error);

			}
			return result.Data;
		}
#endregion
	}
}
