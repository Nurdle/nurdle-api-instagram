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
	public static class GeographiesApi
	{
		public static Task<Envelope<IEnumerable<Media>>> GetRecentMediaForGeography(this InstagramClient client, string geoId, int? count = null, string minId = null)
		{
			var query = new NameValueCollection();
			query["client_id"] = client.ClientId;
			if (count != null) query["count"] = count.ToString();
			if(minId != null) query["min_id"] = minId;

			string path = String.Concat("/v1/geographies/", geoId, "/media/recent");
			
			return client.HttpGetAsync<Envelope<IEnumerable<Media>>>(path, query);
		}
	}
}
