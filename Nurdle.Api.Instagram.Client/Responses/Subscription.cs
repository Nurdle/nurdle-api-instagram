using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurdle.Api.Instagram.Responses
{
	public class Subscription
	{
		public string id { get; set; }
		public string type { get; set; }
		public string @object { get; set; }
		public string aspect { get; set; }
		public string callback_url { get; set; }
	}
}