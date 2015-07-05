using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurdle.Api.Instagram.Responses
{
	public class SubscriptionUpdate
	{
		public string subscription_id { get; set; }
		public string @object { get; set; }
		public string object_id { get; set; }
		public string lat { get; set; }
		public string lng { get; set; }
		public string radius { get; set; }
		public string changed_aspect { get; set; }
		public DateTime time { get; set; }
	}
}