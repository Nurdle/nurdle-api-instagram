using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurdle.Api.Instagram
{
	public enum Scope
	{
		basic = 0, //Default
		comments, //Create or delete comments
		relationships, //Follow and unfollow users
		likes //Like and unlike items
	}

	public static class Scopes
	{
		public static string ToString(IEnumerable<Scope> scopes)
		{
			return String.Join(" ", scopes.Select(scope =>
				Enum.GetName(typeof(Scope), scope).ToLower()
			)).Trim();

		}
	}
}