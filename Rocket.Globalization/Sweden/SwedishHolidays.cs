// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwedishHolidays.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the SwedishHolidays type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Rocket.Globalization.Sweden
{
    public class SwedishHolidays : Holidays
    {
        // TODO: Static  ConcurrentDictionary?
        ////public IEnumerable<Holiday> Get(int year)
        ////{
        ////    ////return LazyInitializer.EnsureInitialized(
        ////    ////    ref holidays, () => AddHolidays(year));
        ////    return AddHolidays(year);
        ////}

        protected override void AddHolidays(int year)
        {
            var swedishHolidays = new List<Holiday>
                               {
                                   NewYearsDay(year),
                                   TwelfthNight(year),
                                   Epiphany(year),
                                   WalpurgisNight(year),
                                   WorkersDay(year),
                                   NationalDay(year),
                                   FeastOfTheAnnunciation(year),
                                   EriksDay(year),
                                   MidsummerEve(year),
                                   Midsummer(year),
                                   Halloween(year),
                                   AllSaintsDay(year),
                                   AllSaintsDay2(year),
                                   ChristmasEve(year),
                                   Christmas(year),
                                   BoxingDay(year),
                                   NewYear(year),
                                   ThirdDayOfChristmas(year),
                                   FourthDayOfChristmas(year)
                               };

            swedishHolidays.AddRange(
                new EasterHolidays().Get(year));

            _holidays.AddRange(swedishHolidays);
        }

        private static FixedDateHoliday NewYearsDay(int year)
        {
            var day = new Day(HolidayCode.NewYearsDay)
                  {
                      IsSunday = true,
                      Name = "Nyårsdagen"
                  };

            return new FixedDateHoliday(day, new DateTime(year, 01, 01));
        }

        private static FixedDateHoliday TwelfthNight(int year)
        {
            var day = new Day(HolidayCode.TwelfthNight)
                  {
                      Name = "Trettondagsafton"
                  };

            return new FixedDateHoliday(day, new DateTime(year, 01, 05));
        }

        private static FixedDateHoliday Epiphany(int year)
        {
            var day = new Day(HolidayCode.Epiphany)
                  {
                      IsSunday = true,
                      Name = "Trettondedag jul"
                  };

            return new FixedDateHoliday(day, new DateTime(year, 01, 06));
        }

        private static FixedDateHoliday WalpurgisNight(int year)
        {
            var day = new Day(HolidayCode.WalpurgisNight)
                  {
                      Name = "Valborgsmässoafton",
                      WorkTimeReduction = 4
                  };

            return new FixedDateHoliday(day, new DateTime(year, 04, 30));
        }

        private static Holiday WorkersDay(int year)
        {
            var day = new Day(HolidayCode.WorkersDay)
            {
                Name = "Första maj",
                IsSunday = true,
                Introduced = new DateTime(1892, 01, 01)
            };

            return new FixedDateHoliday(day, new DateTime(year, 05, 01));
        }

        private static Holiday NationalDay(int year)
        {
            var day = new Day(HolidayCode.NationalDay)
            {
                Name = "Sveriges nationaldag",
                IsSunday = true,
                Introduced = new DateTime(2005, 01, 01)
            };

            return new FixedDateHoliday(day, new DateTime(year, 06, 06));
        }

        private static Holiday FeastOfTheAnnunciation(int year)
        {
            var day = new Day(HolidayCode.FeastOfTheAnnunciation)
            {
                Name = "Jungfru Marie bebådelsedag",
                Deprecated = new DateTime(1954, 01, 01)
            };

            return new FixedDateHoliday(day, new DateTime(year, 03, 25));
        }

        private static Holiday EriksDay(int year)
        {
            var day = new Day(HolidayCode.EriksDay)
            {
                Name = "Eriksmässa",
                Deprecated = new DateTime(1572, 01, 01),
            };

            return new FixedDateHoliday(day, new DateTime(year, 05, 18));
        }

        private static Holiday MidsummerEve(int year)
        {
            var day = new Day(HolidayCode.MidsummerEve)
            {
                Name = "Midsommarafton",
                WorkTimeReduction = 8
            };

            return new DayOfWeekIntervalHoliday(
                            new DateTime(year, 06, 19),
                            new DateTime(year, 06, 25),
                            DayOfWeek.Friday,
                            day);
        }

        private static Holiday Midsummer(int year)
        {
            var day = new Day(HolidayCode.Midsummer)
            {
                Name = "Midsommardagen",
                WorkTimeReduction = 8
            };

            return new DayOfWeekIntervalHoliday(
                            new DateTime(year, 06, 20),
                            new DateTime(year, 06, 26),
                            DayOfWeek.Saturday,
                            day);
        }

        private static Holiday Halloween(int year)
        {
            var day = new Day(HolidayCode.Halloween)
            {
                Name = "Allhelgonaafton",
                WorkTimeReduction = 4
            };

            return new DayOfWeekIntervalHoliday(
                            new DateTime(year, 10, 30),
                            new DateTime(year, 11, 05),
                            DayOfWeek.Friday,
                            day);
        }

        private static Holiday AllSaintsDay(int year)
        {
            var day = new Day(HolidayCode.AllSaintsDay)
            {
                Name = "Alla helgons dag",
                IsSunday = true
            };

            return new DayOfWeekIntervalHoliday(
                            new DateTime(year, 10, 31),
                            new DateTime(year, 11, 06),
                            DayOfWeek.Saturday,
                            day);
        }

        private static Holiday AllSaintsDay2(int year)
        {
            var day = new Day(HolidayCode.AllSaintsDay2)
            {
                Name = "Allhelgonadagen",
                IsSunday = year <= 1953,
                WorkTimeReduction = year > 1953 ? 8 : 0,
            };

            return new FixedDateHoliday(day, new DateTime(year, 11, 01));
        }

        private static Holiday ChristmasEve(int year)
        {
            var day = new Day(HolidayCode.ChristmasEve)
            {
                Name = "Julafton",
                IsSaturday = true,
                WorkTimeReduction = 8,
            };

            return new FixedDateHoliday(day, new DateTime(year, 12, 24));
        }

        private static Holiday Christmas(int year)
        {
            var day = new Day(HolidayCode.Christmas)
            {
                Name = "Juldagen",
                IsSunday = true,
                WorkTimeReduction = 8,
            };

            return new FixedDateHoliday(day, new DateTime(year, 12, 25));
        }

        private static Holiday BoxingDay(int year)
        {
            var day = new Day(HolidayCode.BoxingDay)
            {
                Name = "Annandag jul",
                IsSunday = true,
                WorkTimeReduction = 8,
            };

            return new FixedDateHoliday(day, new DateTime(year, 12, 26));
        }

        private static Holiday NewYear(int year)
        {
            var day = new Day(HolidayCode.NewYear)
            {
                Name = "Nyårsafton",
                IsSaturday = true,
                WorkTimeReduction = 8,
            };

            return new FixedDateHoliday(day, new DateTime(year, 12, 31));
        }

        private static Holiday ThirdDayOfChristmas(int year)
        {
            var day = new Day(HolidayCode.ThirdDayOfChristmas)
            {
                Name = "Tredjedag jul",
                IsSunday = true,
                WorkTimeReduction = 8,
                Deprecated = new DateTime(1572, 01, 01)
            };

            return new FixedDateHoliday(day, new DateTime(year, 12, 27));
        }

        private static Holiday FourthDayOfChristmas(int year)
        {
            var day = new Day(HolidayCode.FourthDayOfChristmas)
            {
                Name = "Fjärdedag jul",
                IsSunday = true,
                WorkTimeReduction = 8,
                Deprecated = new DateTime(1572, 01, 01)
            };

            return new FixedDateHoliday(day, new DateTime(year, 12, 28));
        }
    }
}
