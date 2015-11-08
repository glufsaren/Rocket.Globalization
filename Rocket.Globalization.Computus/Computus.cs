// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Computus.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Computus type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization.Computus
{
    /// <summary>
    /// <see cref="Computus"/> (Latin for "computation") is the calculation of the date of Easter in terms of, first, the Julian and, later, the Gregorian calendar.
    /// <see href="http://en.wikipedia.org/wiki/Computus"/>
    /// </summary>
    public abstract class Computus
    {
        /// <summary>
        /// Gets the date of easter.
        /// </summary>
        /// <param name="year">The year to calculate the date of easter.</param>
        /// <returns>The date for easter for the specified <see cref="year"/>.</returns>
        public abstract DateTime GetDate(int year);
    }
}