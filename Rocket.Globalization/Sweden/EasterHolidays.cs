// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EasterHolidays.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the EasterHolidays type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Rocket.Globalization.Computus;
using Rocket.Globalization.DateCalculations;

namespace Rocket.Globalization.Sweden
{
    // TODO: skicka year i ctor
    public class EasterHolidays : Holidays
    {
        protected override void AddHolidays(int year)
        {
            var days = new Days(year);

            var easter = GetEaster(year);

            var pentecost = 7.Th().Sunday().After(easter).Is(days.Pentecost);

            1.St().Monday().After(pentecost).Is(days.PentecostMonday)
                .Modify(holiday =>
                    {
                        holiday.Metadata.WorkTimeReduction = year > 2004 ? 0 : 8;
                    });

            1.St().Tuesday().After(pentecost).Is(days.PentecostTuesday);
            1.St().Wednesday().After(pentecost).Is(days.PentecostWednesday);

            easter.AddDependency(pentecost);

            1.St().Saturday().Before(pentecost).Is(days.PentecostEve);

            1.St().Thursday().Before(easter).Is(days.MaundyThursday)
                .Modify(holiday =>
                        {
                            holiday.Metadata.IsSunday = year <= 1771;
                            holiday.Metadata.WorkTimeReduction = year > 1771 ? 0 : 8;
                        });

            1.St().Friday().Before(easter).Is(days.GoodFriday);
            1.St().Saturday().Before(easter).Is(days.HolySaturday);

            1.St().Monday().After(easter).Is(days.EasterMonday);
            1.St().Tuesday().After(easter).Is(days.EasterTuesday);
            1.St().Wednesday().After(easter).Is(days.EasterWednesday);

            6.Th().Thursday().After(easter).Is(days.AscensionThursday);

            var quinquagesima = 49.Days().Before(easter).Is(days.Quinquagesima);

            _holidays.Add(days.Candlemass);

            var dayOfWeekIntervalHoliday = days.Candlemass2;

            if (quinquagesima.Date != dayOfWeekIntervalHoliday.Date)
            {
                _holidays.Add(dayOfWeekIntervalHoliday);
            }

            _holidays.AddRange(easter.AddDates());
        }

        private static FixedDateHoliday GetEaster(int year)
        {
            var days = new Days(year);

            var easterDate =
                new GaussAlgorithmComputus().GetDate(year);

            return new FixedDateHoliday(days.Easter, easterDate);
        }
    }
}