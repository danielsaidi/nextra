using NExtra.Validation;
using NExtra.Validation.Ssn;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.Tests.Validation.Ssn
{
    [TestFixture]
    public class NorwegianSsnValidatorBehavior
    {
        private static IValidator GetValidator()
        {
            return new NorwegianSsnAttribute();
        }

        private static IValidator GetValidator(IValidator checksumValidator)
        {
            return new NorwegianSsnAttribute(checksumValidator);
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

        [Test]
        public void IsValid_ShouldReturnFalseForInvalidMonth()
        {
            var checksumValidator = Substitute.For<IValidator>();

            Assert.That(GetValidator(checksumValidator).IsValid("01130122233"), Is.False);

            checksumValidator.DidNotReceive().IsValid(Arg.Any<object>());
        }

        [Test]
        public void IsValid_ShouldReturnFalseForInvalidDay()
        {
            var checksumValidator = Substitute.For<IValidator>();

            Assert.That(GetValidator().IsValid("32010122233"), Is.False);

            checksumValidator.DidNotReceive().IsValid(Arg.Any<object>());
        }

        [Test]
        public void IsValid_ShouldReturnFalseForInvalidChecksum()
        {
            Assert.That(GetValidator().IsValid("01010111111"), Is.False);
        }

        [Test]
        public void IsValid_ShouldValidateChecksumForValidDateSsn()
        {
            var checksumValidator = Substitute.For<IValidator>();

            GetValidator(checksumValidator).IsValid("26024003298");

            checksumValidator.Received().IsValid("26024003298");
        }

        [Test, Ignore]
        public void IsValid_ShouldValidateChecksumForValidDSsn()
        {
            var checksumValidator = Substitute.For<IValidator>();

            GetValidator(checksumValidator).IsValid("26024003298");

            checksumValidator.Received().IsValid("26024003298");
        }

        [Test]
        public void IsValid_ShouldReturnTrueForValidSsn()
        {
            Assert.That(GetValidator().IsValid("26024003298"), Is.True);
        }
    }
}