using NExtra.ValidationAttributes;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes
{
	[TestFixture]
	public class MinLengthAttributeBehavior
	{
		[Test]
		public void IsValid_ShouldHandleNull()
		{
            Assert.That(new MinLengthAttribute(0).IsValid(null), Is.False);
		}

		[Test]
		public void IsValid_ShouldHandleEmptyString()
        {
            Assert.That(new MinLengthAttribute(0).IsValid(""), Is.True);
            Assert.That(new MinLengthAttribute(1).IsValid(""), Is.False);
		}

		[Test]
		public void IsValid_ShouldHandleNonEmptyString()
        {
            Assert.That(new MinLengthAttribute(0).IsValid("foo"), Is.True);
            Assert.That(new MinLengthAttribute(1).IsValid("foo"), Is.True);
            Assert.That(new MinLengthAttribute(2).IsValid("foo"), Is.True);
            Assert.That(new MinLengthAttribute(3).IsValid("foo"), Is.True);
            Assert.That(new MinLengthAttribute(4).IsValid("foo"), Is.False);
		}
	}
}