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
	public static class MediaEndpoint
	{
		public static Task<Envelope<Media>> GetMedia(this InstagramClient client, string mediaId)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = String.Concat("/v1/media/", mediaId);

			return client.HttpGetAsync<Envelope<Media>>(path, query);
		}

		public static Task<Envelope<Media>> GetMediaFromShortcode(this InstagramClient client, string shortcode)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = String.Concat("/v1/media/shortcode/", shortcode);
			return client.HttpGetAsync<Envelope<Media>>(path, query);
		}

		public static Task<Envelope<IEnumerable<Media>>> SearchMedia(this InstagramClient client, double longitude, double latitude, int? distance = null, string maxTimestamp = null, string minTimestamp = null)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;
			query["max_timestamp"] = maxTimestamp;
			query["min_timestamp"] = minTimestamp;
			query["lat"] = latitude.ToString("##0.0#####");
			query["lng"] = longitude.ToString("##0.0#####");
			if (distance != null) query["distance"] = distance.Value.ToString("####0");

			string path = "/v1/media/search";

			return client.HttpGetAsync<Envelope<IEnumerable<Media>>>(path, query);
		}

		public static Task<Envelope<IEnumerable<Media>>> GetPopularMedia(this InstagramClient client)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = "/v1/media/popular";

			return client.HttpGetAsync<Envelope<IEnumerable<Media>>>(path, query);
		}
	}
}