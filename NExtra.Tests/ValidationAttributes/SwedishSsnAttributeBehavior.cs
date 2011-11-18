using NExtra.ValidationAttributes;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes
{
	[TestFixture]
	public class SwedishSsnAttributeBehavior
	{
        [Test]
        public void IsValid_ShouldReturnFalseForNullValue()
        {
            Assert.That(new SwedishSsnAttribute().IsValid(null), Is.False);
            Assert.That(new SwedishSsnAttribute(false).IsValid(null), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForEmptyString()
        {
            Assert.That(new SwedishSsnAttribute().IsValid(""), Is.False);
            Assert.That(new SwedishSsnAttribute(false).IsValid(""), Is.False);
        }


        [Test]
        public void IsValid_Dash_ShouldReturnFalseForAlphaNumerical()
        {
            Assert.That(new SwedishSsnAttribute().IsValid("abcdefghij"), Is.False);
        }

        [Test]
        public void IsValid_Dash_ShouldReturnFalseForTooFewDigits()
        {
            Assert.That(new SwedishSsnAttribute().IsValid("123"), Is.False);
        }

        [Test]
        public void IsValid_Dash_ShouldFalseForInvalidSsnWithInvalidFormat()
        {
            Assert.That(new SwedishSsnAttribute().IsValid("7902237516"), Is.False);
        }

        [Test]
        public void IsValid_Dash_ShouldFalseForValidSsnWithInvalidFormat()
        {
            Assert.That(new SwedishSsnAttribute().IsValid("7902237515"), Is.False);
        }

		[Test]
		public void IsValid_Dash_ShouldFalseForInvalidSsnWithValidFormat()
		{
			Assert.That(new SwedishSsnAttribute().IsValid("790223-7516"), Is.False);
		}

		[Test]
        public void IsValid_Dash_ShouldReturnTrueForValidSsnWithValidFormat()
		{
			Assert.That(new SwedishSsnAttribute().IsValid("790223-7515"), Is.True);
		}


        [Test]
        public void IsValid_NoDash_ShouldReturnFalseForAlphaNumerical()
        {
            Assert.That(new SwedishSsnAttribute(false).IsValid("abcdefghij"), Is.False);
        }

        [Test]
        public void IsValid_NoDash_ShouldReturnFalseForTooFewDigits()
        {
            Assert.That(new SwedishSsnAttribute(false).IsValid("123"), Is.False);
        }

        [Test]
        public void IsValid_NoDash_ShouldFalseForInvalidSsnWithInvalidFormat()
        {
            Assert.That(new SwedishSsnAttribute(false).IsValid("790223-7516"), Is.False);
        }

        [Test]
        public void IsValid_NoDash_ShouldFalseForValidSsnWithInvalidFormat()
        {
            Assert.That(new SwedishSsnAttribute(false).IsValid("790223-7515"), Is.False);
        }

        [Test]
        public void IsValid_NoDash_ShouldFalseForInvalidSsnWithValidFormat()
        {
            Assert.That(new SwedishSsnAttribute(false).IsValid("7902237516"), Is.False);
        }

        [Test]
        public void IsValid_NoDash_ShouldReturnTrueForValidSsnWithValidFormat()
        {
            Assert.That(new SwedishSsnAttribute(false).IsValid("7902237515"), Is.True);
        }
	}
}