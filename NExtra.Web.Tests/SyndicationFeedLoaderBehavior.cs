using System.Linq;
using NUnit.Framework;

namespace NExtra.Web.Tests
{
	[TestFixture]
	public class SyndicationFeedLoaderBehavior
	{
		[Test]
		public void Load_ShouldReturnDefaultObjectForInvalidUrl()
		{
			Assert.That(new SyndicationFeedLoader().Load(null).Items.Count(), Is.EqualTo(0));
		}

		[Test, Ignore]
		public void Load_ShouldReturnPopulatedItemListForValidUrl()
		{
			Assert.That(new SyndicationFeedLoader().Load("http://danielsaidi.wordpress.com/feed/").Items.Count(), Is.EqualTo(10));
		}
	}
}
