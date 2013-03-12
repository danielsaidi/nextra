using NExtra.Validation;
using NUnit.Framework;

namespace NExtra.Tests.Validation
{
	[TestFixture]
	public class EmailAddressAttributeBehavior
	{
	    private IValidator validator;


        [TestFixtureSetUp]
	    public void SetUp()
	    {
	        validator = new EmailAddressAttribute();
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
		public void IsValid_ShouldReturnFalseForEndDot()
		{
			Assert.That(validator.IsValid("foo.bar@foobar.com."), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnFalseForNoDot()
		{
			Assert.That(validator.IsValid("foobar@foobarcom"), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnTrueForValidStrings()
		{
			Assert.That(validator.IsValid("foobar@foobar.com"), Is.True);
			Assert.That(validator.IsValid("foo.bar@foobar.com"), Is.True);
		}

        [Test]
        public void IsValid_ShouldReturnTrueForShortEmail()
        {
            Assert.That(validator.IsValid("a@foobar.com"), Is.True);
        }
	}
}