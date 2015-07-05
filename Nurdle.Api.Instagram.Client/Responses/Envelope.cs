using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurdle.Api.Instagram.Responses
{
	public class Envelope<TData>
	{
		public Meta meta { get; set; }
		public TData data { get; set; }
		public Pagination pagination { get; set; }
	}
}