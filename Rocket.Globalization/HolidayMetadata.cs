// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HolidayMetadata.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the HolidayMetadata type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Rocket.Globalization.Sweden;

namespace Rocket.Globalization
{
    public class HolidayMetadata
    {
        public HolidayMetadata(HolidayCode code)
        {
            Code = code;
        }

        public int WorkTimeReduction { get; set; }

        public HolidayCode Code { get; private set; }

        public string Name { get; set; }

        public bool IsSunday { get; set; }

        public bool IsSaturday { get; set; }

        public bool IsBankHoliday { get; set; }

        public DateTime? Introduced { get; set; }

        public DateTime? Deprecated { get; set; }
    }
}