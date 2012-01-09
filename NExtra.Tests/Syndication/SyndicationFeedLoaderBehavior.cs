using System.Linq;
using NExtra.Syndication;
using NUnit.Framework;

namespace NExtra.Tests.Syndication
{
	[TestFixture]
	public class SyndicationFeedLoaderBehavior
	{
		[Test, Ignore]
		public void Load_ShouldReturnPopulatedItemListForValidUrl()
		{
			Assert.That(new SyndicationFeedLoader().Load("http://danielsaidi.wordpress.com/feed/").Items.Count(), Is.EqualTo(10));
		}
	}
}
