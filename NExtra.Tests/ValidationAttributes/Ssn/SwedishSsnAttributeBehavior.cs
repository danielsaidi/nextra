using NExtra.ValidationAttributes.Ssn;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes.Ssn
{
    [TestFixture]
    public class SwedishSsnValidatorBehavior
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        private static SwedishSsnAttribute GetValidator(SsnSeparatorMode separatorMode)
        {
            return new SwedishSsnAttribute(separatorMode);
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
        public void IsValid_ShouldReturnTrueForEmptyString(SsnSeparatorMode separatorMode, bool expected)
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
            Assert.That(GetValidator(separatorMode).IsValid("abcdefgh-ijklm"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForTooFewDigits(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("780325751"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("780325-751"), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidMonth(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("313108-8320"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("3131088320"), Is.EqualTo(expected));

            //TODO: Luhn NOT called
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidDay(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("310138-8320"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("3101388320"), Is.EqualTo(expected));

            //TODO: Luhn NOT called
        }

        [Test]
        [TestCase(SsnSeparatorMode.None, false)]
        [TestCase(SsnSeparatorMode.Optional, false)]
        [TestCase(SsnSeparatorMode.Required, false)]
        public void IsValid_ShouldReturnFalseForInvalidChecksum(SsnSeparatorMode separatorMode, bool expected)
        {
            Assert.That(GetValidator(separatorMode).IsValid("7803257518"), Is.EqualTo(expected));
            Assert.That(GetValidator(separatorMode).IsValid("780325-7518"), Is.EqualTo(expected));

            //TODO: Luhn called if expected
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