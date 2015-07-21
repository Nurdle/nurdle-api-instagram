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
	public static class LocationsApi
	{
		public static async Task<Envelope<Location>> GetLocation(this InstagramClient client, string locationId)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = String.Concat("/v1/locations/", locationId);

			return await client.HttpGetAsync<Envelope<Location>>(path, query);
		}


		public static async Task<Envelope<IEnumerable<Media>>> GetRecentMediaForLocation(this InstagramClient client, string locationId, int? count = null, string minId = null, string maxId = null)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;
			if (count != null) query["count"] = count.ToString();
			if (minId != null) query["min_id"] = minId;
			if (maxId != null) query["max_id"] = maxId;

			string path = String.Concat("/v1/locations/", locationId, "/media/recent");

			return await client.HttpGetAsync<Envelope<IEnumerable<Media>>>(path, query);
		}

		public static Task<Envelope<IEnumerable<Location>>> SearchLocations(this InstagramClient client, double latitude, double longitude, int? distance = null)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;
			query["lat"] = latitude.ToString("##0.0#####");
			query["lng"] = longitude.ToString("##0.0#####");
			if(distance != null) query["distance"] = distance.Value.ToString("####0");

			string path = "/v1/locations/search";

			return client.HttpGetAsync<Envelope<IEnumerable<Location>>>(path, query);
		}

		public static Task<Envelope<IEnumerable<Location>>> SearchLocationsNearFacebookPlace(this InstagramClient client, string facebookPlacesId, int? distance = null)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;
			query["facebook_places_id"] = facebookPlacesId;
			if (distance != null) query["distance"] = distance.Value.ToString("####0");

			string path = String.Concat("/v1/locations/search");

			return client.HttpGetAsync<Envelope<IEnumerable<Location>>>(path, query);
		}

		public static Task<Envelope<IEnumerable<Location>>> SearchLocationsNearFoursquarePlace(this InstagramClient client, string foursquare2Id, int? distance = null)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;
			query["foursquare_v2_id"] = foursquare2Id;
			if (distance != null) query["distance"] = distance.Value.ToString("####0");

			string path = "/v1/locations/search";

			return client.HttpGetAsync<Envelope<IEnumerable<Location>>>(path, query);
		}
	}
}