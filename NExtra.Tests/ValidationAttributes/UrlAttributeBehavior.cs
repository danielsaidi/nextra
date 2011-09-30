using NExtra.ValidationAttributes;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes
{
	[TestFixture]
	public class UrlAttributeBehavior
	{
		[Test]
		public void IsValid_ShouldReturnFalseForNullAndRequired()
		{
			Assert.That(new UrlAttribute().IsValid(null), Is.False);
		}

        [Test]
        public void IsValid_ShouldReturnTrueForNullAndOptional()
        {
            Assert.That(new UrlAttribute(false).IsValid(null), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnFalseForEmptyStringAndRequired()
		{
			Assert.That(new UrlAttribute().IsValid(""), Is.False);
		}

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyStringAndOptional()
        {
            Assert.That(new UrlAttribute(false).IsValid(""), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnFalseForMissingHttp()
        {
            Assert.That(new UrlAttribute().IsValid("foobar.com"), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnFalseForMissingDomain()
		{
			Assert.That(new UrlAttribute().IsValid("http://.com"), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnFalseForMissingDomainDot()
		{
			Assert.That(new UrlAttribute().IsValid("http://foobarcom"), Is.False);
        }

		[Test]
		public void IsValid_ShouldReturnTrueForValidUrl()
		{
			Assert.That(new UrlAttribute().IsValid("http://foobar.com"), Is.True);
		}
	}
}