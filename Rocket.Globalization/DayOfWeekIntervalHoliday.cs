// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DayOfWeekIntervalHoliday.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the DayOfWeekIntervalHoliday type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization
{
    public class DayOfWeekIntervalHoliday : Holiday
    {
        public DayOfWeek DayOfWeek { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public override short WorkReduction { get; protected set; }

        public override DateTime? Introduced { get; protected set; }

        public override DateTime? Depricated { get; protected set; }
    }
}