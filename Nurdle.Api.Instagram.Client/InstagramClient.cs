using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;

using Newtonsoft.Json;

using Nurdle.Api.Instagram.Endpoints;
using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram
{
	public class InstagramClient
		: IDisposable
	{
		public static string APIROOT = "https://api.instagram.com";
		public const string CONFIG_CLIENTID = "Instagram_ClientID";
		public const string CONFIG_SECRETKEY = "Instagram_SecretKey";

		internal string ClientId { get; private set; }
		internal string SecretKey { get; private set; }
		internal string AccessToken { get; private set; }

		HttpClient client;

		public InstagramClient()
		{
			//Get from web/app config
			ClientId = ConfigurationManager.AppSettings.Get(CONFIG_CLIENTID);
			SecretKey = ConfigurationManager.AppSettings.Get(CONFIG_SECRETKEY);

			//Otherwise get from environment
			if (String.IsNullOrWhiteSpace(ClientId) && String.IsNullOrWhiteSpace(SecretKey))
			{
				ClientId = Environment.GetEnvironmentVariable(CONFIG_CLIENTID);
				SecretKey = Environment.GetEnvironmentVariable(CONFIG_SECRETKEY);
			}

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

		internal async Task<TData> GetAsync<TData>(string url)
		{
			var response = await client.GetAsync(APIROOT + url);
			var json = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TData>(json);
		}

		internal async Task<TData> PostAsync<TData>(string url, string content)
		{
			var stringcontent = new StringContent(content);
			var response = await client.PostAsync(APIROOT + url, stringcontent);
			var json = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TData>(json);
		}

		internal async Task<TData> DeleteAsync<TData>(string url)
		{
			var response = await client.DeleteAsync(APIROOT + url);
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