using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram.Endpoints
{
	public static class MediaEndpoint
	{
		public static Task<Envelope<Media>> GetMedia(this InstagramClient client, string mediaId)
		{
			string url = String.Concat(
				"/v1/media/",
				mediaId,
				"?access_token=",
				client.AccessToken
			);
			return client.GetAsync<Envelope<Media>>(url);
		}

		public static Task<Envelope<Media>> GetMediaFromShortcode(this InstagramClient client, string shortcode)
		{
			string url = String.Concat(
				"/v1/media/shortcode/",
				shortcode,
				"?access_token=",
				client.AccessToken
			);
			return client.GetAsync<Envelope<Media>>(url);
		}

		public static Task<Envelope<IEnumerable<Media>>> SearchMedia(this InstagramClient client, double longitude, double latitude, int? distance = null, string maxTimestamp = null, string minTimestamp = null)
		{
			string url = String.Concat(
				"/v1/media/search",
				"?access_token=",
				client.AccessToken,
				"&max_timestamp=",
				HttpUtility.UrlEncode(maxTimestamp),
				"&min_timestamp=",
				HttpUtility.UrlEncode(minTimestamp),
				"&lat=",
				HttpUtility.UrlEncode(latitude.ToString("##0.0#####")),
				"&lng=",
				HttpUtility.UrlEncode(longitude.ToString("##0.0#####")),
				"&distance=",
				distance == null ? (string)null : HttpUtility.UrlEncode(distance.Value.ToString("####0"))
			);
			return client.GetAsync<Envelope<IEnumerable<Media>>>(url);
		}

		public static Task<Envelope<IEnumerable<Media>>> GetPopularMedia(this InstagramClient client)
		{
			string url = String.Concat(
				"/v1/media/popular",
				"?access_token=",
				client.AccessToken
			);
			return client.GetAsync<Envelope<IEnumerable<Media>>>(url);
		}
	}
}