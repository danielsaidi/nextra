using System.Web.UI;
using NExtra.Web.Extensions;
using NUnit.Framework;

namespace NExtra.Web.Tests.Extensions
{
	[TestFixture]
	public class StateBagExtensionsBehavior
	{
		private StateBag _stateBag;

		[SetUp]
		public void SetUp()
		{
			_stateBag= new StateBag();
		}


		[Test]
		public void Get_ShouldReturnDefaultValueForNonExistingItemIfNoFallback()
		{
			Assert.That(_stateBag.Get<string>("foo"), Is.Null);
		}

		[Test]
		public void Get_ShouldReturnFallbackValueForNonExistingItem()
		{
			Assert.That(_stateBag.Get("foo", "bar"), Is.EqualTo("bar"));
		}

		[Test]
		public void Set_ShouldAddItem()
		{
			_stateBag.Set("foo", "bar2");

			Assert.That(_stateBag.Get<string>("foo"), Is.EqualTo("bar2"));
		}
	}
}
