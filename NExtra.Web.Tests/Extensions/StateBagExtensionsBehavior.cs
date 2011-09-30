using System.Web.UI;
using NExtra.Web.Extensions;
using NUnit.Framework;

namespace NExtra.Web.Tests.Extensions
{
	[TestFixture]
	public class StateBagExtensionsBehavior
	{
		private StateBag stateBag;

		[SetUp]
		public void SetUp()
		{
			stateBag= new StateBag();
		}


		[Test]
		public void Get_ShouldReturnDefaultValueForNonExistingItemIfNoFallback()
		{
			Assert.That(stateBag.Get<string>("foo"), Is.Null);
		}

		[Test]
		public void Get_ShouldReturnFallbackValueForNonExistingItem()
		{
			Assert.That(stateBag.Get("foo", "bar"), Is.EqualTo("bar"));
		}

		[Test]
		public void Set_ShouldAddItem()
		{
			stateBag.Set("foo", "bar2");

			Assert.That(stateBag.Get<string>("foo"), Is.EqualTo("bar2"));
		}
	}
}
