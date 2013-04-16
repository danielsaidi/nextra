using NExtra.Geo;
using NUnit.Framework;

namespace NExtra.Tests.Geo
{
    [TestFixture]
    public class PositionHandlerBehavior
    {
        private readonly Position pos1 = new Position(10.1, 10.2);
        private readonly Position pos2 = new Position(10.2, 10.3);

        private PositionHandler handler;


        [SetUp]
        public void SetUp()
        {
            handler = new PositionHandler();
        }


        [Test]
        public void CalculateDistance_ShouldReturnZeroKilometersForSamePosition()
        {
            Assert.That(handler.CalculateDistance(pos1, pos1, DistanceUnit.Kilometers), Is.EqualTo(0));
        }

        [Test]
        public void CalculateDistance_ShouldReturnZeroMilesForSamePosition()
        {
            Assert.That(handler.CalculateDistance(pos1, pos1, DistanceUnit.Miles), Is.EqualTo(0));
        }

        [Test]
        public void CalculateDistance_ShouldReturnCorrectKilometerValueForDifferentPositions()
        {
            Assert.That(handler.CalculateDistance(pos1, pos2, DistanceUnit.Kilometers), Is.EqualTo(15.59d));
        }

        [Test]
        public void CalculateDistance_ShouldReturnCorrectMileValueForDifferentPositions()
        {
            Assert.That(handler.CalculateDistance(pos1, pos2, DistanceUnit.Miles), Is.EqualTo(9.6899999999999995d));
        }

        [Test]
        public void CalculateRhumbBearing_ShouldReturnZeroForSamePosition()
        {
            Assert.That(handler.CalculateRhumbBearing(pos1, pos1), Is.EqualTo(0));
        }

        [Test]
        public void CalculateRhumbBearing_ShouldReturnCorrectForDifferentPositions()
        {
            Assert.That(handler.CalculateRhumbBearing(pos1, pos2), Is.EqualTo(44.548123371861152d));
        }

        [Test]
        public void CalculateRhumbDistance_ShouldReturnZeroKilometersForSamePosition()
        {
            Assert.That(handler.CalculateRhumbDistance(pos1, pos1, DistanceUnit.Kilometers), Is.EqualTo(0));
        }

        [Test]
        public void CalculateRhumbDistance_ShouldReturnZeroMilesForSamePosition()
        {
            Assert.That(handler.CalculateRhumbDistance(pos1, pos1, DistanceUnit.Miles), Is.EqualTo(0));
        }

        [Test]
        public void CalculateRhumbDistance_ShouldReturnCorrectKilometerValueForDifferentPositions()
        {
            Assert.That(handler.CalculateRhumbDistance(pos1, pos2, DistanceUnit.Kilometers), Is.EqualTo(15.592972833797754d));
        }

        [Test]
        public void CalculateRhumbDistance_ShouldReturnCorrectMileValueForDifferentPositions()
        {
            Assert.That(handler.CalculateRhumbDistance(pos1, pos2, DistanceUnit.Miles), Is.EqualTo(9.6883619491917568d));
        }
    }
}
