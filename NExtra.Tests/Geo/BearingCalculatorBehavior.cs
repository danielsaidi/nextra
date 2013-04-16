using NExtra.Geo;
using NUnit.Framework;

namespace NExtra.Tests.Geo
{
    [TestFixture]
    public class BearingCalculatorBehavior
    {
        private readonly Position pos1 = new Position(10.1, 10.2);
        private readonly Position pos2 = new Position(10.2, 10.3);

        private BearingCalculator handler;


        [SetUp]
        public void SetUp()
        {
            handler = new BearingCalculator(new AngleConverter());
        }


        [Test]
        public void CalculateBearing_ShouldReturnZeroForSamePosition()
        {
            Assert.That(handler.CalculateBearing(pos1, pos1), Is.EqualTo(0));
        }

        [Test]
        public void CalculateBearing_ShouldReturnCorrectForDifferentPositions()
        {
            Assert.That(handler.CalculateBearing(pos1, pos2), Is.EqualTo(44.53932685198231d));
        }
    }
}
