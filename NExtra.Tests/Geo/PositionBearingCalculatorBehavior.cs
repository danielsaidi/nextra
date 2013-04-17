using NExtra.Geo;
using NUnit.Framework;

namespace NExtra.Tests.Geo
{
    [TestFixture]
    public class PositionBearingCalculatorBehavior
    {
        private readonly Position pos1 = new Position(10.1, 10.2);
        private readonly Position pos2 = new Position(10.2, 10.3);

        private PositionBearingCalculator calculator;


        [SetUp]
        public void SetUp()
        {
            calculator = new PositionBearingCalculator(new AngleConverter());
        }


        [Test]
        public void CalculatePositionBearing_ShouldReturnZeroForSamePosition()
        {
            Assert.That(calculator.CalculatePositionBearing(pos1, pos1), Is.EqualTo(0));
        }

        [Test]
        public void CalculatePositionBearing_ShouldReturnCorrectForDifferentPositions()
        {
            Assert.That(calculator.CalculatePositionBearing(pos1, pos2), Is.EqualTo(44.53932685198231d));
        }

        [Test]
        public void CalculatePositionRhumbBearing_ShouldReturnZeroForSamePosition()
        {
            Assert.That(calculator.CalculatePositionRhumbBearing(pos1, pos1), Is.EqualTo(0));
        }

        [Test]
        public void CalculatePositionRhumbBearing_ShouldReturnCorrectForDifferentPositions()
        {
            Assert.That(calculator.CalculatePositionRhumbBearing(pos1, pos2), Is.EqualTo(44.548123371861152d));
        }

    }
}
