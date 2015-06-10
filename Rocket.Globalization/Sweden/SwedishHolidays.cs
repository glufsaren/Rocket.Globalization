// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwedishHolidays.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the SwedishHolidays type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Rocket.Globalization.Sweden
{
    public class SwedishHolidays : IHolidays
    {
        private static IEnumerable<Holiday> holidays;

        // TODO: Static  ConcurrentDictionary?
        public IEnumerable<Holiday> Get(int year)
        {
            ////return LazyInitializer.EnsureInitialized(
            ////    ref holidays, () => AddHolidays(year));
            return AddHolidays(year);
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
                IsSunday = true
            };

            return year >= 1890
                ? new FixedDateHoliday(day, new DateTime(year, 05, 01))
                : null;
        }

        private static Holiday NationalDay(int year)
        {
            var day = new Day(HolidayCode.NationalDay)
            {
                Name = "Sveriges nationaldag",
                IsSunday = true
            };

            return year >= 2005
                ? new FixedDateHoliday(day, new DateTime(year, 06, 06))
                : null;
        }

        private static IEnumerable<Holiday> AddHolidays(int year)
        {
            var swedishHolidays = new List<Holiday>
                               {
                                   NewYearsDay(year),
                                   TwelfthNight(year),
                                   Epiphany(year),
                                   WalpurgisNight(year),
                                   WorkersDay(year),
                                   NationalDay(year)
                               };

            swedishHolidays.AddRange(
                new EasterHolidays().Get(year));

            return swedishHolidays
                .Where(holiday => holiday != null);
        }
    }
}
