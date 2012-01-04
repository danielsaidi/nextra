using NExtra.ValidationAttributes.Ssn;
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
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForTooFewDigigt(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300974498"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidSsn(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300964498S"), Is.EqualTo(expected));
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
        [TestCase(SsnSeparatorMode.Optional, true)]
        [TestCase(SsnSeparatorMode.Required, true)]
        public void IsValid_ShouldHandleDashWithValidSsn(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300974-498S"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, true)]
        [TestCase(SsnSeparatorMode.Optional, true)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldHandleMissingDashWithValidSsn(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("300974498S"), Is.EqualTo(expected));
        }
    }
}