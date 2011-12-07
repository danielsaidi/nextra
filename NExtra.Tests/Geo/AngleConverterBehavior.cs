using System;
using NExtra.Geo;
using NExtra.Geo.Abstractions;
using NUnit.Framework;

namespace NExtra.Tests.Geo
{
    [TestFixture]
    public class AngleConverterBehavior
    {
        private IAngleConverter converter;


        [SetUp]
        public void SetUp()
        {
            converter = new AngleConverter();
        }


        [Test]
        public void ConvertDegreesToRadians_ShouldReturnCorrectValues()
        {
            Assert.That(converter.ConvertDegreesToRadians(0), Is.EqualTo(0));
            Assert.That(converter.ConvertDegreesToRadians(90), Is.EqualTo(Math.PI * 0.5));
            Assert.That(converter.ConvertDegreesToRadians(180), Is.EqualTo(Math.PI * 1.0));
            Assert.That(converter.ConvertDegreesToRadians(270), Is.EqualTo(Math.PI * 1.5));
            Assert.That(converter.ConvertDegreesToRadians(360), Is.EqualTo(Math.PI * 2.0));
        }

        [Test]
        public void ConvertRadiansToDegrees_ShouldReturnCorrectValues()
        {
            Assert.That(converter.ConvertRadiansToDegrees(0), Is.EqualTo(0));
            Assert.That(converter.ConvertRadiansToDegrees(Math.PI * 0.5), Is.EqualTo(90));
            Assert.That(converter.ConvertRadiansToDegrees(Math.PI * 1.0), Is.EqualTo(180));
            Assert.That(converter.ConvertRadiansToDegrees(Math.PI * 1.5), Is.EqualTo(270));
            Assert.That(converter.ConvertRadiansToDegrees(Math.PI * 2.0), Is.EqualTo(360));
        }
    }
}
