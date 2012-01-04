using NExtra.ValidationAttributes.Ssn;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes.Ssn
{
    [TestFixture]
    public class SwedishSsnValidatorBehavior
    {
        private static SwedishSsnAttribute GetValidator(SsnSeparatorMode separatorMode)
        {
            return new SwedishSsnAttribute(separatorMode);
        }


        [Test]
        [TestCase(SsnSeparatorMode.None, true)]
        [TestCase(SsnSeparatorMode.Optional, true)]
        [TestCase(SsnSeparatorMode.Required, true)]
        public void IsValid_ShouldReturnFalseForNullValue(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid(null), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, true)]
        [TestCase(SsnSeparatorMode.Optional, true)]
        [TestCase(SsnSeparatorMode.Required, true)]
        public void IsValid_ShouldReturnFalseForEmptyString(SsnSeparatorMode separatorMode, bool expected)
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
            Assert.That(GetValidator(separatorMode).IsValid("780325751"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidSsn(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("7803257518"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForMultipleDashes(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("310108---8320"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, true)]
        [TestCase(SsnSeparatorMode.Required, true)]
        public void IsValid_ShouldHandleDashWithValidSsn(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("310108-8320"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, true)]
        [TestCase(SsnSeparatorMode.Optional, true)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldHandleMissingDashWithValidSsn(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("3101088320"), Is.EqualTo(expected));
        }
    }
}