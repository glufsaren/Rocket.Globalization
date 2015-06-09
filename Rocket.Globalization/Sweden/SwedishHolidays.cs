// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwedishHolidays.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the SwedishHolidays type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Rocket.Globalization.Sweden
{
    /* 
     * Första maj blev allmän helgdag i Sverige 1939, som den första icke-kristna helgen. 
     * Svenska flaggans dag och Sveriges nationaldag den 6 juni blev allmän helgdag 2005. 
     * Samma år förlorade annandag pingst sin tidigare helgdagsstatus och blev vanlig arbetsdag. 
     * 
     * Se även Helgafton och Annandag.
     * 
     * Gå igenom Tidigare allmänna helgdagar i Sverige
     * 
     * http://sv.wikipedia.org/wiki/Helgdagar_i_Sverige
     * http://www.kevinlaughery.com/east4099.html
     * http://www.csgnetwork.com/eastercalc.html
     * http://en.wikipedia.org/wiki/Gregorian_calendar
     * http://www.samlogic.com/swedish-net-classes/classes/samlogic-calendar-library/class-swedish-calendar.htm
    */
    public class SwedishHolidays : IHolidays
    {
        // TODO: Byt namn!
        // TODO: LAZY!!!
        private readonly IDictionary<DateTime, Day> _holidays = new Dictionary<DateTime, Day>();

        private readonly int _year;

        public SwedishHolidays(int year)
        {
            _year = year;
        }

        public IEnumerable<Holiday> Get(int year)
        {
            yield break;
        }
    }
}
