// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwedishHolidays.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the SwedishHolidays type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Rocket.Globalization.Sweden
{
    public class SwedishHolidays : Holidays
    {
        // TODO: Static  ConcurrentDictionary?
        ////public IEnumerable<Holiday> Get(int year)
        ////{
        ////    ////return LazyInitializer.EnsureInitialized(
        ////    ////    ref holidays, () => AddHolidays(year));
        ////    return AddHolidays(year);
        ////}

        protected override void AddHolidays(int year)
        {
            var days = new Days(year);

            var swedishHolidays = new List<Holiday>
                               {
                                   days.NewYearsDay,
                                   days.TwelfthNight,
                                   days.Epiphany,
                                   days.WalpurgisNight,
                                   days.WorkersDay,
                                   days.NationalDay,
                                   days.FeastOfTheAnnunciation,
                                   days.EriksDay,
                                   days.MidsummerEve,
                                   days.Midsummer,
                                   days.Halloween,
                                   days.AllSaintsDay,
                                   days.AllSaintsDay2,
                                   days.ChristmasEve,
                                   days.Christmas,
                                   days.BoxingDay,
                                   days.NewYear,
                                   days.ThirdDayOfChristmas,
                                   days.FourthDayOfChristmas
                               };

            swedishHolidays.AddRange(
                new EasterHolidays().Get(year));

            _holidays.AddRange(swedishHolidays);
        }

       
    }
}
