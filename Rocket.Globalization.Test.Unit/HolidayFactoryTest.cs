// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HolidayFactoryTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the HolidayFactoryTest type.
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
    public class HolidayFactoryTest
    {
        [Test]
        public void When_getting_workers_day_before_1890_expect_no_holiday()
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(1889);

            var workersDay = holidays.SingleOrDefault(holiday =>
                    holiday.Day.Code == HolidayCode.WorkersDay);

            workersDay.ShouldBeNull();
        }

        [TestCase(2003, "2003-06-09")]
        [TestCase(2004, "2004-05-31")]
        public void When_getting_pentecost_monday_2004_or_earlier_expect_holiday_returned(int year, string date)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year);

            var pentecostMonday = holidays.Single(holiday =>
                   holiday.Day.Code == HolidayCode.PentecostMonday);

            pentecostMonday.Date.ShouldEqual(DateTime.Parse(date));
        }

        [Test]
        public void When_getting_national_day_before_2005_expect_no_holiday()
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(2004);

            var workersDay = holidays.SingleOrDefault(holiday =>
                    holiday.Day.Code == HolidayCode.NationalDay);

            workersDay.ShouldBeNull();
        }

        [TestFixture]
        public class When_getting_swedish_holidays : BaseUnitTest
        {
            private HolidayFactory _holidayFactory;
            private IHolidays _swedishHolidays;
            private IEnumerable<Holiday> _holidays;
            private Holiday _maundyThursday;
            private Holiday _goodFriday;
            private Holiday _holySaturday;
            private Holiday _easter;
            private Holiday _easterMonday;
            private Holiday _ascensionThursday;
            private Holiday _pentecostEve;
            private Holiday _pentecost;
            private Holiday _newYearsDay;
            private Holiday _twelfthNight;
            private Holiday _epiphany;
            private Holiday _walpurgisNight;
            private Holiday _workersDay;
            private Holiday _pentecostMonday;
            private Holiday _nationalDay;

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
                _newYearsDay = GetHoliday(HolidayCode.NewYearsDay);
                _twelfthNight = GetHoliday(HolidayCode.TwelfthNight);
                _epiphany = GetHoliday(HolidayCode.Epiphany);
                _walpurgisNight = GetHoliday(HolidayCode.WalpurgisNight);
                _workersDay = GetHoliday(HolidayCode.WorkersDay);
                _nationalDay = GetHoliday(HolidayCode.NationalDay);

                _pentecostMonday = _holidays.SingleOrDefault(
                    holiday => holiday.Day.Code == HolidayCode.PentecostMonday);
            }

            [Test]
            public void It_gets_new_years_days()
            {
                _newYearsDay.Date.ShouldEqual(new DateTime(2015, 01, 01));
            }

            [Test]
            public void It_gets_twelfth_night()
            {
                _twelfthNight.Date.ShouldEqual(new DateTime(2015, 01, 05));
            }

            [Test]
            public void It_gets_epiphany()
            {
                _epiphany.Date.ShouldEqual(new DateTime(2015, 01, 06));
            }

            [Test]
            public void It_gets_maundry_thursday()
            {
                _maundyThursday.Date.ShouldEqual(new DateTime(2015, 04, 02));
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
            public void It_gets_walpurgis_night()
            {
                _walpurgisNight.Date.ShouldEqual(new DateTime(2015, 04, 30));
            }

            [Test]
            public void It_gets_workers_day()
            {
                _workersDay.Date.ShouldEqual(new DateTime(2015, 05, 01));
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
            public void It_does_not_get_pentecost_monday()
            {
                _pentecostMonday.ShouldBeNull();
            }

            [Test]
            public void It_gets_national_day()
            {
                _nationalDay.Date.ShouldEqual(new DateTime(2015, 06, 06));
            }

            private Holiday GetHoliday(HolidayCode code)
            {
                return _holidays.Single(holiday => holiday.Day.Code == code);
            }
        }
    }
}