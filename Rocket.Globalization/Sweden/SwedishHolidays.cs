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

using Rocket.Globalization.Computus;

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
    */
    // http://www.kevinlaughery.com/east4099.html
    // http://www.csgnetwork.com/eastercalc.html
    // http://en.wikipedia.org/wiki/Gregorian_calendar

    // TODO: Byt namn!
    // TODO: LAZY!!!
    public class SwedishHolidays : IHolidays
    {
        private readonly IDictionary<DateTime, Day> holidays = new Dictionary<DateTime, Day>();

        private readonly int year;

        public SwedishHolidays(int year)
        {
            this.year = year;

            //AddNewYearsDay();
        }

        private void AddNewYearsDay()
        {
            var newYearsDay = new Day(new DateTime(year, 01, 01))
                                  {
                                      IsHoliday = true,
                                      Code = HolidayCode.NewYear,
                                      Name = "Nyårsdagen",
                                      WorkTimeReduction = 8
                                  };

            holidays.Add(newYearsDay.Date, newYearsDay);
        }
        
        // EJ RÖD
        // Trettondagsafton
        public DateTime TwelfthNight
        {
            get
            {
                return new DateTime(year, 01, 05);
            }
        }

        // Trettondedag jul
        public DateTime Epiphany
        {
            get
            {
                return new DateTime(year, 01, 06);
            }
        }

        // EJ RÖD
        // -4
        // Skärtorsdagen
        public DateTime MaundyThursday
        {
            get
            {
                var date = Easter;

                //while (date.DayOfWeek != DayOfWeek.Thursday)
                //{
                //    date = date.AddDays(-1);
                //}

                return date;
            }
        }

        // Långfredagen
        public DateTime GoodFriday
        {
            get
            {
                var date = Easter;

                //while (date.DayOfWeek != DayOfWeek.Friday)
                //{
                //    date = date.AddDays(-1);
                //}

                return date;
            }
        }

        // EJ RÖD!!!
        // Påskafton
        public DateTime HolySaturday
        {
            get
            {
                var date = Easter;

                //while (date.DayOfWeek != DayOfWeek.Saturday)
                //{
                //    date = date.AddDays(-1);
                //}

                return date;
            }
        }

        // Annandag påsk
        public DateTime EasterMonday
        {
            get
            {
                return Easter.AddDays(1);
            }
        }

        //  Spy Wednesday, Maundy Thursday, Good Friday, Holy Saturday, Easter

        public DateTime Easter
        {
            get
            {
                Computus.Computus gaussAlgorithm = new GaussAlgorithmComputus();

                return gaussAlgorithm.GetDate(year);
            }
        }

        // EJ RÖD!!!
        // -4
        // Valborgsmässoafton
        public DateTime WalpurgisNight
        {
            get
            {
                return new DateTime(year, 04, 30);
            }
        }

        // Första maj
        public DateTime WorkersDay
        {
            get
            {
                return new DateTime(year, 05, 01);
            }
        }

        public IEnumerable<Holiday> Get(int year)
        {
            yield break;
        }
    }
}
