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
	public static class LikesApi
	{
		public static Task<Envelope<IEnumerable<User>>> GetLikesOnMedia(this InstagramClient client, string mediaId)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = String.Concat("/v1/media/", mediaId, "/likes");
			
			return client.HttpGetAsync<Envelope<IEnumerable<User>>>(path, query);
		}

		public static Task<Envelope<string>> LikeMedia(this InstagramClient client, string mediaId)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = String.Concat("/v1/media/", mediaId, "/likes");

			return client.HttpPostAsync<Envelope<string>>(path, query, null);
		}

		public static Task<Envelope<string>> UnlikeMedia(this InstagramClient client, string mediaId)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = String.Concat( "/v1/media/", mediaId, "/likes");

			return client.HttpDeleteAsync<Envelope<string>>(path, query);
		}
	}
}