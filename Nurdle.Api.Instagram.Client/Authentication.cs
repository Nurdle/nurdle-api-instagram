using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;
using System.Net.Http;

namespace Nurdle.Api.Instagram
{
	public static class Authentication
	{
		public static string Authorize(this InstagramClient client, string redirectUri, string responseType = null, string state = null, params Scope[] scopes)
		{
			if (string.IsNullOrWhiteSpace(redirectUri))
				throw new ArgumentException("Missing redirectUri argument");

			//Defaults
			if (responseType == null) responseType = "code";
			if (state == null) state = string.Empty;
			if (scopes == null || scopes.Length <= 0) scopes = new[] { Scope.basic };

			string sscopes = Scopes.ToString(scopes);

			//Concat authroize url
			return String.Concat(
				"https://api.instagram.com/oauth/authorize/",
				"?client_id=",
				HttpUtility.UrlEncode(client.ClientId),
				"&redirect_uri=",
				HttpUtility.UrlEncode(redirectUri),
				"&response_type=",
				HttpUtility.UrlEncode(responseType),
				"&state=",
				HttpUtility.UrlEncode(state),
				"&scope=",
				HttpUtility.UrlEncode(sscopes)
			);
		}

		public static async Task<Responses.AccessToken> GetAccessToken(this InstagramClient client, string redirectUri, string code, string grantType = null)
		{
			if (string.IsNullOrWhiteSpace(code))
				throw new ArgumentException("Missing code argument");

			//Only supported grant type
			if (grantType == null) 
				grantType = "authorization_code";

			//Concat authroize url
			var content = new NameValueCollection();
			content["client_id"] = client.ClientId;
			content["client_secret"] = client.SecretKey;
			content["grant_type"] = grantType;
			content["redirect_uri"] = redirectUri;
			content["code"] = code;

			string path = "/oauth/access_token/";

			return await client.HttpPostAsync<Responses.AccessToken>(path, null, content);
		}
	}
}
