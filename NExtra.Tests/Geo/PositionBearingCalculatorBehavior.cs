using NExtra.Geo;
using NUnit.Framework;

namespace NExtra.Tests.Geo
{
    [TestFixture]
    public class PositionBearingCalculatorBehavior
    {
        private readonly Position _pos1 = new Position(10.1, 10.2);
        private readonly Position _pos2 = new Position(10.2, 10.3);

        private PositionBearingCalculator _calculator;


        [SetUp]
        public void SetUp()
        {
            _calculator = new PositionBearingCalculator(new AngleConverter());
        }


        [Test]
        public void CalculateBearing_ShouldReturnZeroForSamePosition()
        {
            Assert.That(_calculator.CalculateBearing(_pos1, _pos1), Is.EqualTo(0));
        }

        [Test]
        public void CalculateBearing_ShouldReturnCorrectForDifferentPositions()
        {
            Assert.That(_calculator.CalculateBearing(_pos1, _pos2), Is.EqualTo(44.53932685198231d));
        }

        [Test]
        public void CalculateRhumbBearing_ShouldReturnZeroForSamePosition()
        {
            Assert.That(_calculator.CalculateRhumbBearing(_pos1, _pos1), Is.EqualTo(0));
        }

        [Test]
        public void CalculateRhumbBearing_ShouldReturnCorrectForDifferentPositions()
        {
            Assert.That(_calculator.CalculateRhumbBearing(_pos1, _pos2), Is.EqualTo(44.548123371861152d));
        }

    }
}
