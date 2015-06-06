// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EasterHolidays.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the EasterHolidays type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Rocket.Globalization.Computus;

namespace Rocket.Globalization.Sweden
{
    public class EasterHolidays : IHolidays
    {
        public IEnumerable<Holiday> Get(int year)
        {
            var easterDate = new GaussAlgorithmComputus().GetDate(year);

            List<Holiday> days = new List<Holiday>();

            var easter = new FixedDateHoliday(HolidayCode.Easter, easterDate);

            //easter.AddDependency(easter);

            var pentcost = new DayOfWeekOffsetHoliday(System.DayOfWeek.Sunday, easter.Date, 7, HolidayCode.Pentecost);

            pentcost.AddDependency(
                new DayOfWeekOffsetHoliday(System.DayOfWeek.Saturday, pentcost.Date, -1, HolidayCode.PentecostEve));

            easter
                .AddDependency(new DayOfWeekOffsetHoliday(System.DayOfWeek.Thursday, easter.Date, -1, HolidayCode.MaundyThursday))
                .AddDependency(new DayOfWeekOffsetHoliday(System.DayOfWeek.Friday, easter.Date, -1, HolidayCode.GoodFriday))
                .AddDependency(new DayOfWeekOffsetHoliday(System.DayOfWeek.Saturday, easter.Date, -1, HolidayCode.HolySaturday))
                .AddDependency(new DayOfWeekOffsetHoliday(System.DayOfWeek.Monday, easter.Date, 1, HolidayCode.EasterMonday))
                .AddDependency(new DayOfWeekOffsetHoliday(System.DayOfWeek.Thursday, easter.Date, 6, HolidayCode.AscensionThursday))
                .AddDependency(pentcost);

            easter.GetDates2(days);

            return days;
        }
    }
}