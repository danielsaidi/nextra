using NExtra.ValidationAttributes;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes
{
	[TestFixture]
	public class SwedishPostalCodeAttributeBehavior
	{
        [Test]
        public void IsValid_ShouldReturnFalseForNullAndRequired()
        {
            Assert.That(new SwedishPostalCodeAttribute().IsValid(null), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid(null), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForNullAndOptional()
        {
            Assert.That(new SwedishPostalCodeAttribute(false).IsValid(null), Is.True);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid(null), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForEmptyStringAndRequired()
        {
            Assert.That(new SwedishPostalCodeAttribute().IsValid(string.Empty), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid(string.Empty), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyStringAndOptional()
        {
            Assert.That(new SwedishPostalCodeAttribute(false).IsValid(string.Empty), Is.True);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid(string.Empty), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForInvalidSpace()
        {
            Assert.That(new SwedishPostalCodeAttribute().IsValid("111 11"), Is.False);

            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("1 1111"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("11 111"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("1111 1"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("11 111"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForInvalidDigitCount()
        {
            Assert.That(new SwedishPostalCodeAttribute().IsValid("1"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute().IsValid("11"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute().IsValid("111"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute().IsValid("1111"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute().IsValid("111111"), Is.False);

            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("1"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("11"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("111"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("1111"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("111 111"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForCharsAndSymbols()
        {
            Assert.That(new SwedishPostalCodeAttribute().IsValid("11a11"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute().IsValid("11%11"), Is.False);

            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("11a11"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("11%11"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("11% 11"), Is.False);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("11% 11"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForValidSpace()
        {
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("111 11"), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForValidDigitCount()
        {
            Assert.That(new SwedishPostalCodeAttribute().IsValid("11111"), Is.True);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("11111"), Is.True);
            Assert.That(new SwedishPostalCodeAttribute(true, true).IsValid("111 11"), Is.True);
        }
	}
}