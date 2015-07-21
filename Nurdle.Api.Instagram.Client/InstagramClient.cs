using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;

using Newtonsoft.Json;

using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram
{
	public class InstagramClient
		: IDisposable
	{
		public static Uri APIROOT = new Uri("https://api.instagram.com");
		public const string CONFIG_CLIENTID = "Instagram_ClientID";
		public const string CONFIG_SECRETKEY = "Instagram_SecretKey";
		public const string CONFIG_ACCESSTOKEN = "Instagram_AccessToken";

		internal string ClientId { get; private set; }
		internal string SecretKey { get; private set; }
		internal string AccessToken { get; private set; }

		HttpClient client;

		public InstagramClient()
		{
			//Get from web/app config
			ClientId = ConfigurationManager.AppSettings.Get(CONFIG_CLIENTID);
			SecretKey = ConfigurationManager.AppSettings.Get(CONFIG_SECRETKEY);
			AccessToken = ConfigurationManager.AppSettings.Get(CONFIG_ACCESSTOKEN);

			//Otherwise get from environment
			if (String.IsNullOrWhiteSpace(ClientId))
				ClientId = Environment.GetEnvironmentVariable(CONFIG_CLIENTID);
			if (String.IsNullOrWhiteSpace(SecretKey))
				SecretKey = Environment.GetEnvironmentVariable(CONFIG_SECRETKEY);
			if (String.IsNullOrWhiteSpace(AccessToken))
				AccessToken = Environment.GetEnvironmentVariable(CONFIG_ACCESSTOKEN);

			client = new HttpClient();
		}
		public InstagramClient(string clientId, string secretKey)
		{
			ClientId = clientId;
			SecretKey = secretKey;
			client = new HttpClient();
		}

		public InstagramClient(string clientId, string secretKey, string accessToken = null)
			: this()
		{
			this.ClientId = clientId;
			this.SecretKey = secretKey;
			this.AccessToken = accessToken;
		}

		public async Task<TData> HttpGetAsync<TData>(string path, NameValueCollection query)
		{
			var uriBuilder = new UriBuilder(InstagramClient.APIROOT);
			uriBuilder.Path = path;
			uriBuilder.Query = query.ToQueryString();

			var response = await client.GetAsync(uriBuilder.Uri);
			var json = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TData>(json);
		}

		public async Task<TData> HttpPostAsync<TData>(string path, NameValueCollection query, NameValueCollection body)
		{
			var uriBuilder = new UriBuilder(InstagramClient.APIROOT);
			uriBuilder.Path = path;
			uriBuilder.Query = query.ToQueryString();

			var content = body.ToString();
			var stringcontent = new StringContent(content);

			var response = await client.PostAsync(uriBuilder.Uri, stringcontent);
			var json = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TData>(json);
		}

		public async Task<TData> HttpDeleteAsync<TData>(string path, NameValueCollection query)
		{
			var uriBuilder = new UriBuilder(InstagramClient.APIROOT);
			uriBuilder.Path = path;
			uriBuilder.Query = query.ToQueryString();

			var response = await client.DeleteAsync(uriBuilder.Uri);
			var json = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TData>(json);
		}

		protected virtual void Dispose(bool managed)
		{
			if (!managed)
				return;

			if (client == null)
				return;

			client.Dispose();
			client = null;
		}

		public void Dispose()
		{
			Dispose(true);
		}
	}
}