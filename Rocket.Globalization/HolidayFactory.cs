// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HolidayFactory.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the HolidayFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Rocket.Globalization.Sweden;

namespace Rocket.Globalization
{
    public class HolidayFactory : IHolidayFactory
    {
        public Holidays Create(Country country)
        {
            switch (country)
            {
                case Country.Sweden:
                    return new SwedishHolidays();

                default:
                    throw new ArgumentOutOfRangeException(nameof(country));
            }
        }
    }
}