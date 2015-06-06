// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Day.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Day type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Rocket.Globalization.Sweden;

namespace Rocket.Globalization
{
    public class Day
    {
        public Day(DateTime date)
        {
            Date = date;
        }

        public DayOfWeek Weekday
        {
            get
            {
                return Date.DayOfWeek.ToDayOfWeek();
            }
        }

        public DateTime Date { get; private set; }

        public int WorkTimeReduction { get; set; }

        public HolidayCode Code { get; set; }

        public string Name { get; set; }

        public bool IsHoliday { get; set; }
    }
}