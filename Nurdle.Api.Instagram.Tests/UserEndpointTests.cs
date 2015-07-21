using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Nurdle.Api.Instagram.Tests
{
	[TestFixture]
	class UserEndpointTests
	{
		[Test]
		public async Task User_User()
		{
			var client = new InstagramClient();
			var response = await client.GetUserInfo("2175453");
			Assert.AreEqual(200, response.meta.code);
		}
	}
}
