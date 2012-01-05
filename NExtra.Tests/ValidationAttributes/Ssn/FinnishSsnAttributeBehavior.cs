using NExtra.Validation.Ssn;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes.Ssn
{
    [TestFixture]
    public class FinnishSsnValidatorBehavior
    {
        private static FinnishSsnAttribute GetValidator(SsnSeparatorMode separatorMode)
        {
            return new FinnishSsnAttribute(separatorMode);
        }


        [Test]
        [TestCase(SsnSeparatorMode.None, true)]
        [TestCase(SsnSeparatorMode.Optional, true)]
        [TestCase(SsnSeparatorMode.Required, true)]
        public void IsValid_ShouldReturnTrueForNullValue(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid(null), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, true)]
        [TestCase(SsnSeparatorMode.Optional, true)]
        [TestCase(SsnSeparatorMode.Required, true)]
        public void IsValid_ShouldReturnTrueForEmptyValue(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid(""), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForAlphaNumericalValue(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("abcdefghijklm"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("abcdefghi-jklm"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForTooFewCharacters(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300974498"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("300974-498"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForMultipleDashes(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300974---498S"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidMonth(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("301974498S"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("301974-498S"), Is.EqualTo(expected));

            //TODO: Checksum not calculated
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidDay(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("320974498S"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("320974-498S"), Is.EqualTo(expected));

            //TODO: Checksum not calculated
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidChecksum(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300964498S"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("300964-498S"), Is.EqualTo(expected));

            //TODO: Checksum calculated
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, true)]
        [TestCase(SsnSeparatorMode.Required, true)]
        public void IsValid_ShouldHandleValidDashedSsn(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300974-498S"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, true)]
        [TestCase(SsnSeparatorMode.Optional, true)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldHandleValidNonDashedSsn(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300974498S"), Is.EqualTo(expected));
        }
    }
}