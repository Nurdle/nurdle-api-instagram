using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram.Endpoints
{
	public static class TagsEndpoint
	{
		public static Task<Envelope<Tag>> GetTag(this InstagramClient client, string tagName)
		{
			string url = String.Concat(
				"/v1/tags/",
				tagName,
				"?access_token=",
				client.AccessToken
			);
			return client.GetAsync<Envelope<Tag>>(url);
		}

		public static Task<Envelope<IEnumerable<Media>>> GetRecentMediaWithTag(this InstagramClient client, string tagName, int? count = null, string minId = null, string maxId = null)
		{
			string url = String.Concat(
				"/v1/tags/",
				tagName,
				"/media/recent",
				"?access_token=",
				client.AccessToken,
				"&count=",
				count == null ? (string)null : count.ToString(),
				"&min_id=",
				minId == null ? (string)null : HttpUtility.UrlEncode(minId),
				"&max_id=",
				maxId == null ? (string)null : HttpUtility.UrlEncode(maxId)
			);
			return client.GetAsync<Envelope<IEnumerable<Media>>>(url);
		}

		public static Task<Envelope<IEnumerable<Tag>>> SearchTags(this InstagramClient client, string q)
		{
			string url = String.Concat(
				"/v1/tags/search",
				"?access_token=",
				client.AccessToken,
				"&q=",
				HttpUtility.UrlEncode(q)
			);
			return client.GetAsync<Envelope<IEnumerable<Tag>>>(url);
		}
	}
}