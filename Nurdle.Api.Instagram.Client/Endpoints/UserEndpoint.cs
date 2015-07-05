using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram.Endpoints
{
	public static class UserEndpoint
	{
		public static Task<Envelope<User>> GetUserInfo(this InstagramClient client, string userId)
		{
			string url = String.Concat(
				"/v1/users/",
				userId,
				"?access_token=",
				client.AccessToken
			);
			return client.GetAsync<Envelope<User>>(url);
		}

		public static Task<Envelope<IEnumerable<Media>>> GetMyFeed(this InstagramClient client, int? count = null, string maxId = null, string minId = null)
		{
			string url = String.Concat(
				"/v1/users/self/feed",
				"?access_token=",
				HttpUtility.UrlEncode(client.AccessToken),
				"&count=",
				count.ToString(),
				"&min_id=",
				HttpUtility.UrlEncode(minId),
				"&max_id=",
				HttpUtility.UrlEncode(maxId)
			);

			return client.GetAsync<Envelope<IEnumerable<Media>>>(url);
		}

		public static Task<Envelope<IEnumerable<Media>>> GetRecentMediaForUser(this InstagramClient client, string userId, int? count = null, string maxTimestamp = null, string minTimestamp = null, string maxId = null, string minId = null)
		{
			string url;

			//Prefer access token, fall back to client
			if (client.AccessToken != null)
				url = String.Concat(
					"?access_token=",
					client.AccessToken
				);
			else
				url = String.Concat(
					"?client_id=",
					client.ClientId
				);

			//Shared params
			url = String.Concat(
				"/v1/users/",
				userId,
				"/media/recent",
				url,
				"&count=",
				count.ToString(),
				"&max_timestamp=",
				HttpUtility.UrlEncode(maxTimestamp),
				"&min_timestamp=",
				HttpUtility.UrlEncode(minTimestamp),
				"&min_id=",
				HttpUtility.UrlEncode(minId),
				"&max_id=",
				HttpUtility.UrlEncode(maxId)
			);

			return client.GetAsync<Envelope<IEnumerable<Media>>>(url);
		}

		public static Task<Envelope<IEnumerable<Media>>> GetMediaILiked(this InstagramClient client, int? count = null, string maxLikeId = null)
		{
			string url = String.Concat(
				"/v1/users/self/media/liked",
				"?access_token=",
				client.AccessToken,
				"&count=",
				count.ToString(),
				"&max_like_id=",
				HttpUtility.UrlEncode(maxLikeId)
			);

			return client.GetAsync<Envelope<IEnumerable<Media>>>(url);
		}

		public static Task<Envelope<IEnumerable<User>>> SearchUsers(this InstagramClient client, string query, int? count = null)
		{
			string url = String.Concat(
				"/v1/users/search",
				"?access_token=",
				client.AccessToken,
				"&q=",
				HttpUtility.UrlEncode(query),
				"&count=",
				count.ToString()
			);

			return client.GetAsync<Envelope<IEnumerable<User>>>(url);
		}
	}
}