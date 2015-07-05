using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram.Endpoints
{
	public static class LocationsEndpoint
	{
		public static async Task<Envelope<Location>> GetLocation(this InstagramClient client, string locationId)
		{
			string url = String.Concat(
				"/v1/locations/",
				locationId,
				"?access_token=",
				client.AccessToken
			);
			return await client.GetAsync<Envelope<Location>>(url);
		}


		public static async Task<Envelope<IEnumerable<Media>>> GetRecentMediaForLocation(this InstagramClient client, string locationId, int? count = null, string minId = null, string maxId = null)
		{
			string url = String.Concat(
				"/v1/locations/",
				locationId,
				"/media/recent",
				"?access_token=",
				client.AccessToken,
				"&count=",
				count == null ? (string)null : count.ToString(),
				"&min_id=",
				minId == null ? (string)null : HttpUtility.UrlEncode(minId),
				"&max_id=",
				maxId == null ? (string)null : HttpUtility.UrlEncode(maxId)
			);
			return await client.GetAsync<Envelope<IEnumerable<Media>>>(url);
		}

		public static Task<Envelope<IEnumerable<Location>>> SearchLocations(this InstagramClient client, double latitude, double longitude, int? distance = null)
		{
			string url = String.Concat(
				"/v1/locations/search",
				"?access_token=",
				client.AccessToken,
				"&lat=",
				HttpUtility.UrlEncode(latitude.ToString("##0.0#####")),
				"&lng=",
				HttpUtility.UrlEncode(longitude.ToString("##0.0#####")),
				"&distance=",
				distance == null ? (string)null : HttpUtility.UrlEncode(distance.Value.ToString("####0"))
			);
			return client.GetAsync<Envelope<IEnumerable<Location>>>(url);
		}

		public static Task<Envelope<IEnumerable<Location>>> SearchLocationsNearFacebookPlace(this InstagramClient client, string facebookPlacesId, int? distance = null)
		{
			string url = String.Concat(
				"/v1/locations/search",
				"?access_token=",
				client.AccessToken,
				"&facebook_places_id=",
				facebookPlacesId,
				"&distance=",
				distance == null ? (string)null : HttpUtility.UrlEncode(distance.Value.ToString("####0"))
			);
			return client.GetAsync<Envelope<IEnumerable<Location>>>(url);
		}

		public static Task<Envelope<IEnumerable<Location>>> SearchLocationsNearFoursquarePlace(this InstagramClient client, string foursquare2Id, int? distance = null)
		{
			string url = String.Concat(
				"/v1/locations/search",
				"?access_token=",
				client.AccessToken,
				"&foursquare_v2_id=",
				foursquare2Id,
				"&distance=",
				distance == null ? (string)null : HttpUtility.UrlEncode(distance.Value.ToString("####0"))
			);
			return client.GetAsync<Envelope<IEnumerable<Location>>>(url);
		}
	}
}