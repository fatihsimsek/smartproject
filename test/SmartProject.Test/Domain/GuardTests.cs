using System;
using SmartProject.Domain.Common;

namespace SmartProject.Test.Domain
{
    [TestFixture]
    public class GuardTests
	{
		[Test]
		public void ValueIsNotEmpty()
		{
			string value = "SmartProject";
			Assert.DoesNotThrow(() => Guard.AgainstEmptyString(value));
		}
	}
}

