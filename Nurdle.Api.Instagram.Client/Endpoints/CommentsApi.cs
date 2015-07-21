using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;

using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram
{
	public static class CommentsApi
	{
		public static Task<Envelope<IEnumerable<Comment>>> GetCommentsOnMedia(this InstagramClient client, string mediaId)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			var path = String.Concat("/v1/media/", mediaId, "/comments");

			return client.HttpGetAsync<Envelope<IEnumerable<Comment>>>(path, query);
		}

		public static void MakeCommentOnMedia(this InstagramClient client)
		{
			throw new NotImplementedException();
		}

		public static void RemoveCommentOnMedia(this InstagramClient client)
		{
			throw new NotImplementedException();
		}
	}
}