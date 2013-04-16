using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
	public class IComparable_ExtensionsBehavior
    {
        [Test]
        public void Limit_ShouldHandleInteger()
        {
			Assert.That(5.Limit(0, 10), Is.EqualTo(5));
			Assert.That(5.Limit(6, 10), Is.EqualTo(6));
			Assert.That(5.Limit(0, 4), Is.EqualTo(4));
        }

		[Test]
		public void Limit_ShouldHandleDouble()
		{
			Assert.That((5.1).Limit((0.1), (10.1)), Is.EqualTo((5.1)));
			Assert.That((5.1).Limit((6.1), (10.1)), Is.EqualTo((6.1)));
			Assert.That((5.1).Limit((0.1), (4.1)), Is.EqualTo((4.1)));
		}

		[Test]
		public void Limit_ShouldHandleString()
		{
			Assert.That("c".Limit("a", "e"), Is.EqualTo("c"));
			Assert.That("c".Limit("d", "e"), Is.EqualTo("d"));
			Assert.That("c".Limit("a", "b"), Is.EqualTo("b"));
		}
    }
}