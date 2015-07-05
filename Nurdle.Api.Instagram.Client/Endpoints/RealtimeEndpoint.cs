using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram.Endpoints
{
	public static class RealtimeEndpoint
	{
		/// <summary>
		/// Subscribe to all our app's authenticated users
		/// </summary>
		public static Task<Envelope<Subscription[]>> SubscribeToUsers(this InstagramClient client, string verifyToken, string callbackUrl)
		{
			if (string.IsNullOrWhiteSpace(verifyToken))
				throw new ArgumentException("Missing verifyToken argument");
			if (string.IsNullOrWhiteSpace(callbackUrl))
				throw new ArgumentException("Missing callbackUrl argument");

			//Only supported grant type
			string aspect = "media";
			string obj = "user";

			//Concat authroize url
			string url = "/v1/subscriptions";
			string body = String.Concat(
				"client_id=",
				HttpUtility.UrlEncode(client.ClientId),
				"&client_secret=",
				HttpUtility.UrlEncode(client.SecretKey),
				"&aspect=",
				HttpUtility.UrlEncode(aspect),
				"&verify_token=",
				HttpUtility.UrlEncode(verifyToken),
				"&callback_url=",
				HttpUtility.UrlEncode(callbackUrl),
				"&object=",
				HttpUtility.UrlEncode(obj)
			);
			return client.PostAsync<Envelope<Subscription[]>>(url, body);
		}

		public static Task<Envelope<Subscription[]>> SubscribeToTag(this InstagramClient client, string verifyToken, string callbackUrl, string tag)
		{
			if (string.IsNullOrWhiteSpace(verifyToken))
				throw new ArgumentException("Missing verifyToken argument");
			if (string.IsNullOrWhiteSpace(callbackUrl))
				throw new ArgumentException("Missing callbackUrl argument");

			//Only supported grant type
			string aspect = "media";
			string obj = "tag";

			//Concat authroize url
			string url = "/v1/subscriptions";
			string body = String.Concat(
				"client_id=",
				HttpUtility.UrlEncode(client.ClientId),
				"&client_secret=",
				HttpUtility.UrlEncode(client.SecretKey),
				"&aspect=",
				HttpUtility.UrlEncode(aspect),
				"&verify_token=",
				HttpUtility.UrlEncode(verifyToken),
				"&callback_url=",
				HttpUtility.UrlEncode(callbackUrl),
				"&object=",
				HttpUtility.UrlEncode(obj),
				"&object_id=",
				HttpUtility.UrlEncode(tag)
			);

			return client.PostAsync<Envelope<Subscription[]>>(url, body);
		}

		public static string SubscribeToLocation(this InstagramClient client, string clientId, string secretKey, string verifyToken, string callbackUrl, string locationId)
		{
			if (String.IsNullOrWhiteSpace(clientId))
				throw new ArgumentException("Missing clientId argument");
			if (String.IsNullOrWhiteSpace(secretKey))
				throw new ArgumentException("Missing secretKey argument");
			if (string.IsNullOrWhiteSpace(verifyToken))
				throw new ArgumentException("Missing verifyToken argument");
			if (string.IsNullOrWhiteSpace(callbackUrl))
				throw new ArgumentException("Missing callbackUrl argument");

			//Only supported grant type
			string aspect = "media";
			string obj = "location";

			//Concat authroize url
			return String.Concat(
				"https://api.instagram.com/v1/subscriptions",
				"?client_id=",
				HttpUtility.UrlEncode(clientId),
				"&client_secret=",
				HttpUtility.UrlEncode(secretKey),
				"&aspect=",
				HttpUtility.UrlEncode(aspect),
				"&verify_token=",
				HttpUtility.UrlEncode(verifyToken),
				"&callback_url=",
				HttpUtility.UrlEncode(callbackUrl),
				"&object=",
				HttpUtility.UrlEncode(obj),
				"&object_id=",
				HttpUtility.UrlEncode(locationId)
			);
		}

		public static string SubscribeToGeography(this InstagramClient client, string clientId, string secretKey, string verifyToken, string callbackUrl, double longitude, double latitude, int radius)
		{
			if (String.IsNullOrWhiteSpace(clientId))
				throw new ArgumentException("Missing clientId argument");
			if (String.IsNullOrWhiteSpace(secretKey))
				throw new ArgumentException("Missing secretKey argument");
			if (string.IsNullOrWhiteSpace(verifyToken))
				throw new ArgumentException("Missing verifyToken argument");
			if (string.IsNullOrWhiteSpace(callbackUrl))
				throw new ArgumentException("Missing callbackUrl argument");
			if (radius < 1 || radius > 5000)
				throw new ArgumentException("Radius must be between 0 and 5000 metres");
			if (longitude < 180 || longitude > 180)
				throw new ArgumentException("Longitude must be between -180 and 180");
			if (latitude < 180 || latitude > 180)
				throw new ArgumentException("Latitude must be between -180 and 180");

			//Only supported grant type
			string aspect = "media";
			string obj = "geography";

			//Concat authroize url
			return String.Concat(
				"https://api.instagram.com/v1/subscriptions",
				"?client_id=",
				HttpUtility.UrlEncode(clientId),
				"&client_secret=",
				HttpUtility.UrlEncode(secretKey),
				"&aspect=",
				HttpUtility.UrlEncode(aspect),
				"&verify_token=",
				HttpUtility.UrlEncode(verifyToken),
				"&callback_url=",
				HttpUtility.UrlEncode(callbackUrl),
				"&object=",
				HttpUtility.UrlEncode(obj),
				"&lat=",
				HttpUtility.UrlEncode(latitude.ToString("##0.0#####")),
				"&lng=",
				HttpUtility.UrlEncode(longitude.ToString("##0.0#####")),
				"&radius=",
				HttpUtility.UrlEncode(radius.ToString("####0"))
			);
		}

		public static string GetSubscriptions(this InstagramClient client, string clientId, string secretKey)
		{
			if (String.IsNullOrWhiteSpace(clientId))
				throw new ArgumentException("Missing clientId argument");
			if (String.IsNullOrWhiteSpace(secretKey))
				throw new ArgumentException("Missing secretKey argument");

			//Concat authroize url
			return String.Concat(
				"https://api.instagram.com/v1/subscriptions",
				"?client_id=",
				HttpUtility.UrlEncode(clientId),
				"&client_secret=",
				HttpUtility.UrlEncode(secretKey)
			);
		}


		static string UnsubscribeFromObject(this InstagramClient client, string clientId, string secretKey, string type)
		{
			if (String.IsNullOrWhiteSpace(clientId))
				throw new ArgumentException("Missing clientId argument");
			if (String.IsNullOrWhiteSpace(secretKey))
				throw new ArgumentException("Missing secretKey argument");
			if (String.IsNullOrWhiteSpace(type))
				throw new ArgumentException("Missing type argument");

			//Concat authroize url
			return String.Concat(
				"https://api.instagram.com/v1/subscriptions",
				"?client_id=",
				HttpUtility.UrlEncode(clientId),
				"&client_secret=",
				HttpUtility.UrlEncode(secretKey),
				"&object=",
				HttpUtility.UrlEncode(type)
			);
		}

		public static string UnsubscribeAll(this InstagramClient client, string clientId, string secretKey)
		{
			return UnsubscribeFromObject(client, clientId, secretKey, "all");
		}

		public static string UnsubscribeFromUsers(this InstagramClient client, string clientId, string secretKey)
		{
			return UnsubscribeFromObject(client, clientId, secretKey, "user");
		}
		public static string UnsubscribeFromTags(this InstagramClient client, string clientId, string secretKey)
		{
			return UnsubscribeFromObject(client, clientId, secretKey, "tag");
		}
		public static string UnsubscribeFromLocations(this InstagramClient client, string clientId, string secretKey)
		{
			return UnsubscribeFromObject(client, clientId, secretKey, "location");
		}
		public static string UnsubscribeFromGeographies(this InstagramClient client, string clientId, string secretKey)
		{
			return UnsubscribeFromObject(client, clientId, secretKey, "geography");
		}

		public static string Unsubscribe(this InstagramClient client, string clientId, string secretKey, string subscriptionId)
		{
			if (String.IsNullOrWhiteSpace(clientId))
				throw new ArgumentException("Missing clientId argument");
			if (String.IsNullOrWhiteSpace(secretKey))
				throw new ArgumentException("Missing secretKey argument");
			if (String.IsNullOrWhiteSpace(subscriptionId))
				throw new ArgumentException("Missing subscriptionId argument");

			//Concat authroize url
			return String.Concat(
				"https://api.instagram.com/v1/subscriptions",
				"?client_id=",
				HttpUtility.UrlEncode(clientId),
				"&client_secret=",
				HttpUtility.UrlEncode(secretKey),
				"&id=",
				HttpUtility.UrlEncode(subscriptionId)
			);
		}
	}
}