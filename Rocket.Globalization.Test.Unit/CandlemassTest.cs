// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CandlemassTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the CandlemassTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

using NUnit.Framework;

using Rocket.Globalization.Sweden;

using Should;

namespace Rocket.Globalization.Test.Unit
{
    [TestFixture]
    public class CandlemassTest
    {
        [Test]
        public void When_getting_candlemass_before_600_expect_no_holiday()
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(599);

            var candlemass = holidays.SingleOrDefault(holiday =>
                    holiday.Metadata.Code == HolidayCode.Candlemas);

            candlemass.ShouldBeNull();
        }

        [TestCase(1771, "1771-02-02")]
        public void When_getting_candlemass_earlier_expect_holiday_returned(int year, string date)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year);

            var candlemass = holidays.Single(holiday =>
                   holiday.Metadata.Code == HolidayCode.Candlemas);

            candlemass.Date.ShouldEqual(DateTime.Parse(date));
        }

        [TestCase(2008, "2008-02-03")]
        public void When_getting_candlemass_in_a_year_when_it_collides_with_quinquagesima_expect_no_candlemass_returned(int year, string date)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year).ToList();

            var quinquagesima = holidays.Single(holiday =>
                   holiday.Metadata.Code == HolidayCode.Quinquagesima);

            var candlemass = holidays.SingleOrDefault(holiday =>
                   holiday.Metadata.Code == HolidayCode.Candlemas);

            quinquagesima.Date.ShouldEqual(DateTime.Parse(date));
            candlemass.ShouldBeNull();
        }
    }
}