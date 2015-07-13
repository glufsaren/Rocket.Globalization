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

        private static Day PentecostMonday
        {
            get
            {
                return new Day(HolidayCode.PentecostMonday)
                {
                    Name = "Annandag pingst",
                    IsSunday = true,
                    Deprecated = new DateTime(2005, 01, 01)
                };
            }
        }

        private static Day PentecostTuesday
        {
            get
            {
                return new Day(HolidayCode.PentecostTuesday)
                {
                    Name = "Tredjedag pingst",
                    IsSunday = true,
                    WorkTimeReduction = 8,
                    Deprecated = new DateTime(1772, 11, 04)
                };
            }
        }

        private static Day PentecostWednesday
        {
            get
            {
                return new Day(HolidayCode.PentecostWednesday)
                {
                    Name = "Fjärdedag pingst",
                    IsSunday = true,
                    WorkTimeReduction = 8,
                    Deprecated = new DateTime(1772, 11, 04)
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

        private static Day EasterTuesday
        {
            get
            {
                return new Day(HolidayCode.EasterTuesday)
                           {
                               Name = "Tredjedag påsk",
                               IsSunday = true,
                               WorkTimeReduction = 8,
                               Deprecated = new DateTime(1772, 11, 04)
                           };
            }
        }

        private static Day EasterWednesday
        {
            get
            {
                return new Day(HolidayCode.EasterWednesday)
                           {
                               Name = "Fjärdedag påsk",
                               IsSunday = true,
                               WorkTimeReduction = 8,
                               Deprecated = new DateTime(1772, 11, 04)
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

        private static FixedDateHoliday Candlemass(int year)
        {
            var day = new Day(HolidayCode.Candlemas)
            {
                IsSunday = true,
                Name = "Kyndelsmässodagen",
                Introduced = new DateTime(600, 01, 01),
                Deprecated = new DateTime(1771, 12, 31)
            };

            return new FixedDateHoliday(day, new DateTime(year, 02, 02));
        }

        private static DayOfWeekIntervalHoliday Candlemass2(int year)
        {
            var day = new Day(HolidayCode.Candlemas)
            {
                Name = "Kyndelsmässodagen",
                Introduced = new DateTime(1772, 01, 01)
            };

            return new DayOfWeekIntervalHoliday(
                            new DateTime(year, 02, 02),
                            new DateTime(year, 02, 08),
                            DayOfWeek.Sunday,
                            day);
        }

        private static Day Quinquagesima
        {
            get
            {
                return new Day(HolidayCode.Quinquagesima)
                           {
                               Name = "Fastlagssöndagen"
                           };
            }
        }

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

            Holidays1.Add(Candlemass(year));

            var dayOfWeekIntervalHoliday = Candlemass2(year);

            if (quinquagesima.Date != dayOfWeekIntervalHoliday.Date)
            {
                Holidays1.Add(dayOfWeekIntervalHoliday);
            }

            Holidays1.AddRange(easter.AddDates());
        }

        private static FixedDateHoliday GetEaster(int year)
        {
            var easterDate =
                new GaussAlgorithmComputus().GetDate(year);

            return new FixedDateHoliday(Easter, easterDate);
        }
    }
}