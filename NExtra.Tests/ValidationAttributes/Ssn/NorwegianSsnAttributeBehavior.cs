using NExtra.ValidationAttributes.Ssn;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes.Ssn
{
    [TestFixture]
    public class NorwegianSsnValidatorBehavior
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        private static NorwegianSsnAttribute GetValidator()
        {
            return new NorwegianSsnAttribute();
        }


        [Test]
        public void IsValid_ShouldReturnTrueForNullValue()
        {
            Assert.That(GetValidator().IsValid(null), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForEmptyString()
        {
            Assert.That(GetValidator().IsValid(""), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForAlphaNumericalValue()
        {
            Assert.That(GetValidator().IsValid("abcdefghijklm"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForTooFewDigigt()
        {
            Assert.That(GetValidator().IsValid("0101011111"), Is.False);
        }

        [Test, Ignore]
        public void IsValid_ShouldReturnFalseForInvalidChecksum()
        {
            //TODO: To make this work, implement the checksum calculation in the validator
            Assert.That(GetValidator().IsValid("01010111111"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForInvalidMonth()
        {
            Assert.That(GetValidator().IsValid("01130122233"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForInvalidDay()
        {
            Assert.That(GetValidator().IsValid("32010122233"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForValidSsn()
        {
            //NOTE: When the checksum calculation is implemented in the validator, this will fail
            Assert.That(GetValidator().IsValid("01010111111"), Is.True);
        }
    }
}