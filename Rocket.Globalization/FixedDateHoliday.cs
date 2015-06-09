// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FixedDateHoliday.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the FixedDateHoliday type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization
{
    public class FixedDateHoliday : Holiday
    {
        public FixedDateHoliday(Day day, DateTime date)
        {
            Day = day;
            Date = date;
        }

        public override short WorkReduction { get; protected set; }

        public override DateTime? Introduced { get; protected set; }

        public override DateTime? Depricated { get; protected set; }
    }
}