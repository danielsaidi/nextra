using NExtra.Validation;
using NUnit.Framework;

namespace NExtra.Tests.Validation
{
	[TestFixture]
	public class UrlAttributeBehavior
    {
        private IValidator _validator;


        [TestFixtureSetUp]
        public void SetUp()
        {
            _validator = new UrlAttribute();
        }


        
		[Test]
		public void IsValid_ShouldReturnTrueForNullValue()
		{
			Assert.That(_validator.IsValid(null), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(_validator.IsValid(""), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnFalseForMissingHttp()
        {
            Assert.That(_validator.IsValid("foobar.com"), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnFalseForMissingDomain()
		{
			Assert.That(_validator.IsValid("http://.com"), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnFalseForMissingDomainDot()
		{
			Assert.That(_validator.IsValid("http://foobarcom"), Is.False);
        }

		[Test]
		public void IsValid_ShouldReturnTrueForValidUrl()
		{
			Assert.That(_validator.IsValid("http://foobar.com"), Is.True);
		}
	}
}