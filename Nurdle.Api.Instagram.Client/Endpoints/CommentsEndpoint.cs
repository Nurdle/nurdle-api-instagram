using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram.Endpoints
{
	public static class CommentsEndpoint
	{
		public static Task<Envelope<IEnumerable<Comment>>> GetCommentsOnMedia(this InstagramClient client, string mediaId)
		{
			string url = String.Concat(
				"/v1/media/",
				mediaId,
				"/comments",
				"?access_token=",
				client.AccessToken
			);
			return client.GetAsync<Envelope<IEnumerable<Comment>>>(url);
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