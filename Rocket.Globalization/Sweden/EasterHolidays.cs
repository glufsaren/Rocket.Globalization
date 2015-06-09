// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EasterHolidays.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the EasterHolidays type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Rocket.Globalization.Computus;

namespace Rocket.Globalization.Sweden
{
    public class EasterHolidays : IHolidays
    {
        private static Day Pentecost
        {
            get
            {
                return new Day(HolidayCode.Pentecost)
                           {
                               Name = "Pingstdagen",
                               WorkTimeReduction = 8,
                               IsSunday = true
                           };
            }
        }

        private static Day PentecostEve
        {
            get
            {
                return new Day(HolidayCode.PentecostEve)
                           {
                               Name = "Pingstafton",
                               IsSaturday = true
                           };
            }
        }

        private static Day MaundyThursday
        {
            get
            {
                return new Day(HolidayCode.MaundyThursday)
                           {
                               Name = "Skärtorsdagen",
                               WorkTimeReduction = 4
                           };
            }
        }

        private static Day GoodFriday
        {
            get
            {
                return new Day(HolidayCode.GoodFriday)
                           {
                               Name = "Långfredagen",
                               WorkTimeReduction = 8,
                               IsSunday = true
                           };
            }
        }

        private static Day HolySaturday
        {
            get
            {
                return new Day(HolidayCode.HolySaturday)
                           {
                               Name = "Påskafton",
                               IsSaturday = true
                           };
            }
        }

        private static Day EasterMonday
        {
            get
            {
                return new Day(HolidayCode.EasterMonday)
                           {
                               Name = "Annandag påsk",
                               IsSunday = true,
                               WorkTimeReduction = 8
                           };
            }
        }

        private static Day AscensionThursday
        {
            get
            {
                return new Day(HolidayCode.AscensionThursday)
                           {
                               Name = "Kristi himmelsfärdsdag",
                               IsSunday = true,
                               WorkTimeReduction = 8
                           };
            }
        }

        private static Day Easter
        {
            get
            {
                return new Day(HolidayCode.Easter)
                           {
                               Name = "Påskdagen",
                               IsSunday = true
                           };
            }
        }

        public IEnumerable<Holiday> Get(int year)
        {
            var easter = GetEaster(year);

            var pentecost = 7.Th().Sunday().After(easter).Is(Pentecost);

            easter.AddDependency(pentecost);

            1.St().Saturday().Before(pentecost).Is(PentecostEve);
            1.St().Thursday().Before(easter).Is(MaundyThursday);
            1.St().Friday().Before(easter).Is(GoodFriday);
            1.St().Saturday().Before(easter).Is(HolySaturday);
            1.St().Monday().After(easter).Is(EasterMonday);
            6.Th().Thursday().After(easter).Is(AscensionThursday);

            return easter.AddDates();
        }

        private static FixedDateHoliday GetEaster(int year)
        {
            var easterDate =
                new GaussAlgorithmComputus().GetDate(year);

            return new FixedDateHoliday(Easter, easterDate);
        }
    }
}