using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using Nurdle.Api.Instagram;
using Nurdle.Api.Instagram.Responses;
using Nurdle.Api.Instagram.Endpoints;

namespace Nurdle.Api.Instagram.Tests
{
	[TestClass]
	public class InstagramTest
	{
		[TestMethod]
		public async Task User_User()
		{
			var client = new InstagramClient();
			var response = await client.GetUserInfo("2175453");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task User_SelfFeed()
		{
			var client = new InstagramClient();
			var response = await client.GetMyFeed();
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task User_UserRecentMedia_WithToken()
		{
			var client = new InstagramClient();
			var response = await client.GetRecentMediaForUser("2175453");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task User_UserRecentMedia()
		{
			var client = new InstagramClient();
			var response = await client.GetRecentMediaForUser("185339476");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task User_SelfLikedMedia()
		{
			var client = new InstagramClient();
			var response = await client.GetMediaILiked();
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task User_Search()
		{
			var client = new InstagramClient();
			var response = await client.SearchTags("cambloom");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Relationship_UserFollows()
		{
			var client = new InstagramClient();
			var response = await client.GetUsersFollowedByGivenUser("185339476");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Relationship_UserFollowedBy()
		{
			var client = new InstagramClient();
			var response = await client.GetUsersFollowingGivenUser("185339476");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Relationship_SelfRequestedBy()
		{
			var client = new InstagramClient();
			var response = await client.GetMyPendingRelationships();
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Relationship_UserRelationship()
		{
			var client = new InstagramClient();
			var response = await client.GetMyRelationshipWithUser("2175453");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Relationship_UserRelationship_POST()
		{
			var client = new InstagramClient();
			var response = await client.ChangeMyRelationshipWithUser("2175453", RelationshipAction.follow);
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Media_Media()
		{
			var client = new InstagramClient();
			var response = await client.GetMedia("514799749715942011");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Media_Shortcode()
		{
			var client = new InstagramClient();
			var response = await client.GetMediaFromShortcode("D");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Media_Search()
		{
			var client = new InstagramClient();
			var response = await client.SearchMedia(48, 2);
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Media_Popular()
		{
			var client = new InstagramClient();
			var response = await client.GetPopularMedia();
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Comments_MediaComments()
		{
			var client = new InstagramClient();
			var response = await client.GetCommentsOnMedia("514799749715942011");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Likes_MediaLikes()
		{
			var client = new InstagramClient();
			var response = await client.GetLikesOnMedia("514799749715942011");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Likes_MediaLike()
		{
			var client = new InstagramClient();
			var response = await client.LikeMedia("514799749715942011");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Likes_MediaLike_DELETE()
		{
			var client = new InstagramClient();
			var response = await client.UnlikeMedia("514799749715942011");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Tags_Tag()
		{
			var client = new InstagramClient();
			var response = await client.GetTag("nofilter");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Tags_TagRecentMedia()
		{
			var client = new InstagramClient();
			var response = await client.GetRecentMediaWithTag("nofilter");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Tags_Search()
		{
			var client = new InstagramClient();
			var response = await client.SearchTags("filter");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Locations_Location()
		{
			var client = new InstagramClient();
			var response = await client.GetLocation("1");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Locations_LocationRecentMedia()
		{
			var client = new InstagramClient();
			var response = await client.GetRecentMediaForLocation("1");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Locations_Search()
		{
			var client = new InstagramClient();
			var response = await client.SearchLocations(48, 2);
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Locations_SearchFacebookPlaces()
		{
			var client = new InstagramClient();
			var response = await client.SearchLocationsNearFacebookPlace("91641530652");
			Assert.AreEqual(200, response.meta.code);
		}

		[TestMethod]
		public async Task Locations_SearchFoursqare()
		{
			var client = new InstagramClient();
			var response = await client.SearchLocationsNearFoursquarePlace("4ab7e57cf964a5205f7b20e3");
			Assert.AreEqual(200, response.meta.code);
		}

		//[TestMethod]
		//public async Task Authorize()
		//{
		//	string clientId = Environment.GetEnvironmentVariable("INSTAGRAM_CLIENTID", EnvironmentVariableTarget.User);
		//	string redirectUri = Environment.GetEnvironmentVariable("INSTAGRAM_REDIRECTURI", EnvironmentVariableTarget.User);

		//	string endpoint = RealtimeEndpoint.Authorize(clientId, redirectUri);

		//	HttpClient client = new HttpClient();
		//	var get = await client.GetAsync(endpoint);

		//	Assert.AreEqual(HttpStatusCode.OK, get.StatusCode);
		//	Assert.AreEqual("text/html", get.Content.Headers.ContentType);
		//}

		//[TestMethod]
		//public async Task RequestAccessToken()
		//{
		//	string code = "749f7aa42fce456983e87a60e9de5769";

		//	string clientId = Environment.GetEnvironmentVariable("INSTAGRAM_CLIENTID", EnvironmentVariableTarget.User);
		//	string secretKey = Environment.GetEnvironmentVariable("INSTAGRAM_SECRETKEY", EnvironmentVariableTarget.User);
		//	string redirectUri = Environment.GetEnvironmentVariable("INSTAGRAM_REDIRECTURI", EnvironmentVariableTarget.User);

		//	string endpoint = RealtimeEndpoint.GetAccessToken(clientId, secretKey, redirectUri, code);
		//	//string xInstaForwardedFor = 

		//	HttpClient client = new HttpClient();
		////	client.DefaultRequestHeaders.Add("X-Insta-Forwarded-For", xInstaForwardedFor);
		//	var post = await client.PostAsync(endpoint, new StringContent(String.Empty));

		//	Assert.AreEqual(HttpStatusCode.OK, post.StatusCode);
		//	Assert.AreEqual("application/json", post.Content.Headers.ContentType);

		//	var response = await post.Content.ReadAsStringAsync();

		//	Assert.IsNotNull(response);
		//	Assert.AreNotEqual(String.Empty, response);

		//	var oauthToken = JsonConvert.DeserializeObject<OAuthTokenResponse>(response);

		//	Assert.IsNotNull(oauthToken);
		//	Assert.IsNotNull(oauthToken.access_token);
		//	Assert.IsNotNull(oauthToken.user);
		//}

		//[TestMethod]
		//public async Task SubscribeToAllAuthorizedUsers()
		//{
		//	string clientId = Environment.GetEnvironmentVariable("INSTAGRAM_CLIENTID", EnvironmentVariableTarget.User);
		//	string secretKey = Environment.GetEnvironmentVariable("INSTAGRAM_SECRETKEY", EnvironmentVariableTarget.User);
		//	string verifyToken = "";
		//	string callbackUrl = Environment.GetEnvironmentVariable("INSTAGRAM_CALLBACKURI", EnvironmentVariableTarget.User);

		//	string endpoint = RealtimeEndpoint.SubscribeToUsers(clientId, secretKey, verifyToken, callbackUrl);
		//	//string xInstaForwardedFor = 

		//	HttpClient client = new HttpClient();
		//	//client.DefaultRequestHeaders.Add("X-Insta-Forwarded-For", xInstaForwardedFor);
		//	var post = await client.PostAsync(endpoint, new StringContent(String.Empty));

		//	Assert.AreEqual(HttpStatusCode.OK, post.StatusCode);
		//	Assert.AreEqual("application/json", post.Content.Headers.ContentType);

		//	var response = await post.Content.ReadAsStringAsync();

		//	Assert.IsNotNull(response);
		//	Assert.AreNotEqual(String.Empty, response);

		//	var oauthToken = JsonConvert.DeserializeObject<OAuthTokenResponse>(response);

		//	Assert.IsNotNull(oauthToken);
		//	Assert.IsNotNull(oauthToken.access_token);
		//	Assert.IsNotNull(oauthToken.user);
		//}
	}
}