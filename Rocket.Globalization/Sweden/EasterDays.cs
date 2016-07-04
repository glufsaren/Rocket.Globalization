// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EasterDays.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Days type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Rocket.Globalization.DateCalculations;

namespace Rocket.Globalization.Sweden
{
    public partial class Days
    {
        public static HolidayMetadata Pentecost => new HolidayMetadata(HolidayCode.Pentecost)
                                                {
                                                    Name = "Pingstdagen",
                                                    WorkTimeReduction = 8,
                                                    IsSunday = true
                                                };

        public HolidayMetadata PentecostEve
        {
            get
            {
                return new HolidayMetadata(HolidayCode.PentecostEve)
                {
                    Name = "Pingstafton",
                    IsSaturday = true
                };
            }
        }

        public HolidayMetadata PentecostMonday
        {
            get
            {
                return new HolidayMetadata(HolidayCode.PentecostMonday)
                {
                    Name = "Annandag pingst",
                    IsSunday = true,
                    Deprecated = new DateTime(2005, 01, 01)
                };
            }
        }

        public HolidayMetadata PentecostTuesday
        {
            get
            {
                return new HolidayMetadata(HolidayCode.PentecostTuesday)
                {
                    Name = "Tredjedag pingst",
                    IsSunday = true,
                    WorkTimeReduction = 8,
                    Deprecated = new DateTime(1772, 11, 04)
                };
            }
        }

        public HolidayMetadata PentecostWednesday
        {
            get
            {
                return new HolidayMetadata(HolidayCode.PentecostWednesday)
                {
                    Name = "Fjärdedag pingst",
                    IsSunday = true,
                    WorkTimeReduction = 8,
                    Deprecated = new DateTime(1772, 11, 04)
                };
            }
        }

        public HolidayMetadata MaundyThursday
        {
            get
            {
                return new HolidayMetadata(HolidayCode.MaundyThursday)
                {
                    Name = "Skärtorsdagen",
                    WorkTimeReduction = 4
                };
            }
        }

        public HolidayMetadata GoodFriday
        {
            get
            {
                return new HolidayMetadata(HolidayCode.GoodFriday)
                {
                    Name = "Långfredagen",
                    WorkTimeReduction = 8,
                    IsSunday = true
                };
            }
        }

        public HolidayMetadata HolySaturday
        {
            get
            {
                return new HolidayMetadata(HolidayCode.HolySaturday)
                {
                    Name = "Påskafton",
                    IsSaturday = true
                };
            }
        }

        public HolidayMetadata EasterMonday
        {
            get
            {
                return new HolidayMetadata(HolidayCode.EasterMonday)
                {
                    Name = "Annandag påsk",
                    IsSunday = true,
                    WorkTimeReduction = 8
                };
            }
        }

        public HolidayMetadata EasterTuesday
        {
            get
            {
                return new HolidayMetadata(HolidayCode.EasterTuesday)
                {
                    Name = "Tredjedag påsk",
                    IsSunday = true,
                    WorkTimeReduction = 8,
                    Deprecated = new DateTime(1772, 11, 04)
                };
            }
        }

        public HolidayMetadata EasterWednesday
        {
            get
            {
                return new HolidayMetadata(HolidayCode.EasterWednesday)
                {
                    Name = "Fjärdedag påsk",
                    IsSunday = true,
                    WorkTimeReduction = 8,
                    Deprecated = new DateTime(1772, 11, 04)
                };
            }
        }

        public HolidayMetadata AscensionThursday
        {
            get
            {
                return new HolidayMetadata(HolidayCode.AscensionThursday)
                {
                    Name = "Kristi himmelsfärdsdag",
                    IsSunday = true,
                    WorkTimeReduction = 8
                };
            }
        }

        public HolidayMetadata Easter
        {
            get
            {
                return new HolidayMetadata(HolidayCode.Easter)
                {
                    Name = "Påskdagen",
                    IsSunday = true
                };
            }
        }

        public FixedDateHoliday Candlemass
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.Candlemas)
                {
                    IsSunday = true,
                    Name = "Kyndelsmässodagen",
                    Introduced = new DateTime(600, 01, 01),
                    Deprecated = new DateTime(1771, 12, 31)
                };

                return new FixedDateHoliday(day, new DateTime(_year, 02, 02));
            }
        }

        // TODO: Fix!
        public DayOfWeekIntervalHoliday Candlemass2
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.Candlemas)
                {
                    Name = "Kyndelsmässodagen",
                    Introduced = new DateTime(1772, 01, 01)
                };

                return new DayOfWeekIntervalHoliday(
                                new DateTime(_year, 02, 02),
                                new DateTime(_year, 02, 08),
                                DayOfWeek.Sunday,
                                day);
            }
        }

        public HolidayMetadata Quinquagesima
        {
            get
            {
                return new HolidayMetadata(HolidayCode.Quinquagesima)
                {
                    Name = "Fastlagssöndagen"
                };
            }
        }
    }
}