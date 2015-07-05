using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram.Endpoints
{
	public static class LikesEndpoint
	{
		public static Task<Envelope<IEnumerable<User>>> GetLikesOnMedia(this InstagramClient client, string mediaId)
		{
			string url = String.Concat(
				"/v1/media/",
				mediaId,
				"/likes",
				"?access_token=",
				client.AccessToken
			);
			return client.GetAsync<Envelope<IEnumerable<User>>>(url);
		}

		public static Task<Envelope<string>> LikeMedia(this InstagramClient client, string mediaId)
		{
			string url = String.Concat(
				"/v1/media/",
				mediaId,
				"/likes",
				"?access_token=",
				client.AccessToken
			);
			return client.PostAsync<Envelope<string>>(url, String.Empty);
		}

		public static Task<Envelope<string>> UnlikeMedia(this InstagramClient client, string mediaId)
		{
			string url = String.Concat(
				"/v1/media/",
				mediaId,
				"/likes",
				"?access_token=",
				client.AccessToken
			);
			return client.DeleteAsync<Envelope<string>>(url);
		}
	}
}