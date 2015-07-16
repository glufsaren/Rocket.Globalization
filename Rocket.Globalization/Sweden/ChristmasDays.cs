using System;

using Rocket.Globalization.DateCalculations;

namespace Rocket.Globalization.Sweden
{
    public partial class Days
    {
        public Holiday ChristmasEve
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.ChristmasEve)
            {
                Name = "Julafton",
                IsSaturday = true,
                WorkTimeReduction = 8,
            };

                return new FixedDateHoliday(day, new DateTime(_year, 12, 24));
            }
        }

        public Holiday Christmas
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.Christmas)
            {
                Name = "Juldagen",
                IsSunday = true,
                WorkTimeReduction = 8,
            };

                return new FixedDateHoliday(day, new DateTime(_year, 12, 25));
            }
        }

        public Holiday BoxingDay
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.BoxingDay)
            {
                Name = "Annandag jul",
                IsSunday = true,
                WorkTimeReduction = 8,
            };

                return new FixedDateHoliday(day, new DateTime(_year, 12, 26));
            }
        }

        public Holiday NewYear
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.NewYear)
            {
                Name = "Nyårsafton",
                IsSaturday = true,
                WorkTimeReduction = 8,
            };

                return new FixedDateHoliday(day, new DateTime(_year, 12, 31));
            }
        }

        public Holiday ThirdDayOfChristmas
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.ThirdDayOfChristmas)
            {
                Name = "Tredjedag jul",
                IsSunday = true,
                WorkTimeReduction = 8,
                Deprecated = new DateTime(1572, 01, 01)
            };

                return new FixedDateHoliday(day, new DateTime(_year, 12, 27));
            }
        }

        public Holiday FourthDayOfChristmas
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.FourthDayOfChristmas)
            {
                Name = "Fjärdedag jul",
                IsSunday = true,
                WorkTimeReduction = 8,
                Deprecated = new DateTime(1572, 01, 01)
            };

                return new FixedDateHoliday(day, new DateTime(_year, 12, 28));
            }
        }
    }
}