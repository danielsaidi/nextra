using NExtra.Geo;
using NUnit.Framework;

namespace NExtra.Tests.Geo
{
    [TestFixture]
    public class PositionDistanceCalculatorBehavior
    {
        private readonly Position _pos1 = new Position(10.1, 10.2);
        private readonly Position _pos2 = new Position(10.2, 10.3);

        private PositionDistanceCalculator _calculator;


        [SetUp]
        public void SetUp()
        {
            _calculator = new PositionDistanceCalculator(new AngleConverter());
        }


        [Test]
        public void CalculateDistance_ShouldReturnZeroKilometersForSamePosition()
        {
            Assert.That(_calculator.CalculateDistance(_pos1, _pos1, DistanceUnit.Kilometers), Is.EqualTo(0));
        }

        [Test]
        public void CalculateDistance_ShouldReturnZeroMilesForSamePosition()
        {
            Assert.That(_calculator.CalculateDistance(_pos1, _pos1, DistanceUnit.Miles), Is.EqualTo(0));
        }

        [Test]
        public void CalculateDistance_ShouldReturnCorrectKilometerValueForDifferentPositions()
        {
            Assert.That(_calculator.CalculateDistance(_pos1, _pos2, DistanceUnit.Kilometers), Is.EqualTo(15.59d));
        }

        [Test]
        public void CalculateDistance_ShouldReturnCorrectMileValueForDifferentPositions()
        {
            Assert.That(_calculator.CalculateDistance(_pos1, _pos2, DistanceUnit.Miles), Is.EqualTo(9.6899999999999995d));
        }

        [Test]
        public void CalculateRhumbDistance_ShouldReturnZeroKilometersForSamePosition()
        {
            Assert.That(_calculator.CalculateRhumbDistance(_pos1, _pos1, DistanceUnit.Kilometers), Is.EqualTo(0));
        }

        [Test]
        public void CalculateRhumbDistance_ShouldReturnZeroMilesForSamePosition()
        {
            Assert.That(_calculator.CalculateRhumbDistance(_pos1, _pos1, DistanceUnit.Miles), Is.EqualTo(0));
        }

        [Test]
        public void CalculateRhumbDistance_ShouldReturnCorrectKilometerValueForDifferentPositions()
        {
            Assert.That(_calculator.CalculateRhumbDistance(_pos1, _pos2, DistanceUnit.Kilometers), Is.EqualTo(15.592972833797754d));
        }

        [Test]
        public void CalculateRhumbDistance_ShouldReturnCorrectMileValueForDifferentPositions()
        {
            Assert.That(_calculator.CalculateRhumbDistance(_pos1, _pos2, DistanceUnit.Miles), Is.EqualTo(9.6883619491917568d));
        }
    }
}
