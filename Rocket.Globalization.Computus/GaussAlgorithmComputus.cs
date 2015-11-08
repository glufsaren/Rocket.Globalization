// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GaussAlgorithmComputus.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the GaussAlgorithmComputus type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization.Computus
{
    /// <summary>
    /// Uses Carl Friedrich Gauss algorithm for calculating the date of the Julian or Gregorian Easter.
    /// </summary>
    /// <remarks>
    /// The Gregorian calendar was introduced in october 1582, 
    /// up until 1582 the calculation for Julian Easter will be used.
    /// The algorithm is explained here <see href="http://www.maa.org/publications/periodicals/convergence/servois-1813-perpetual-calendar-with-an-english-translation-gauss-calculation-for-the-date-of-easter"/>
    /// </remarks>
    public class GaussAlgorithmComputus : Computus
    {
        /// <summary>
        /// Gauss algorithm <see cref="Computus"/> implementation.
        /// </summary>
        /// <param name="year">The year to calculate the date of easter.</param>
        /// <returns>The date for easter for the specified <see cref="year"/>.</returns>
        public override DateTime GetDate(int year)
        {
            // Identifies the location of the year within the Metonic cycle, the 19-year cycle of the phases of the moon.
            var a = year % 19;

            // The 4-year cycle of the leap years in the Julian calendar.
            var b = year % 4;

            // Takes into account that a non-leap year is one day longer than 52 weeks.
            var c = year % 7;

            // The value of m is dependent on the century in question.
            // This value is calculated from the cycle of the dates on which the Paschal Full Moon occurred in that century.
            decimal m;

            // The value of n is based on the cycle of the days of the week on which the Paschal moon occurs in that century. 
            // In other words, n works according to a mod 7 system, with 0 representing Sunday, 1 representing Monday, etc.
            decimal n;

            // Gregorian calendar was introduced in october 1582
            if (year <= 1582)
            {
                m = 15;
                n = 6;
            }
            else
            {
                var k = Math.Floor(year / 100m);
                var p = Math.Floor((13 + (8 * k)) / 25);
                var q = Math.Floor(k / 4);

                m = (15 - p + k - q) % 30;
                n = (4 + k - q) % 7;
            }

            // This gives the number of days that need to be added to March 21 in order to find out the date of the Paschal Full Moon.
            var d = ((19 * a) + m) % 30;

            // This is the number of days from the Paschal Full Moon to the next Sunday.
            var e = ((2 * b) + (4 * c) + (6 * d) + n) % 7;

            // The Paschal Full Moon will occur d days after March 21 and Easter Sunday will be March (22+d+e).
            // If (22+d+e) is greater than 31, then you roll over into the month of April.
            var easter = new DateTime(year, 3, 22).AddDays((int)(d + e));

            // Now, the length of a lunar month is not 30 days, but rather 29.53 days.
            // Therefore, when the value of d is large this causes the Paschal Full Moon to be one day late. 
            // Additionally, if it happens on a Sunday, then we calculate a date of Easter which will be one week overdue. 
            // To compensate for this possibility, you must watch for this condition:
            if (d == 29 && e == 6)
            {
                return new DateTime(year, 4, 19);
            }

            if (d == 28 && e == 6 && ((11 * m) + 11) % 30 < 19)
            {
                return new DateTime(year, 4, 18);
            }

            return easter;
        }
    }
}