using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nurdle.Api.Instagram
{
	public static class Utility
	{
		public static string ToQueryString(this NameValueCollection query)
		{
			if (query == null || query.Keys.Count <= 0)
				return null;

			StringBuilder sb = new StringBuilder();
			string split = "";
			foreach (string key in query.Keys)
			{
				var value = query.Get(key);

				sb.Append(split);
				sb.Append(HttpUtility.UrlEncode(key));
				sb.Append("=");
				if(value != null)
					sb.Append(HttpUtility.UrlEncode(value));

				split = "&";
			}

			return sb.ToString();
		}
	}
}
