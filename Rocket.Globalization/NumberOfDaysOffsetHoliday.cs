// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NumberOfDaysOffsetHoliday.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the NumberOfDaysOffsetHoliday type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization
{
    public class NumberOfDaysOffsetHoliday : Holiday
    {
        public NumberOfDaysOffsetHoliday(DateTime dateTime, int days, Day day)
            : base(day)
        {
            Date = dateTime.AddDays(days);
        }
    }
}