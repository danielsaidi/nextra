using NExtra.Validation;
using NExtra.Validation.PostalCode;
using NUnit.Framework;

namespace NExtra.Tests.Validation.PostalCode
{
	[TestFixture]
	public class SwedishPostalCodeAttributeBehavior
    {
        public IValidator GetValidator(UseSeparator useSpace)
        {
            return new SwedishPostalCodeAttribute(useSpace);
        }


        [Test]
        public void IsValid_ShouldReturnTrueForNull()
        {
            Assert.That(GetValidator(UseSeparator.Yes).IsValid(null), Is.True);
            Assert.That(GetValidator(UseSeparator.No).IsValid(null), Is.True);
            Assert.That(GetValidator(UseSeparator.Optional).IsValid(null), Is.True);
        }
        [Test]
        public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(GetValidator(UseSeparator.Yes).IsValid(string.Empty), Is.True);
            Assert.That(GetValidator(UseSeparator.No).IsValid(string.Empty), Is.True);
            Assert.That(GetValidator(UseSeparator.Optional).IsValid(string.Empty), Is.True);
        }

        [Test]
        [TestCase("1 1111")]
        [TestCase("11 111")]
        [TestCase("111 11")]
        [TestCase("1111 1")]
        public void IsValid_NoSpace_ShouldReturnFalseForAllSpaces(string postalCode)
        {
            Assert.That(GetValidator(UseSeparator.No).IsValid(postalCode), Is.False);
        }

        [Test]
        [TestCase("1 1111")]
        [TestCase("11 111")]
        [TestCase("1111 1")]
        public void IsValid_YesAndOptional_ShouldReturnFalseForInvalidSpaces(string postalCode)
        {
            Assert.That(GetValidator(UseSeparator.Yes).IsValid(postalCode), Is.False);
            Assert.That(GetValidator(UseSeparator.Optional).IsValid(postalCode), Is.False);
        }


        [Test]
        [TestCase("1")]
        [TestCase("11")]
        [TestCase("111")]
        [TestCase("1111")]
        [TestCase("111111")]
        public void IsValid_No_ShouldReturnFalseForInvalidStringLength(string postalCode)
        {
            Assert.That(GetValidator(UseSeparator.No).IsValid(postalCode), Is.False);
        }

        [Test]
        [TestCase("1")]
        [TestCase("11")]
        [TestCase("111")]
        [TestCase("1111")]
        [TestCase("111111")]
        [TestCase("111 111")]
        public void IsValid_YesAndOptional_ShouldReturnFalseForInvalidStringLength(string postalCode)
        {
            Assert.That(GetValidator(UseSeparator.Yes).IsValid(postalCode), Is.False);
            Assert.That(GetValidator(UseSeparator.Optional).IsValid(postalCode), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForInvalidChars()
        {
            Assert.That(GetValidator(UseSeparator.Yes).IsValid("@2345"), Is.False);
            Assert.That(GetValidator(UseSeparator.No).IsValid("@2345"), Is.False);
            Assert.That(GetValidator(UseSeparator.Optional).IsValid("@2345"), Is.False);
        }

        [Test]
        [TestCase("11111")]
        public void IsValid_NoAndOptional_ShouldReturnTrueForValidPostalCodeWithoutSpace(string postalCode)
        {
            Assert.That(GetValidator(UseSeparator.No).IsValid(postalCode), Is.True);
            Assert.That(GetValidator(UseSeparator.Optional).IsValid(postalCode), Is.True);
        }

        [Test]
        [TestCase("111 11")]
        public void IsValid_YesAndOptional_ShouldReturnTrueForValidPostalCodeWithSpace(string postalCode)
        {
            Assert.That(GetValidator(UseSeparator.Yes).IsValid(postalCode), Is.True);
            Assert.That(GetValidator(UseSeparator.Optional).IsValid(postalCode), Is.True);
        }
	}
}