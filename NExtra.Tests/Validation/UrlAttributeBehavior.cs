using NExtra.Validation;
using NUnit.Framework;

namespace NExtra.Tests.Validation
{
	[TestFixture]
	public class UrlAttributeBehavior
    {
        private IValidator validator;


        [TestFixtureSetUp]
        public void SetUp()
        {
            validator = new UrlAttribute();
        }


        
		[Test]
		public void IsValid_ShouldReturnTrueForNullValue()
		{
			Assert.That(validator.IsValid(null), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(validator.IsValid(""), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnFalseForMissingHttp()
        {
            Assert.That(validator.IsValid("foobar.com"), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnFalseForMissingDomain()
		{
			Assert.That(validator.IsValid("http://.com"), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnFalseForMissingDomainDot()
		{
			Assert.That(validator.IsValid("http://foobarcom"), Is.False);
        }

		[Test]
		public void IsValid_ShouldReturnTrueForValidUrl()
		{
			Assert.That(validator.IsValid("http://foobar.com"), Is.True);
		}
	}
}