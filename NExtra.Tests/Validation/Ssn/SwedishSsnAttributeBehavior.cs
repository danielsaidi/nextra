using NExtra.Validation;
using NExtra.Validation.Ssn;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.Tests.Validation.Ssn
{
    [TestFixture]
    public class SwedishSsnValidatorBehavior
    {
        private static IValidator GetValidator(RequiredMode separatorMode)
        {
            return new SwedishSsnAttribute(separatorMode);
        }

        private static IValidator GetValidator(RequiredMode separatorMode, IValidator checksumValidator)
        {
            return new SwedishSsnAttribute(separatorMode, checksumValidator);
        }


        [Test]
        [TestCase(RequiredMode.None, true)]
        [TestCase(RequiredMode.Optional, true)]
        [TestCase(RequiredMode.Required, true)]
        public void IsValid_ShouldReturnTrueForNullValue(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid(null), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(RequiredMode.None, true)]
        [TestCase(RequiredMode.Optional, true)]
        [TestCase(RequiredMode.Required, true)]
        public void IsValid_ShouldReturnTrueForEmptyString(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid(""), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, false)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldReturnFalseForAlphaNumericalValue(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("abcdefghijklm"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("abcdefgh-ijklm"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, false)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldReturnFalseForTooFewDigits(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("780325751"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("780325-751"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, false)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidMonth(RequiredMode separatorMode, bool expected)
        {
            var checksumValidator = Substitute.For<IValidator>();

            Assert.That(GetValidator(separatorMode, checksumValidator).IsValid("313108-8320"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode, checksumValidator).IsValid("3131088320"), Is.EqualTo(expected));

            checksumValidator.DidNotReceive().IsValid(Arg.Any<object>());
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, false)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidDay(RequiredMode separatorMode, bool expected)
        {
            var checksumValidator = Substitute.For<IValidator>();

            Assert.That(GetValidator(separatorMode, checksumValidator).IsValid("310138-8320"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode, checksumValidator).IsValid("3101388320"), Is.EqualTo(expected));

            checksumValidator.DidNotReceive().IsValid(Arg.Any<object>());
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, false)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidChecksum(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("7803257518"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("780325-7518"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(RequiredMode.Optional)]
        [TestCase(RequiredMode.Required)]
        public void IsValid_ShouldValidateChecksumForValidDateSsnWithDash(RequiredMode separatorMode)
        {
            var checksumValidator = Substitute.For<IValidator>();

            GetValidator(separatorMode, checksumValidator).IsValid("780325-7518");

            checksumValidator.Received().IsValid("780325-7518");
        }

        [Test]
        [TestCase(RequiredMode.None)]
        [TestCase(RequiredMode.Optional)]
        public void IsValid_ShouldValidateChecksumForValidDateSsnWithoutDash(RequiredMode separatorMode)
        {
            var checksumValidator = Substitute.For<IValidator>();

            GetValidator(separatorMode, checksumValidator).IsValid("7803257518");

            checksumValidator.Received().IsValid("7803257518");
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, false)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldReturnFalseForMultipleDashes(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("310108---8320"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, true)]
        [TestCase(RequiredMode.Required, true)]
        public void IsValid_ShouldHandleDashWithValidSsn(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("310108-8320"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(RequiredMode.None, true)]
        [TestCase(RequiredMode.Optional, true)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldHandleMissingDashWithValidSsn(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("3101088320"), Is.EqualTo(expected));
        }
    }
}