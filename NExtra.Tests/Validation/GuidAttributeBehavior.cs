using System;
using NExtra.Validation;
using NUnit.Framework;

namespace NExtra.Tests.Validation
{
	[TestFixture]
	public class GuidAttributeBehavior
    {
        private IValidator validator;


        [SetUp]
        public void SetUp()
        {
            validator = new GuidAttribute();
        }


        [Test]
        public void IsValid_ShouldReturnTrueForNullValue()
        {
            Assert.That(validator.IsValid(null), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(validator.IsValid(""), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnFalseForInvalidString()
		{
			Assert.That(validator.IsValid("weghighuihgaweuihgweui"), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnTrueForValidStrings()
		{
			Assert.That(validator.IsValid(Guid.Empty), Is.True);
			Assert.That(validator.IsValid(Guid.NewGuid()), Is.True);
		}
	}
}