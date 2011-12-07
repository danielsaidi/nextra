using NExtra.Geo;
using NExtra.Geo.Abstractions;
using NUnit.Framework;

namespace NExtra.Tests.Geo
{
    [TestFixture]
    public class DistanceConverterBehavior
    {
        private IDistanceConverter converter;


        [SetUp]
        public void SetUp()
        {
            converter = new DistanceConverter();
        }


        [Test]
        public void ConvertKilometersToMiles_ShouldReturnCorrectValues()
        {
            Assert.That(converter.ConvertKilometersToMiles(0), Is.EqualTo(0));
            Assert.That(converter.ConvertKilometersToMiles(1), Is.EqualTo(0.62137119200000002d));
        }

        [Test]
        public void ConvertMilesToKilometers_ShouldReturnCorrectValues()
        {
            Assert.That(converter.ConvertMilesToKilometers(0), Is.EqualTo(0));
            Assert.That(converter.ConvertMilesToKilometers(1), Is.EqualTo(1.6093440000000001d));
        }
    }
}
