using System;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class DateTimeExtensionsBehavior
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
		public void GetFirstDateOfWeek_ShouldHandleMinValue()
		{
			Assert.That(DateTime.MinValue.GetFirstDateOfWeek(), Is.EqualTo(DateTime.MinValue));
		}

		[Test]
		public void GetFirstDateOfWeek_041231ShouldReturn041227()
		{
			Assert.That(new DateTime(2004, 12, 31).GetFirstDateOfWeek(), Is.EqualTo(new DateTime(2004, 12, 27)));
		}

		[Test]
		public void GetFirstDateOfWeek_050101ShouldReturn041227()
		{
			Assert.That(new DateTime(2005, 01, 01).GetFirstDateOfWeek(), Is.EqualTo(new DateTime(2004, 12, 27)));
		}

		[Test]
		public void GetFirstDateOfWeek_051231ShouldReturn051226()
		{
			Assert.That(new DateTime(2005, 12, 31).GetFirstDateOfWeek(), Is.EqualTo(new DateTime(2005, 12, 26)));
		}

		[Test]
		public void GetFirstDateOfWeek_060101ShouldReturn051226()
		{
			Assert.That(new DateTime(2006, 01, 01).GetFirstDateOfWeek(), Is.EqualTo(new DateTime(2005, 12, 26)));
		}

		[Test]
		public void GetFirstDateOfWeek_081231ShouldReturn081229()
		{
			Assert.That(new DateTime(2008, 12, 31).GetFirstDateOfWeek(), Is.EqualTo(new DateTime(2008, 12, 29)));
		}

		[Test]
		public void GetFirstDateOfWeek_090101ShouldReturn090101()
		{
			Assert.That(new DateTime(2009, 01, 01).GetFirstDateOfWeek(), Is.EqualTo(new DateTime(2009, 01, 01)));
		}


		[Test]
		public void GetFirstDateOfWeek_Iso8601_081231ShouldReturn081229()
		{
			Assert.That(new DateTime(2008, 12, 31).GetFirstDateOfWeek(true), Is.EqualTo(new DateTime(2008, 12, 29)));
		}

		[Test]
		public void GetFirstDateOfWeek_Iso8601_090101ShouldReturn081229()
		{
			Assert.That(new DateTime(2009, 01, 01).GetFirstDateOfWeek(true), Is.EqualTo(new DateTime(2008, 12, 29)));
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
		public void GetLastDateOfWeek_ShouldHandleMaxValue()
		{
			Assert.That(DateTime.MaxValue.GetLastDateOfWeek(), Is.EqualTo(DateTime.MaxValue));
		}

		[Test]
		public void GetLastDateOfWeek_041231ShouldReturn050102()
		{
			Assert.That(new DateTime(2004, 12, 31).GetLastDateOfWeek(), Is.EqualTo(new DateTime(2005, 01, 02)));
		}

		[Test]
		public void GetLastDateOfWeek_050101ShouldReturn050102()
		{
			Assert.That(new DateTime(2005, 01, 01).GetLastDateOfWeek(), Is.EqualTo(new DateTime(2005, 01, 02)));
		}

		[Test]
		public void GetLastDateOfWeek_051231ShouldReturn060101()
		{
			Assert.That(new DateTime(2005, 12, 31).GetLastDateOfWeek(), Is.EqualTo(new DateTime(2006, 01, 01)));
		}

		[Test]
		public void GetLastDateOfWeek_060101ShouldReturn060101()
		{
			Assert.That(new DateTime(2006, 01, 01).GetLastDateOfWeek(), Is.EqualTo(new DateTime(2006, 01, 01)));
		}

		[Test]
		public void GetLastDateOfWeek_081231ShouldReturn081231()
		{
			Assert.That(new DateTime(2008, 12, 31).GetLastDateOfWeek(), Is.EqualTo(new DateTime(2008, 12, 31)));
		}

		[Test]
		public void GetLastDateOfWeek_090101ShouldReturn090104()
		{
			Assert.That(new DateTime(2009, 01, 01).GetLastDateOfWeek(), Is.EqualTo(new DateTime(2009, 01, 04)));
		}


		[Test]
		public void GetLastDateOfWeek_Iso8601_081231ShouldReturn090104()
		{
			Assert.That(new DateTime(2008, 12, 31).GetLastDateOfWeek(true), Is.EqualTo(new DateTime(2009, 01, 04)));
		}

		[Test]
		public void GetLastDateOfWeek_Iso8601_090101ShouldReturn090104()
		{
			Assert.That(new DateTime(2009, 01, 01).GetLastDateOfWeek(), Is.EqualTo(new DateTime(2009, 01, 04)));
		}


		[Test]
		public void GetWeekNumber_ShouldHandleMinValue()
		{
			var week = DateTime.MinValue.GetWeekNumber();
			Assert.That(week, Is.GreaterThan(0));
			Assert.That(week, Is.LessThanOrEqualTo(53));
		}

		[Test]
		public void GetWeekNumber_ShouldHandleMaxValue()
		{
			var week = DateTime.MaxValue.GetWeekNumber();
			Assert.That(week, Is.GreaterThan(0));
			Assert.That(week, Is.LessThanOrEqualTo(53));
		}

		[Test]
		public void GetWeekNumber_041231ShouldReturn53()
		{
			Assert.That(new DateTime(2004, 12, 31).GetWeekNumber(), Is.EqualTo(53));
		}

		[Test]
		public void GetWeekNumber_050101ShouldReturn53()
		{
			Assert.That(new DateTime(2005, 01, 01).GetWeekNumber(), Is.EqualTo(53));
		}

		[Test]
		public void GetWeekNumber_061231ShouldReturn52()
		{
			Assert.That(new DateTime(2006, 12, 31).GetWeekNumber(), Is.EqualTo(52));
		}

		[Test]
		public void GetWeekNumber_070101ShouldReturn1()
		{
			Assert.That(new DateTime(2007, 01, 01).GetWeekNumber(), Is.EqualTo(1));
		}

		[Test]
		public void GetWeekNumber_081231ShouldReturn53()
		{
			Assert.That(new DateTime(2008, 12, 31).GetWeekNumber(), Is.EqualTo(53));
		}

		[Test]
		public void GetWeekNumber_090101ShouldReturn1()
		{
			Assert.That(new DateTime(2009, 01, 01).GetWeekNumber(), Is.EqualTo(1));
		}


		[Test]
		public void GetWeekNumber_Iso8601_081231ShouldReturn1()
		{
			Assert.That(new DateTime(2008, 12, 31).GetWeekNumber(true), Is.EqualTo(1));
		}

		[Test]
		public void GetWeekNumber_Iso8601_090101ShouldReturn1()
		{
			Assert.That(new DateTime(2009, 01, 01).GetWeekNumber(true), Is.EqualTo(1));
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