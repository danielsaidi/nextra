using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class StructExtensionsBehavior
    {
        [Test]
        public void IsDefault_ShouldReturnFalseForNonDefaultValues()
        {
            const int intValue = 1;
            const bool boolValue = true;
            const double doubleValue = 5;

            Assert.That(intValue.IsDefault(), Is.False);
            Assert.That(boolValue.IsDefault(), Is.False);
            Assert.That(doubleValue.IsDefault(), Is.False);
        }

        [Test]
        public void IsDefault_ShouldReturnTrueForDefaultValues()
        {
            const int intValue = 0;
            const bool boolValue = false;
            const double doubleValue = 0;

            Assert.That(intValue.IsDefault(), Is.True);
            Assert.That(boolValue.IsDefault(), Is.True);
            Assert.That(doubleValue.IsDefault(), Is.True);
        }
    }
}