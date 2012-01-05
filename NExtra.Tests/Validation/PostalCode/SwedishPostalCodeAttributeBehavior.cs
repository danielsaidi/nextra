using NExtra.Validation;
using NExtra.Validation.PostalCode;
using NUnit.Framework;

namespace NExtra.Tests.Validation.PostalCode
{
	[TestFixture]
	public class SwedishPostalCodeAttributeBehavior
    {
        public IValidator GetValidator(bool optionalSpace = false)
        {
            return new SwedishPostalCodeAttribute(optionalSpace);
        }


        [Test]
        public void IsValid_ShouldReturnTrueForNull()
        {
            Assert.That(GetValidator().IsValid(null), Is.True);
            Assert.That(GetValidator(true).IsValid(null), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(GetValidator().IsValid(string.Empty), Is.True);
            Assert.That(GetValidator(true).IsValid(string.Empty), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForSpaceWhenNotAllowed()
        {
            Assert.That(GetValidator().IsValid("111 11"), Is.False);
        }

        [Test]
        [TestCase("1 1111")]
        [TestCase("11 111")]
        [TestCase("1111 1")]
        public void IsValid_ShouldReturnFalseForInvalidSpaceWhenAllowed(string postalCode)
        {
            Assert.That(GetValidator(true).IsValid(postalCode), Is.False);
        }

        [Test]
        [TestCase("1")]
        [TestCase("11")]
        [TestCase("111")]
        [TestCase("1111")]
        [TestCase("111111")]
        public void IsValid_ShouldReturnFalseForInvalidStringLengthWhenSpaceIsNotAllowed(string postalCode)
        {
            Assert.That(GetValidator().IsValid(postalCode), Is.False);
        }

        [Test]
        [TestCase("1")]
        [TestCase("11")]
        [TestCase("111")]
        [TestCase("1111")]
        [TestCase("111111")]
        [TestCase("111 111")]
        public void IsValid_ShouldReturnFalseForInvalidStringLengthWhenSpaceIsAllowed(string postalCode)
        {
            Assert.That(GetValidator(true).IsValid(postalCode), Is.False);
        }


        [Test]
        public void IsValid_ShouldReturnFalseForInvalidChars()
        {
            Assert.That(GetValidator().IsValid("@2345"), Is.False);
            Assert.That(GetValidator(true).IsValid("@2345"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForValidPostalCodeWithoutSpace()
        {
            Assert.That(GetValidator().IsValid("11111"), Is.True);
            Assert.That(GetValidator(true).IsValid("11111"), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForValidPostalCodeWithSpace()
        {
            Assert.That(GetValidator(true).IsValid("111 11"), Is.True);
        }
	}
}