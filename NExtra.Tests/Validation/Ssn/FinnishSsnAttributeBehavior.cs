using NExtra.Validation.Ssn;
using NUnit.Framework;

namespace NExtra.Tests.Validation.Ssn
{
    [TestFixture]
    public class FinnishSsnValidatorBehavior
    {
        private static FinnishSsnAttribute GetValidator(RequiredMode separatorMode)
        {
            return new FinnishSsnAttribute(separatorMode);
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
        public void IsValid_ShouldReturnTrueForEmptyValue(RequiredMode separatorMode, bool expected)
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
            Assert.That(GetValidator(separatorMode).IsValid("abcdefghi-jklm"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, false)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldReturnFalseForTooFewCharacters(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300974498"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("300974-498"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, false)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldReturnFalseForMultipleDashes(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300974---498S"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, false)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidMonth(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("301974498S"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("301974-498S"), Is.EqualTo(expected));

            //TODO: Checksum not calculated
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, false)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidDay(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("320974498S"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("320974-498S"), Is.EqualTo(expected));

            //TODO: Checksum not calculated
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, false)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidChecksum(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300964498S"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("300964-498S"), Is.EqualTo(expected));

            //TODO: Checksum calculated
        }

        [Test]
        [TestCase(RequiredMode.None, false)]
        [TestCase(RequiredMode.Optional, true)]
        [TestCase(RequiredMode.Required, true)]
        public void IsValid_ShouldHandleValidDashedSsn(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300974-498S"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(RequiredMode.None, true)]
        [TestCase(RequiredMode.Optional, true)]
        [TestCase(RequiredMode.Required, false)]
        public void IsValid_ShouldHandleValidNonDashedSsn(RequiredMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300974498S"), Is.EqualTo(expected));
        }
    }
}