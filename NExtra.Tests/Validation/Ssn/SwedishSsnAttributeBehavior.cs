using NExtra.Validation;
using NExtra.Validation.Ssn;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.Tests.Validation.Ssn
{
    [TestFixture]
    public class SwedishSsnValidatorBehavior
    {
        private static IValidator GetValidator(UseSeparator useSeparator)
        {
            return new SwedishSsnAttribute(useSeparator);
        }

        private static IValidator GetValidator(UseSeparator useSeparator, IValidator checksumValidator)
        {
            return new SwedishSsnAttribute(useSeparator, checksumValidator);
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
        public void IsValid_ShouldReturnTrueForEmptyString(UseSeparator useSeparator, bool expected)
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
            Assert.That(GetValidator(useSeparator).IsValid("abcdefgh-ijklm"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, false)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldReturnFalseForTooFewDigits(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid("780325751"), Is.EqualTo(expected));
            Assert.That(GetValidator(useSeparator).IsValid("780325-751"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, false)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldReturnFalseForInvalidMonth(UseSeparator useSeparator, bool expected)
        {
            var checksumValidator = Substitute.For<IValidator>();

            Assert.That(GetValidator(useSeparator, checksumValidator).IsValid("313108-8320"), Is.EqualTo(expected));
            Assert.That(GetValidator(useSeparator, checksumValidator).IsValid("3131088320"), Is.EqualTo(expected));

            checksumValidator.DidNotReceive().IsValid(Arg.Any<object>());
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, false)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldReturnFalseForInvalidDay(UseSeparator useSeparator, bool expected)
        {
            var checksumValidator = Substitute.For<IValidator>();

            Assert.That(GetValidator(useSeparator, checksumValidator).IsValid("310138-8320"), Is.EqualTo(expected));
            Assert.That(GetValidator(useSeparator, checksumValidator).IsValid("3101388320"), Is.EqualTo(expected));

            checksumValidator.DidNotReceive().IsValid(Arg.Any<object>());
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, false)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldReturnFalseForInvalidChecksum(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid("7803257518"), Is.EqualTo(expected));
            Assert.That(GetValidator(useSeparator).IsValid("780325-7518"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(UseSeparator.Optional)]
        [TestCase(UseSeparator.Yes)]
        public void IsValid_ShouldValidateChecksumForValidDateSsnWithDash(UseSeparator useSeparator)
        {
            var checksumValidator = Substitute.For<IValidator>();

            GetValidator(useSeparator, checksumValidator).IsValid("780325-7518");

            checksumValidator.Received().IsValid("780325-7518");
        }

        [Test]
        [TestCase(UseSeparator.No)]
        [TestCase(UseSeparator.Optional)]
        public void IsValid_ShouldValidateChecksumForValidDateSsnWithoutDash(UseSeparator useSeparator)
        {
            var checksumValidator = Substitute.For<IValidator>();

            GetValidator(useSeparator, checksumValidator).IsValid("7803257518");

            checksumValidator.Received().IsValid("7803257518");
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, false)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldReturnFalseForMultipleDashes(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid("310108---8320"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(UseSeparator.No, false)]
        [TestCase(UseSeparator.Optional, true)]
        [TestCase(UseSeparator.Yes, true)]
        public void IsValid_ShouldHandleDashWithValidSsn(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid("310108-8320"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(UseSeparator.No, true)]
        [TestCase(UseSeparator.Optional, true)]
        [TestCase(UseSeparator.Yes, false)]
        public void IsValid_ShouldHandleMissingDashWithValidSsn(UseSeparator useSeparator, bool expected)
        {
            Assert.That(GetValidator(useSeparator).IsValid("3101088320"), Is.EqualTo(expected));
        }
    }
}