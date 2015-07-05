using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurdle.Api.Instagram.Responses
{
	public enum RelationshipAction
	{
		follow,
		unfollow,
		block,
		unblock,
		approve,
		ignore
	}

	public class Relationship
	{
		public string outgoing_status { get; set; }
		public string incoming_status { get; set; }
	}

	public class Location
	{
		public string id { get; set; }
		public double latitude { get; set; }
		public double longitude { get; set; }
		public string name { get; set; }
	}

	public class Comments
	{
		public int count { get; set; }
		public IEnumerable<Comment> data { get; set; }
	}

	public class Comment
	{
		public string created_time { get; set; }
		public string text { get; set; }
		public User from { get; set; }
		public string id { get; set; }
	}

	public class Media
	{
		public Location location { get; set; }
		public Comments comments { get; set; }
		public Comment caption { get; set; }
		public string link { get; set; }
		public Likes likes { get; set; }
		public string created_time { get; set; }
		public Image images { get; set; }
		public string type { get; set; }
		public IEnumerable<User> users_in_photo { get; set; }
		public string filter { get; set; }
		public IEnumerable<string> tags { get; set; }
		public string id { get; set; }
		public User user { get; set; }
		public Video videos { get; set; }
	}

	public class Likes
	{
		public int count { get; set; }
		public IEnumerable<User> data { get; set; }
	}

	public class Image
	{
		public ImageFile low_resolution { get; set; }
		public ImageFile thumbnail { get; set; }
		public ImageFile standard_resolution { get; set; }
	}

	public class Video
	{
		public VideoFile low_resolution { get; set; }
		public VideoFile standard_resolution { get; set; }
	}

	public class ImageFile
	{
		public string url { get; set; }
		public int width { get; set; }
		public int height { get; set; }
	}

	public class VideoFile
	{
		public string url { get; set; }
		public int width { get; set; }
		public int height { get; set; }
	}

	public class Tag
	{
		public string name { get; set; }
		public int media_count { get; set; }
	}
}