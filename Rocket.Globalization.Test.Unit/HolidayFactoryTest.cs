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
                    holiday.Metadata.Code == HolidayCode.WorkersDay);

            workersDay.ShouldBeNull();
        }

        [TestCase(1570, "1570-05-18")]
        [TestCase(1571, "1571-05-18")]
        public void When_getting_eriks_day_before_1571_expect_holiday(int year, string date)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year);

            var eriksDay = holidays.Single(holiday =>
                    holiday.Metadata.Code == HolidayCode.EriksDay);

            eriksDay.Date.ShouldEqual(DateTime.Parse(date));
        }

        [TestCase(1570, "1570-12-27")]
        [TestCase(1571, "1571-12-27")]
        public void When_getting_third_christmas_day_before_1571_expect_holiday(int year, string date)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year);

            var thirdDayOfChristmas = holidays.Single(holiday =>
                    holiday.Metadata.Code == HolidayCode.ThirdDayOfChristmas);

            thirdDayOfChristmas.Date.ShouldEqual(DateTime.Parse(date));
        }

        [TestCase(1570, "1570-12-28")]
        [TestCase(1571, "1571-12-28")]
        public void When_getting_fourth_christmas_day_before_1571_expect_holiday(int year, string date)
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(year);

            var fourthDayOfChristmas = holidays.Single(holiday =>
                    holiday.Metadata.Code == HolidayCode.FourthDayOfChristmas);

            fourthDayOfChristmas.Date.ShouldEqual(DateTime.Parse(date));
        }

        [Test]
        public void When_getting_national_day_before_2005_expect_no_holiday()
        {
            var holidayFactory = new HolidayFactory();
            var swedishHolidays = holidayFactory.Create(Country.Sweden);

            var holidays = swedishHolidays.Get(2004);

            var workersDay = holidays.SingleOrDefault(holiday =>
                    holiday.Metadata.Code == HolidayCode.NationalDay);

            workersDay.ShouldBeNull();
        }

        [TestFixture]
        public class When_getting_swedish_holidays : BaseUnitTest
        {
            private HolidayFactory _holidayFactory;
            private Holidays _swedishHolidays;
            private IEnumerable<Holiday> _holidays;
            private Holiday _newYearsDay;
            private Holiday _twelfthNight;
            private Holiday _walpurgisNight;
            private Holiday _workersDay;
            private Holiday _nationalDay;
            private Holiday _midsummerEve;
            private Holiday _midsummer;
            private Holiday _halloween;
            private Holiday _allSaintsDay;
            private Holiday _allSaintsDay2;
            private Holiday _christmasEve;
            private Holiday _christmas;
            private Holiday _boxingDay;
            private Holiday _newYears;
            private Holiday _thirdDayOfChristmas;
            private Holiday _fourthDayOfChristmas;

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
                _newYearsDay = GetHoliday(HolidayCode.NewYearsDay);
                _twelfthNight = GetHoliday(HolidayCode.TwelfthNight);
                _walpurgisNight = GetHoliday(HolidayCode.WalpurgisNight);
                _workersDay = GetHoliday(HolidayCode.WorkersDay);
                _nationalDay = GetHoliday(HolidayCode.NationalDay);
                _midsummerEve = GetHoliday(HolidayCode.MidsummerEve);
                _midsummer = GetHoliday(HolidayCode.Midsummer);
                _halloween = GetHoliday(HolidayCode.Halloween);
                _allSaintsDay = GetHoliday(HolidayCode.AllSaintsDay);
                _allSaintsDay2 = GetHoliday(HolidayCode.AllSaintsDay2);
                _christmasEve = GetHoliday(HolidayCode.ChristmasEve);
                _christmas = GetHoliday(HolidayCode.Christmas);
                _boxingDay = GetHoliday(HolidayCode.BoxingDay);
                _newYears = GetHoliday(HolidayCode.NewYear);

                _thirdDayOfChristmas = _holidays.SingleOrDefault(
                    holiday => holiday.Metadata.Code == HolidayCode.ThirdDayOfChristmas);

                _fourthDayOfChristmas = _holidays.SingleOrDefault(
                    holiday => holiday.Metadata.Code == HolidayCode.FourthDayOfChristmas);
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
            public void It_gets_national_day()
            {
                _nationalDay.Date.ShouldEqual(new DateTime(2015, 06, 06));
            }

            [Test]
            public void It_gets_midsummer_eve()
            {
                _midsummerEve.Date.ShouldEqual(new DateTime(2015, 06, 19));
            }

            [Test]
            public void It_gets_midsummer()
            {
                _midsummer.Date.ShouldEqual(new DateTime(2015, 06, 20));
            }

            [Test]
            public void It_gets_halloween()
            {
                _halloween.Date.ShouldEqual(new DateTime(2015, 10, 30));
            }

            [Test]
            public void It_gets_all_saints_day()
            {
                _allSaintsDay.Date.ShouldEqual(new DateTime(2015, 10, 31));
            }

            [Test]
            public void It_gets_all_saints_day2()
            {
                _allSaintsDay2.Date.ShouldEqual(new DateTime(2015, 11, 01));
            }

            [Test]
            public void It_gets_christmas_eve()
            {
                _christmasEve.Date.ShouldEqual(new DateTime(2015, 12, 24));
            }

            [Test]
            public void It_gets_christmas()
            {
                _christmas.Date.ShouldEqual(new DateTime(2015, 12, 25));
            }

            [Test]
            public void It_gets_boxing_day()
            {
                _boxingDay.Date.ShouldEqual(new DateTime(2015, 12, 26));
            }

            [Test]
            public void It_gets_new_years()
            {
                _newYears.Date.ShouldEqual(new DateTime(2015, 12, 31));
            }

            [Test]
            public void It_gets_third_day_of_christmas()
            {
                _thirdDayOfChristmas.ShouldBeNull();
            }

            [Test]
            public void It_gets_fourth_day_of_christmas()
            {
                _fourthDayOfChristmas.ShouldBeNull();
            }

            private Holiday GetHoliday(HolidayCode code)
            {
                return _holidays.Single(holiday => holiday.Metadata.Code == code);
            }
        }
    }
}