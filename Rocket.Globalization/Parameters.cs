// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parameters.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Parameters type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization
{
    internal class Parameters
    {
        public DayOfWeek DayOfWeek { get; set; }

        public int Number { get; set; }

        public Day Day { get; set; }

        public DateTime Date { get; set; }

        public Holiday Parent { get; set; }

        public int Days { get; set; }
    }
}