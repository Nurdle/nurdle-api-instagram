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
	public static class TagsEndpoint
	{
		public static Task<Envelope<Tag>> GetTag(this InstagramClient client, string tagName)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = String.Concat("/v1/tags/", tagName);

			return client.HttpGetAsync<Envelope<Tag>>(path, query);
		}

		public static Task<Envelope<IEnumerable<Media>>> GetRecentMediaWithTag(this InstagramClient client, string tagName, int? count = null, string minId = null, string maxId = null)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;
			if(count != null) query["count"] = count.ToString();
			if(minId != null) query["min_id"] = minId;
			if(maxId != null) query["max_id"] = maxId;

			string path = String.Concat("/v1/tags/", tagName, "/media/recent");

			return client.HttpGetAsync<Envelope<IEnumerable<Media>>>(path, query);
		}

		public static Task<Envelope<IEnumerable<Tag>>> SearchTags(this InstagramClient client, string q)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;
			query["q"] = q;

			string path = "/v1/tags/search";

			return client.HttpGetAsync<Envelope<IEnumerable<Tag>>>(path, query);
		}
	}
}