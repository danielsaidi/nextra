using NExtra.ValidationAttributes;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes
{
	[TestFixture]
	public class EmailAddressAttributeBehavior
	{
        [Test]
        public void IsValid_ShouldReturnFalseForNullAndRequired()
        {
            Assert.That(new EmailAddressAttribute().IsValid(null), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForNullAndOptional()
        {
            Assert.That(new EmailAddressAttribute(false).IsValid(null), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForEmptyStringAndRequired()
        {
            Assert.That(new EmailAddressAttribute().IsValid(""), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyStringAndOptional()
        {
            Assert.That(new EmailAddressAttribute(false).IsValid(""), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnFalseForStartDot()
		{
			Assert.That(new EmailAddressAttribute().IsValid(".foo.bar@foobar.com"), Is.False);
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