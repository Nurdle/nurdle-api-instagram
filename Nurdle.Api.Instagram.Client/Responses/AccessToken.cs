using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurdle.Api.Instagram.Responses
{
	public class AccessToken
	{
		//Success
		public string access_token { get; set; }
		public User user { get; set; }
		//Error
		public int code { get; set; }
		public string error_type { get; set; }
		public string error_message { get; set; }
	}
}