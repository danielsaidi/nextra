using NExtra.Validation;
using NUnit.Framework;

namespace NExtra.Tests.Validation
{
	[TestFixture]
	public class PhoneNumberAttributeBehavior
	{
        [Test]
        public void IsValid_ShouldReturnTrueForNullValue()
        {
            Assert.That(new PhoneNumberAttribute().IsValid(null), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(new PhoneNumberAttribute().IsValid(""), Is.True);
        }

        [Test]
        [TestCase("foo")]
        [TestCase("0730b787048")]
        [TestCase("073_0787048")]
        [TestCase("+46(0)73-078 70 48")]
        public void IsValid_ShouldDeclineInvalidStrings(string value)
        {
            Assert.That(new PhoneNumberAttribute().IsValid(value), Is.False, value);
        }

        [Test]


        [TestCase("0730787048")]
        [TestCase("073-078 70 48")]
        [TestCase("+4673-078 70 48")]
        [TestCase("0046730787048")]
        [TestCase("0 0 4 6 7 3 0 7 8 7 0 4 8")]
        public void IsValid_ShouldAllowValidStrings(string value)
        {
            Assert.That(new PhoneNumberAttribute().IsValid(value), Is.True, value);
        }
	}
}