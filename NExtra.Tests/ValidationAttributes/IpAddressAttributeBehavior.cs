using NExtra.ValidationAttributes;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes
{
	[TestFixture]
	public class IpAddressAttributeBehavior
    {
        [Test]
        public void IsValid_ShouldReturnFalseForNullAndRequired()
        {
            Assert.That(new IpAddressAttribute().IsValid(null), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForNullAndOptional()
        {
            Assert.That(new IpAddressAttribute(false).IsValid(null), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForEmptyStringAndRequired()
        {
            Assert.That(new IpAddressAttribute().IsValid(""), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyStringAndOptional()
        {
            Assert.That(new IpAddressAttribute(false).IsValid(""), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnFalseForDomain()
		{
			Assert.That(new IpAddressAttribute().IsValid("foobar.com"), Is.False);
		}

        [Test]
        public void IsValid_ShouldReturnFalseForTooFewSections()
        {
            Assert.That(new IpAddressAttribute().IsValid("192"), Is.False);
            Assert.That(new IpAddressAttribute().IsValid("192.168"), Is.False);
            Assert.That(new IpAddressAttribute().IsValid("192.168.0"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForNoDots()
        {
            Assert.That(new IpAddressAttribute().IsValid("19216801"), Is.False);
        }

		[Test]
		public void IsValid_ShouldReturnTrueForValidIpAddress()
		{
			Assert.That(new IpAddressAttribute().IsValid("192.168.0.1"), Is.True);
		}
	}
}