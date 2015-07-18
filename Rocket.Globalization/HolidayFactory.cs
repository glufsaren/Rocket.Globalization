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
    /// <summary>
    /// http://www.samlogic.com/swedish-net-classes/classes/samlogic-calendar-library/class-swedish-calendar.htm
    /// https://sv.wikipedia.org/wiki/Helgdagar_i_Sverige
    /// http://rodadagar.com/
    /// http://www.kalender.se/2012/November
    /// http://www.dinstartsida.se/almanacka.asp?datum=2003-10-01
    /// http://www.dinstartsida.se/almanacka.asp?datum=2015-02-01
    /// http://www.dinstartsida.se/almanacka.asp?datum=2008-02-01
    /// </summary>
    public class HolidayFactory : IHolidayFactory
    {
        public Holidays Create(Country country)
        {
            switch (country)
            {
                case Country.Sweden:
                    return new SwedishHolidays();

                default:
                    throw new ArgumentOutOfRangeException("country");
            }
        }
    }
}