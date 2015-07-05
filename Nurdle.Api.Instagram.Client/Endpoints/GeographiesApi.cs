using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram
{
	public static class GeographiesApi
	{
		public static Task<Envelope<IEnumerable<Media>>> GetRecentMediaForGeography(this InstagramClient client, string geoId, int? count = null, string minId = null)
		{
			string url = String.Concat(
				"/v1/geographies/",
				geoId,
				"/media/recent",
				"?client_id=",
				client.ClientId,
				"&count=",
				count == null ? (string)null : count.ToString(),
				"&min_id=",
				minId == null ? (string)null : HttpUtility.UrlEncode(minId)
			);
			return client.GetAsync<Envelope<IEnumerable<Media>>>(url);
		}

	}
}
