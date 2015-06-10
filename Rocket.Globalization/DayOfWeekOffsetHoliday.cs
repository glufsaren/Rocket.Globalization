// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DayOfWeekOffsetHoliday.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the DayOfWeekOffsetHoliday type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization
{
    public class DayOfWeekOffsetHoliday : Holiday
    {
        public DayOfWeekOffsetHoliday(DayOfWeek dayOfWeek, DateTime dateTime, int number, Day day)
        {
            Day = day;
            DayOfWeek = dayOfWeek;
            DateTime = dateTime;
            Number = number;

            var offset = dateTime.AddDays(number * 6);

            int delta;

            if (number < 0)
            {
                delta = dayOfWeek.ToDayOfWeek() - offset.DayOfWeek.ToDayOfWeek();
            }
            else
            {
                delta = dayOfWeek - offset.DayOfWeek;
            }

            if (delta == 0) delta = 7;

            DateTime monday = offset.AddDays(delta);

            Date = monday;
        }

        internal DayOfWeekOffsetHoliday(Parameters parameters)
            : this(parameters.DayOfWeek, parameters.Date, parameters.Number, parameters.Day)
        {
        }

        public DayOfWeek DayOfWeek { get; set; }

        public DateTime DateTime { get; set; }

        public int Number { get; set; }
    }

    internal static class Ext
    {
        public static DayOfWeekNegative ToDayOfWeek(this DayOfWeek dayOfWeek)
        {
            return (DayOfWeekNegative)Enum.Parse(typeof(DayOfWeekNegative), dayOfWeek.ToString());
        }
    }
}