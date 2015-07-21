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
	public static class RelationshipEndpoint
	{
		public static Task<Envelope<IEnumerable<User>>> GetUsersFollowedByGivenUser(this InstagramClient client, string userId)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = String.Concat("/v1/users/", userId, "/follows");

			return client.HttpGetAsync<Envelope<IEnumerable<User>>>(path, query);
		}

		public static Task<Envelope<IEnumerable<User>>> GetUsersFollowingGivenUser(this InstagramClient client, string userId)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = String.Concat("/v1/users/", userId, "/followed-by");

			return client.HttpGetAsync<Envelope<IEnumerable<User>>>(path, query);
		}

		public static Task<Envelope<IEnumerable<User>>> GetMyPendingRelationships(this InstagramClient client)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = "/v1/users/self/requested-by";

			return client.HttpGetAsync<Envelope<IEnumerable<User>>>(path, query);
		}

		public static Task<Envelope<Relationship>> GetMyRelationshipWithUser(this InstagramClient client, string userId)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = String.Concat("/v1/users/", userId, "/relationship");

			return client.HttpGetAsync<Envelope<Relationship>>(path, query);
		}

		public static Task<Envelope<Relationship>> ChangeMyRelationshipWithUser(this InstagramClient client, string userId, RelationshipAction action)
		{
			var query = new NameValueCollection();
			query["access_token"] = client.AccessToken;

			string path = String.Concat("/v1/users/", userId, "/relationship");

			var content = new NameValueCollection();
			content["action"] = Enum.GetName(typeof(RelationshipAction), action).ToLower();

			return client.HttpPostAsync<Envelope<Relationship>>(path, query, content);
		}
	}
}