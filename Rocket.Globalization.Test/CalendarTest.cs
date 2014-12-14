// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwedishCalendarTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the SwedishCalendarTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using NUnit.Framework;

namespace Rocket.Globalization.Test
{
	[TestFixture]
	public class CalendarTest
	{
		[TestCase(1981, 4, 19)]
		[TestCase(2076, 4, 19)]
		[TestCase(1954, 4, 18)]
		[TestCase(2049, 4, 18)]
		[TestCase(2001, 4, 15)]
		[TestCase(1948, 3, 28)]
		[TestCase(326, 4, 3)]
		[TestCase(327, 3, 26)]
		[TestCase(328, 4, 14)]
		[TestCase(1581, 3, 26)]
		[TestCase(1582, 4, 15)]
		[TestCase(1583, 4, 10)]
		public void When_getting_date_for_easter_expect_date_returned(int year, int expectedMonth, int expectedDay)
		{
			var calendar = new SwedishHolidayFactory(year);

			var easter = calendar.Easter;

			Assert.AreEqual(new DateTime(year, expectedMonth, expectedDay), easter);
		}

		[Test]
		public void When_getting_maundy_thursday_expect_thursday_before_easter()
		{
			var calendar = new SwedishHolidayFactory(2014);

			var maundyThursday = calendar.MaundyThursday;

			Assert.AreEqual(new DateTime(2014, 04, 17), maundyThursday);
		}

		[Test]
		public void When_getting_good_friday_expect_thursday_before_easter()
		{
			var calendar = new SwedishHolidayFactory(2014);

			var goodFriday = calendar.GoodFriday;

			Assert.AreEqual(new DateTime(2014, 04, 18), goodFriday);
		}

		[Test]
		public void When_getting_holy_saturday_expect_thursday_before_easter()
		{
			var calendar = new SwedishHolidayFactory(2014);

			var holySaturday = calendar.HolySaturday;

			Assert.AreEqual(new DateTime(2014, 04, 19), holySaturday);
		}

		[Test]
		public void When_getting_easter_monday_expect_thursday_before_easter()
		{
			var calendar = new SwedishHolidayFactory(2014);

			var easterMonday = calendar.EasterMonday;

			Assert.AreEqual(new DateTime(2014, 04, 21), easterMonday);
		}
	}
}
