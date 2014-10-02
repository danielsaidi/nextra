using NExtra.Validation;
using NUnit.Framework;

namespace NExtra.Tests.Validation
{
	[TestFixture]
	public class LuhnAttributeBehavior
    {
        private IValidator _validator;


        [TestFixtureSetUp]
        public void SetUp()
        {
            _validator = new LuhnAttribute();
        }

        
        [Test]
        public void IsValid_ShouldReturnTrueForNullValue()
        {
            Assert.That(_validator.IsValid(null), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(_validator.IsValid(""), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForInvalidNumbers()
        {
            Assert.That(_validator.IsValid("7902237516"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForValidNumbers()
        {
            Assert.That(_validator.IsValid("7902237515"), Is.True);
        }
	}
}