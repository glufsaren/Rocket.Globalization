// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DayOfWeekExtensions.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the DayOfWeekExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization.DateCalculations
{
    internal static class DayOfWeekExtensions
    {
        public static DayOfWeekNegative ToDayOfWeek(this DayOfWeek dayOfWeek)
        {
            return (DayOfWeekNegative)Enum.Parse(typeof(DayOfWeekNegative), dayOfWeek.ToString());
        }
    }
}