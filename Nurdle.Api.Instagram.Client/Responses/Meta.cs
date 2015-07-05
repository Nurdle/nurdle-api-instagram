using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurdle.Api.Instagram.Responses
{
	public class Meta
	{
		public int code { get; set; }
		public string error_type { get; set; }
		public string error_message { get; set; }
	}
}