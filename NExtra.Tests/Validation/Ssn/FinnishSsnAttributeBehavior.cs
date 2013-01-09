using NExtra.Validation;
using NExtra.Validation.Ssn;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.Tests.Validation.Ssn
{
    [TestFixture]
    public class FinnishSsnValidatorBehavior
    {
        private static IValidator GetValidator(UseSeparator useSeparator)
        {
            return new FinnishSsnAttribute(useSeparator);
        }

        private static IValidator GetValidator(UseSeparator useSeparator, IValidator checksumValidator)
        {
            return new FinnishSsnAttribute(useSeparator, checksumValidator);
        }


        [Test]
        [TestCase(UseSeparator.No, true)]
        [TestCase(UseSeparator.Optional, true)]
        [TestCase(UseSeparator.Yes, true)]
        public void IsValid_ShouldReturnTrueForNullValue(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid(null), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(UseSeparator.No, true)]
        [TestCase(UseSeparator.Optional, true)]
        [TestCase(UseSeparator.Yes, true)]
        public void IsValid_ShouldReturnTrueForEmptyValue(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid(""), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, false)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldReturnFalseForAlphaNumericalValue(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid("abcdefghijklm"), Is.EqualTo(expected));
            Assert.That(GetValidator(useSeparator).IsValid("abcdefghi-jklm"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, false)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldReturnFalseForTooFewCharacters(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid("300974498"), Is.EqualTo(expected));
            Assert.That(GetValidator(useSeparator).IsValid("300974-498"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, false)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldReturnFalseForMultipleDashes(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid("300974---498S"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, false)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldReturnFalseForInvalidMonth(UseSeparator useSeparator, bool expected)
        {
            var checksumValidator = Substitute.For<IValidator>();

            Assert.That(GetValidator(useSeparator, checksumValidator).IsValid("301974498S"), Is.EqualTo(expected));
            Assert.That(GetValidator(useSeparator, checksumValidator).IsValid("301974-498S"), Is.EqualTo(expected));

            checksumValidator.DidNotReceive().IsValid(Arg.Any<object>());
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, false)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldReturnFalseForInvalidDay(UseSeparator useSeparator, bool expected)
        {
            var checksumValidator = Substitute.For<IValidator>();

            Assert.That(GetValidator(useSeparator, checksumValidator).IsValid("320974498S"), Is.EqualTo(expected));
            Assert.That(GetValidator(useSeparator, checksumValidator).IsValid("320974-498S"), Is.EqualTo(expected));

            checksumValidator.DidNotReceive().IsValid(Arg.Any<object>());
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, false)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldReturnFalseForInvalidChecksum(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid("320974498S"), Is.EqualTo(expected));
            Assert.That(GetValidator(useSeparator).IsValid("320974-498S"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(UseSeparator.Optional)]
        [TestCase(UseSeparator.Yes)]
        public void IsValid_ShouldValidateChecksumForValidDateSsnWithDash(UseSeparator useSeparator)
        {
            var checksumValidator = Substitute.For<IValidator>();

            GetValidator(useSeparator, checksumValidator).IsValid("300974-498S");

            checksumValidator.Received().IsValid("300974-498S");
        }

        [Test]
        [TestCase(UseSeparator.No)]
        [TestCase(UseSeparator.Optional)]
        public void IsValid_ShouldValidateChecksumForValidDateSsnWithoutDash(UseSeparator useSeparator)
        {
            var checksumValidator = Substitute.For<IValidator>();

            GetValidator(useSeparator, checksumValidator).IsValid("300974498S");

            checksumValidator.Received().IsValid("300974498S");
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, true)]
        [TestCase(UseSeparator.Yes, true)]
        public void IsValid_ShouldHandleValidDashedSsn(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid("300974-498S"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(UseSeparator.No, true)]
        [TestCase(UseSeparator.Optional, true)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldHandleValidNonDashedSsn(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid("300974498S"), Is.EqualTo(expected));
        }
    }
}