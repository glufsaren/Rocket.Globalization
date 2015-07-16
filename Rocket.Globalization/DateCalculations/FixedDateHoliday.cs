// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FixedDateHoliday.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the FixedDateHoliday type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization.DateCalculations
{
    public class FixedDateHoliday : Holiday
    {
        public FixedDateHoliday(HolidayMetadata metadata, DateTime date)
            : base(metadata)
        {
            Date = date;
        }
    }
}