// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FixedDateHoliday.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the FixedDateHoliday type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Rocket.Globalization.Sweden;

namespace Rocket.Globalization
{
    public class FixedDateHoliday : Holiday
    {
        public FixedDateHoliday(HolidayCode code, DateTime date)
        {
            Code = code;
            Date = date;
        }

        public override short WorkReduction { get; protected set; }

        public override DateTime? Depricated { get; protected set; }

        
    }
}