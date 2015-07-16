// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EasterHolidayFactoryTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the EasterHolidayFactoryTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using Rocket.Globalization.Sweden;
using Rocket.Test;

using Should;

namespace Rocket.Globalization.Test.Unit
{
    [TestFixture]
    public class EasterHolidayFactoryTest
    {
        [TestCase(2003, "2003-06-09")]
        [TestCase(2004, "2004-05-31")]
        public void When_getting_pentecost_monday_2004_or_earlier_expect_holiday_returned(int year, string date)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year);

            var pentecostMonday = holidays.Single(holiday =>
                   holiday.Metadata.Code == HolidayCode.PentecostMonday);

            pentecostMonday.Date.ShouldEqual(DateTime.Parse(date));
        }

        [TestCase(1953, "1953-03-25")]
        [TestCase(1952, "1952-03-25")]
        public void When_getting_feast_of_the_annunciation_before_1953_expect_holiday(int year, string date)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year);

            var feastOfTheAnnunciation = holidays.Single(holiday =>
                    holiday.Metadata.Code == HolidayCode.FeastOfTheAnnunciation);

            feastOfTheAnnunciation.Date.ShouldEqual(DateTime.Parse(date));
        }

        [TestCase(1770)]
        [TestCase(1771)]
        public void When_getting_maundry_thursday_before_1771_expect_its_a_sunday(int year)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year);

            var maundyThursday = holidays.Single(holiday =>
                    holiday.Metadata.Code == HolidayCode.MaundyThursday);

            maundyThursday.Metadata.IsSunday.ShouldBeTrue();
        }

        [TestCase(1770, "1770-04-17")]
        [TestCase(1771, "1771-04-02")]
        public void When_getting_easter_tuesday_before_1772_expect_holiday(int year, string date)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year);

            var easterTuesday = holidays.Single(holiday =>
                    holiday.Metadata.Code == HolidayCode.EasterTuesday);

            easterTuesday.Date.ShouldEqual(DateTime.Parse(date));
        }

        [TestCase(1770, "1770-04-18")]
        [TestCase(1771, "1771-04-03")]
        public void When_getting_easter_wednesday_before_1772_expect_holiday(int year, string date)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year);

            var easterWednesday = holidays.Single(holiday =>
                    holiday.Metadata.Code == HolidayCode.EasterWednesday);

            easterWednesday.Date.ShouldEqual(DateTime.Parse(date));
        }

        [TestCase(1770, "1770-06-05")]
        [TestCase(1771, "1771-05-21")]
        public void When_getting_pentecost_tuesday_before_1772_expect_holiday(int year, string date)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year);

            var easterTuesday = holidays.Single(holiday =>
                    holiday.Metadata.Code == HolidayCode.PentecostTuesday);

            easterTuesday.Date.ShouldEqual(DateTime.Parse(date));
        }

        [TestCase(1770, "1770-06-06")]
        [TestCase(1771, "1771-05-22")]
        public void When_getting_pentecost_wednesday_before_1772_expect_holiday(int year, string date)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year);

            var easterWednesday = holidays.Single(holiday =>
                    holiday.Metadata.Code == HolidayCode.PentecostWednesday);

            easterWednesday.Date.ShouldEqual(DateTime.Parse(date));
        }

        [TestFixture]
        public class When_getting_swedish_holidays : BaseUnitTest
        {
            private HolidayFactory _holidayFactory;
            private Holidays _swedishHolidays;
            private IEnumerable<Holiday> _holidays;
            private Holiday _maundyThursday;
            private Holiday _goodFriday;
            private Holiday _holySaturday;
            private Holiday _easter;
            private Holiday _easterMonday;
            private Holiday _easterTuesday;
            private Holiday _easterWednesday;
            private Holiday _ascensionThursday;
            private Holiday _pentecostEve;
            private Holiday _pentecost;
            private Holiday _epiphany;
            private Holiday _pentecostMonday;
            private Holiday _pentecostTuesday;
            private Holiday _pentecostWednesday;
            private Holiday _candlemass;
            private Holiday _quinquagesima;

            protected override void Arrange()
            {
                _holidayFactory = new HolidayFactory();
                _swedishHolidays = _holidayFactory.Create(Country.Sweden);
            }

            protected override void Act()
            {
                _holidays = _swedishHolidays.Get(2015);
            }

            protected override void Assemble()
            {
                _maundyThursday = GetHoliday(HolidayCode.MaundyThursday);
                _goodFriday = GetHoliday(HolidayCode.GoodFriday);
                _holySaturday = GetHoliday(HolidayCode.HolySaturday);
                _easter = GetHoliday(HolidayCode.Easter);
                _easterMonday = GetHoliday(HolidayCode.EasterMonday);
                _ascensionThursday = GetHoliday(HolidayCode.AscensionThursday);
                _pentecostEve = GetHoliday(HolidayCode.PentecostEve);
                _pentecost = GetHoliday(HolidayCode.Pentecost);
                _epiphany = GetHoliday(HolidayCode.Epiphany);
                _quinquagesima = GetHoliday(HolidayCode.Quinquagesima);

                _pentecostMonday = _holidays.SingleOrDefault(
                    holiday => holiday.Metadata.Code == HolidayCode.PentecostMonday);

                _pentecostTuesday = _holidays.SingleOrDefault(
                    holiday => holiday.Metadata.Code == HolidayCode.PentecostTuesday);

                _pentecostWednesday = _holidays.SingleOrDefault(
                    holiday => holiday.Metadata.Code == HolidayCode.PentecostWednesday);

                _candlemass = _holidays.SingleOrDefault(
                    holiday => holiday.Metadata.Code == HolidayCode.Candlemas);

                _easterTuesday = _holidays.SingleOrDefault(
                    holiday => holiday.Metadata.Code == HolidayCode.EasterTuesday);

                _easterWednesday = _holidays.SingleOrDefault(
                    holiday => holiday.Metadata.Code == HolidayCode.EasterWednesday);
            }

            [Test]
            public void It_gets_epiphany()
            {
                _epiphany.Date.ShouldEqual(new DateTime(2015, 01, 06));
            }

            [Test]
            public void It_should_not_get_candlemass()
            {
                _candlemass.Date.ShouldEqual(new DateTime(2015, 02, 08));
            }

            [Test]
            public void It_gets_maundry_thursday()
            {
                _maundyThursday.Date.ShouldEqual(new DateTime(2015, 04, 02));
            }

            [Test]
            public void It_maundry_thursday_should_not_be_a_sunday()
            {
                _maundyThursday.Metadata.IsSunday.ShouldBeFalse();
            }

            [Test]
            public void It_gets_good_friday()
            {
                _goodFriday.Date.ShouldEqual(new DateTime(2015, 04, 03));
            }

            [Test]
            public void It_gets_holy_saturday()
            {
                _holySaturday.Date.ShouldEqual(new DateTime(2015, 04, 04));
            }

            [Test]
            public void It_gets_easter()
            {
                _easter.Date.ShouldEqual(new DateTime(2015, 04, 05));
            }

            [Test]
            public void It_gets_easter_monday()
            {
                _easterMonday.Date.ShouldEqual(new DateTime(2015, 04, 06));
            }

            [Test]
            public void It_gets_easter_tuesday()
            {
                _easterTuesday.ShouldBeNull();
            }

            [Test]
            public void It_gets_easter_wednesday()
            {
                _easterWednesday.ShouldBeNull();
            }

            [Test]
            public void It_gets_ascension_thursday()
            {
                _ascensionThursday.Date.ShouldEqual(new DateTime(2015, 05, 14));
            }

            [Test]
            public void It_gets_pentecost_eve()
            {
                _pentecostEve.Date.ShouldEqual(new DateTime(2015, 05, 23));
            }

            [Test]
            public void It_gets_pentecost()
            {
                _pentecost.Date.ShouldEqual(new DateTime(2015, 05, 24));
            }

            [Test]
            public void It_gets_pentecost_tuesday()
            {
                _pentecostTuesday.ShouldBeNull();
            }

            [Test]
            public void It_gets_pentecost_wednesday()
            {
                _pentecostWednesday.ShouldBeNull();
            }

            [Test]
            public void It_does_not_get_pentecost_monday()
            {
                _pentecostMonday.ShouldBeNull();
            }

            [Test]
            public void It_gets_quinquagesima()
            {
                _quinquagesima.Date.ShouldEqual(new DateTime(2015, 02, 15));
            }

            private Holiday GetHoliday(HolidayCode code)
            {
                return _holidays.Single(holiday => holiday.Metadata.Code == code);
            }
        }
    }
}