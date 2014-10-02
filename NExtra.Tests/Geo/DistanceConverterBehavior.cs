using NExtra.Geo;
using NUnit.Framework;

namespace NExtra.Tests.Geo
{
    [TestFixture]
    public class DistanceConverterBehavior
    {
        private IDistanceConverter _converter;


        [SetUp]
        public void SetUp()
        {
            _converter = new DistanceConverter();
        }


        [Test]
        public void ConvertKilometersToMiles_ShouldReturnCorrectValues()
        {
            Assert.That(_converter.ConvertKilometersToMiles(0), Is.EqualTo(0));
            Assert.That(_converter.ConvertKilometersToMiles(1), Is.EqualTo(0.62137119200000002d));
        }

        [Test]
        public void ConvertMilesToKilometers_ShouldReturnCorrectValues()
        {
            Assert.That(_converter.ConvertMilesToKilometers(0), Is.EqualTo(0));
            Assert.That(_converter.ConvertMilesToKilometers(1), Is.EqualTo(1.6093440000000001d));
        }
    }
}
