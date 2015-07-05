using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurdle.Api.Instagram.Responses
{
	public class User
	{
		public string id { get; set; }
		public string username { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string full_name { get; set; }
		public string profile_picture { get; set; }
		public string bio { get; set; }
		public string website { get; set; }
		public Counts counts { get; set; }
	}
}