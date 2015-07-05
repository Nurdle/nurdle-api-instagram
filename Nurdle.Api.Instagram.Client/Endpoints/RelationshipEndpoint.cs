using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Nurdle.Api.Instagram.Responses;

namespace Nurdle.Api.Instagram.Endpoints
{
	public static class RelationshipEndpoint
	{
		public static Task<Envelope<IEnumerable<User>>> GetUsersFollowedByGivenUser(this InstagramClient client, string userId)
		{
			string url = String.Concat(
				"/v1/users/",
				userId,
				"/follows",
				"?access_token=",
				client.AccessToken
			);
			return client.GetAsync<Envelope<IEnumerable<User>>>(url);
		}

		public static Task<Envelope<IEnumerable<User>>> GetUsersFollowingGivenUser(this InstagramClient client, string userId)
		{
			string url = String.Concat(
				"/v1/users/",
				userId,
				"/followed-by",
				"?access_token=",
				client.AccessToken
			);
			return client.GetAsync<Envelope<IEnumerable<User>>>(url);
		}

		public static Task<Envelope<IEnumerable<User>>> GetMyPendingRelationships(this InstagramClient client)
		{
			string url = String.Concat(
				"/v1/users/self/requested-by",
				"?access_token=",
				client.AccessToken
			);
			return client.GetAsync<Envelope<IEnumerable<User>>>(url);
		}

		public static Task<Envelope<Relationship>> GetMyRelationshipWithUser(this InstagramClient client, string userId)
		{
			string url = String.Concat(
				"/v1/users/",
				userId,
				"/relationship",
				"?access_token=",
				client.AccessToken
			);
			return client.GetAsync<Envelope<Relationship>>(url);
		}

		public static Task<Envelope<Relationship>> ChangeMyRelationshipWithUser(this InstagramClient client, string userId, RelationshipAction action)
		{
			string url = String.Concat(
				"/v1/users/",
				userId,
				"/relationship",
				"?access_token=",
				client.AccessToken
			);
			string content = String.Concat(
				"action=",
				Enum.GetName(typeof(RelationshipAction), action).ToLower()
			);
			return client.PostAsync<Envelope<Relationship>>(url, content);
		}
	}
}