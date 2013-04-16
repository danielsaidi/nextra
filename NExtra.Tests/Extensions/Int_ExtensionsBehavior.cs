using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
	public class Int_ExtensionsBehavior
	{
		[Test]
		public void IsEven_ShouldReturnCorrectValue()
		{
			Assert.That(1.IsEven(), Is.False);
			Assert.That(2.IsEven(), Is.True);
			Assert.That(99.IsEven(), Is.False);
			Assert.That(100.IsEven(), Is.True);
		}

		[Test]
		public void IsOdd_ShouldReturnCorrectValue()
		{
			Assert.That(1.IsOdd(), Is.True);
			Assert.That(2.IsOdd(), Is.False);
			Assert.That(99.IsOdd(), Is.True);
			Assert.That(100.IsOdd(), Is.False);
		}
    }
}