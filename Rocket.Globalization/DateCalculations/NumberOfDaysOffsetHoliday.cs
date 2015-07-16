// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NumberOfDaysOffsetHoliday.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the NumberOfDaysOffsetHoliday type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization.DateCalculations
{
    public class NumberOfDaysOffsetHoliday : Holiday
    {
        public NumberOfDaysOffsetHoliday(DateTime dateTime, int days, HolidayMetadata metadata)
            : base(metadata)
        {
            Date = dateTime.AddDays(days);
        }
    }
}