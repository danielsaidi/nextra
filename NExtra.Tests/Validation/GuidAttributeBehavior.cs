using System;
using NExtra.Validation;
using NUnit.Framework;

namespace NExtra.Tests.Validation
{
	[TestFixture]
	public class GuidAttributeBehavior
    {
        private IValidator _validator;


        [TestFixtureSetUp]
        public void SetUp()
        {
            _validator = new GuidAttribute();
        }


        [Test]
        public void IsValid_ShouldReturnTrueForNullValue()
        {
            Assert.That(_validator.IsValid(null), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(_validator.IsValid(""), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnFalseForInvalidString()
		{
			Assert.That(_validator.IsValid("weghighuihgaweuihgweui"), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnTrueForValidStrings()
		{
			Assert.That(_validator.IsValid(Guid.Empty), Is.True);
			Assert.That(_validator.IsValid(Guid.NewGuid()), Is.True);
		}
	}
}