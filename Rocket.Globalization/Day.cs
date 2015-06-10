// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Day.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Day type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Rocket.Globalization.Sweden;

namespace Rocket.Globalization
{
    public class Day
    {
        public Day(HolidayCode code)
        {
            Code = code;
        }

        public int WorkTimeReduction { get; set; }

        public HolidayCode Code { get; set; }

        public string Name { get; set; }

        public bool IsSunday { get; set; }

        public bool IsSaturday { get; set; }
    }
}