using NExtra.Validation;
using NUnit.Framework;

namespace NExtra.Tests.Validation
{
	[TestFixture]
	public class LuhnAttributeBehavior
    {
        private IValidator validator;


        [SetUp]
        public void SetUp()
        {
            validator = new LuhnAttribute();
        }

        
        [Test]
        public void IsValid_ShouldReturnTrueForNullValue()
        {
            Assert.That(validator.IsValid(null), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(validator.IsValid(""), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForInvalidNumbers()
        {
            Assert.That(validator.IsValid("7902237516"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForValidNumbers()
        {
            Assert.That(validator.IsValid("7902237515"), Is.True);
        }
	}
}