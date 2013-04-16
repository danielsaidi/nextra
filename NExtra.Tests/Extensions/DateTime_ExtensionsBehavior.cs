using System;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class DateTime_ExtensionsBehavior
    {
        [Test]
        public void GetFirstDateOfMonth_ShouldHandleMinValue()
        {
            Assert.That(DateTime.MinValue.GetFirstDateOfMonth(), Is.EqualTo(DateTime.MinValue));
        }

        [Test]
        public void GetFirstDateOfMonth_ShouldHandleValidDates()
        {
            for (var i = 1; i <= 12; i++)
                Assert.That(new DateTime(2009, i, 20).GetFirstDateOfMonth(), Is.EqualTo(new DateTime(2009, i, 01)));
        }

        [Test]
        public void GetLastDateOfMonth_ShouldHandleMaxValue()
        {
            Assert.That(DateTime.MaxValue.GetLastDateOfMonth(), Is.EqualTo(DateTime.MaxValue));
        }

        [Test]
        public void GetLastDateOfMonth_ShouldHandle28DayMonth()
        {
            Assert.That(new DateTime(2009, 02, 01).GetLastDateOfMonth(), Is.EqualTo(new DateTime(2009, 02, 28)));
        }

        [Test]
        public void GetLastDateOfMonth_ShouldHandle29DayMonth()
        {
            Assert.That(new DateTime(2008, 02, 01).GetLastDateOfMonth(), Is.EqualTo(new DateTime(2008, 02, 29)));
        }

        [Test]
        public void GetLastDateOfMonth_ShouldHandle30DayMonth()
        {
            Assert.That(new DateTime(2009, 04, 01).GetLastDateOfMonth(), Is.EqualTo(new DateTime(2009, 04, 30)));
        }

        [Test]
        public void GetLastDateOfMonth_ShouldHandle31DayMonth()
        {
            Assert.That(new DateTime(2009, 01, 01).GetLastDateOfMonth(), Is.EqualTo(new DateTime(2009, 01, 31)));
        }

        [Test]
        public void IsSameDate_ShouldReturnFalseForDifferentDate()
        {
            Assert.That(new DateTime(2007, 01, 01, 01, 01, 01).IsSameDate(new DateTime(2008, 01, 01, 01, 02, 03)), Is.False);
        }

        [Test]
        public void IsSameDate_ShouldReturnTrueForSameDate()
        {
            Assert.That(new DateTime(2007, 01, 01, 01, 01, 01).IsSameDate(new DateTime(2007, 01, 01, 01, 02, 03)), Is.True);
        }
    }
}