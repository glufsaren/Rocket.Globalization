// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DayOfWeekOffsetHoliday.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the DayOfWeekOffsetHoliday type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Rocket.Globalization.Sweden;

namespace Rocket.Globalization
{
    public class DayOfWeekOffsetHoliday : Holiday
    {
        public DayOfWeekOffsetHoliday(System.DayOfWeek dayOfWeek, DateTime dateTime, int number, HolidayCode code)
        {
            Code = code;
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

        public Direction Direction { get; set; }

        public System.DayOfWeek DayOfWeek { get; set; }

        public DateTime DateTime { get; set; }

        public int Number { get; set; }

        public override short WorkReduction { get; protected set; }

        public override DateTime? Depricated { get; protected set; }
    }

    public enum Direction
    {
        Back = -1,

        Forward = 1
    }

    public static class Ext
    {
        public static DayOfWeek ToDayOfWeek(this System.DayOfWeek dayOfWeek)
        {
            return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayOfWeek.ToString());
        }
    }
}