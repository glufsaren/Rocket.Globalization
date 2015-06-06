// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HolidayFactory.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the HolidayFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization
{
    public class HolidayFactory : IHolidayFactory
    {
        public IHolidayFactory Create(Country country)
        {
            switch (country)
            {
                case Country.Sweden:
                    return null;

                default:
                    throw new ArgumentOutOfRangeException("country");
            }
        }
    }
}