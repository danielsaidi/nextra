using NExtra.ValidationAttributes;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes
{
	[TestFixture]
	public class EmailAddressAttributeBehavior
	{
        [Test]
        public void IsValid_ShouldReturnTrueForNullValue()
        {
            Assert.That(new EmailAddressAttribute().IsValid(null), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(new EmailAddressAttribute().IsValid(""), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnFalseForEndDot()
		{
			Assert.That(new EmailAddressAttribute().IsValid("foo.bar@foobar.com."), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnFalseForNoDot()
		{
			Assert.That(new EmailAddressAttribute().IsValid("foobar@foobarcom"), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnTrueForValidStrings()
		{
			Assert.That(new EmailAddressAttribute().IsValid("foobar@foobar.com"), Is.True);
			Assert.That(new EmailAddressAttribute().IsValid("foo.bar@foobar.com"), Is.True);
		}
	}
}