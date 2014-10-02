using NExtra.Validation;
using NUnit.Framework;

namespace NExtra.Tests.Validation
{
	[TestFixture]
	public class EmailAddressAttributeBehavior
	{
	    private IValidator _validator;


        [TestFixtureSetUp]
	    public void SetUp()
	    {
	        _validator = new EmailAddressAttribute();
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
		public void IsValid_ShouldReturnFalseForEndDot()
		{
			Assert.That(_validator.IsValid("foo.bar@foobar.com."), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnFalseForNoDot()
		{
			Assert.That(_validator.IsValid("foobar@foobarcom"), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnTrueForValidStrings()
		{
			Assert.That(_validator.IsValid("foobar@foobar.com"), Is.True);
			Assert.That(_validator.IsValid("foo.bar@foobar.com"), Is.True);
		}

        [Test]
        public void IsValid_ShouldReturnTrueForShortEmail()
        {
            Assert.That(_validator.IsValid("a@foobar.com"), Is.True);
        }
	}
}