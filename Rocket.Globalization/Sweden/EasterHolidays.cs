// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EasterHolidays.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the EasterHolidays type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Rocket.Globalization.Computus;

namespace Rocket.Globalization.Sweden
{
    // TODO: skicka year i ctor
    public class EasterHolidays : Holidays
    {
        protected override void AddHolidays(int year)
        {
            var easter = GetEaster(year);

            var pentecost = 7.Th().Sunday().After(easter).Is(Pentecost);

            1.Th().Monday().After(pentecost).Is(PentecostMonday)
                .Modify(holiday =>
                    {
                        holiday.WorkTimeReduction = year > 2004 ? 0 : 8;
                    });

            1.Th().Tuesday().After(pentecost).Is(PentecostTuesday);
            1.Th().Wednesday().After(pentecost).Is(PentecostWednesday);

            easter.AddDependency(pentecost);

            1.St().Saturday().Before(pentecost).Is(PentecostEve);

            1.St().Thursday().Before(easter).Is(MaundyThursday)
                .Modify(holiday =>
                        {
                            holiday.IsSunday = year <= 1771;
                            holiday.WorkTimeReduction = year > 1771 ? 0 : 8;
                        });


            1.St().Friday().Before(easter).Is(GoodFriday);
            1.St().Saturday().Before(easter).Is(HolySaturday);

            1.St().Monday().After(easter).Is(EasterMonday);
            1.St().Tuesday().After(easter).Is(EasterTuesday);
            1.St().Wednesday().After(easter).Is(EasterWednesday);

            6.Th().Thursday().After(easter).Is(AscensionThursday);

            var quinquagesima = 49.Days().Before(easter).IsX(Quinquagesima);

            _holidays.Add(Candlemass(year));

            var dayOfWeekIntervalHoliday = Candlemass2(year);

            if (quinquagesima.Date != dayOfWeekIntervalHoliday.Date)
            {
                _holidays.Add(dayOfWeekIntervalHoliday);
            }

            _holidays.AddRange(easter.AddDates());
        }

        private static FixedDateHoliday GetEaster(int year)
        {
            var easterDate =
                new GaussAlgorithmComputus().GetDate(year);

            return new FixedDateHoliday(Easter, easterDate);
        }
    }
}