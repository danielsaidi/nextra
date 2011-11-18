using NExtra.ValidationAttributes;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes
{
	[TestFixture]
	public class SwedishPostalCodeAttributeBehavior
	{
        [Test]
        public void IsValid_ShouldReturnTrueForNull()
        {
            Assert.That(new SwedishPostalCodeAttribute().IsValid(null), Is.True);
            Assert.That(new SwedishPostalCodeAttribute(true).IsValid(null), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(new SwedishPostalCodeAttribute().IsValid(string.Empty), Is.True);
            Assert.That(new SwedishPostalCodeAttribute(true).IsValid(string.Empty), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForSpaceWhenNotAllowed()
        {
            Assert.That(new SwedishPostalCodeAttribute().IsValid("111 11"), Is.False);
        }

        [Test]
        [TestCase("1 1111")]
        [TestCase("11 111")]
        [TestCase("1111 1")]
        public void IsValid_ShouldReturnFalseForInvalidSpaceWhenAllowed(string postalCode)
        {
            Assert.That(new SwedishPostalCodeAttribute(true).IsValid(postalCode), Is.False);
        }

        [Test]
        [TestCase("1")]
        [TestCase("11")]
        [TestCase("111")]
        [TestCase("1111")]
        [TestCase("111111")]
        public void IsValid_ShouldReturnFalseForInvalidStringLengthWhenSpaceIsNotAllowed(string postalCode)
        {
            Assert.That(new SwedishPostalCodeAttribute().IsValid(postalCode), Is.False);
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
            Assert.That(new SwedishPostalCodeAttribute(true).IsValid(postalCode), Is.False);
        }


        [Test]
        public void IsValid_ShouldReturnFalseForInvalidChars()
        {
            Assert.That(new SwedishPostalCodeAttribute().IsValid("@2345"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true).IsValid("@2345"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForValidPostalCodeWithoutSpace()
        {
            Assert.That(new SwedishPostalCodeAttribute().IsValid("11111"), Is.True);
            Assert.That(new SwedishPostalCodeAttribute(true).IsValid("11111"), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForValidPostalCodeWithSpace()
        {
            Assert.That(new SwedishPostalCodeAttribute(true).IsValid("111 11"), Is.True);
        }
	}
}