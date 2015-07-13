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
            : base(day)
        {
            Date = date;
        }
    }
}