using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram
{
	public static class UserEndpoint
	{
		public static Task<Envelope<User>> GetUserInfo(this InstagramClient client, string userId)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = String.Concat("/v1/users/", userId);

			return client.HttpGetAsync<Envelope<User>>(path, query);
		}

		public static Task<Envelope<IEnumerable<Media>>> GetMyFeed(this InstagramClient client, int? count = null, string maxId = null, string minId = null)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;
			query["count"] = count.ToString();
			query["min_id"] = minId;
			query["max_id"] = maxId;

			string path = "/v1/users/self/feed";

			return client.HttpGetAsync<Envelope<IEnumerable<Media>>>(path, query);
		}

		public static Task<Envelope<IEnumerable<Media>>> GetRecentMediaForUser(this InstagramClient client, string userId, int? count = null, string maxTimestamp = null, string minTimestamp = null, string maxId = null, string minId = null)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;
			query["count"] = count.ToString();
			query["max_timestamp"] = maxTimestamp;
			query["min_timestamp"] = minTimestamp;
			query["min_id"] = minId;
			query["max_id"] = maxId;

			//Shared params
			var path = String.Concat("/v1/users/", userId, "/media/recent");

			return client.HttpGetAsync<Envelope<IEnumerable<Media>>>(path, query);
		}

		public static Task<Envelope<IEnumerable<Media>>> GetMediaILiked(this InstagramClient client, int? count = null, string maxLikeId = null)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;
			query["count"] = count.ToString();
			query["max_like_id"] = maxLikeId;

			string path = "/v1/users/self/media/liked";

			return client.HttpGetAsync<Envelope<IEnumerable<Media>>>(path, query);
		}

		public static Task<Envelope<IEnumerable<User>>> SearchUsers(this InstagramClient client, string q, int? count = null)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;
			query["q"] = q;
			query["count"] = count.ToString();

			string path = "/v1/users/search";

			return client.HttpGetAsync<Envelope<IEnumerable<User>>>(path, query);
		}
	}
}