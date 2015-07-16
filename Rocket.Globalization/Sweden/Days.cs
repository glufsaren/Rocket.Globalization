using System;

using Rocket.Globalization.DateCalculations;

namespace Rocket.Globalization.Sweden
{
    public partial class Days
    {
        private readonly int _year;

        public Days(int year)
        {
            _year = year;
        }

        public FixedDateHoliday NewYearsDay
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.NewYearsDay)
                              {
                                  IsSunday = true,
                                  Name = "Nyårsdagen"
                              };

                return new FixedDateHoliday(day, new DateTime(_year, 01, 01));
            }
        }

        public FixedDateHoliday TwelfthNight
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.TwelfthNight)
                {
                    Name = "Trettondagsafton"
                };

                return new FixedDateHoliday(day, new DateTime(_year, 01, 05));
            }
        }

        public FixedDateHoliday Epiphany
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.Epiphany)
                {
                    IsSunday = true,
                    Name = "Trettondedag jul"
                };

                return new FixedDateHoliday(day, new DateTime(_year, 01, 06));
            }
        }

        public FixedDateHoliday WalpurgisNight
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.WalpurgisNight)
                {
                    Name = "Valborgsmässoafton",
                    WorkTimeReduction = 4
                };

                return new FixedDateHoliday(day, new DateTime(_year, 04, 30));
            }
        }

        public Holiday WorkersDay
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.WorkersDay)
                {
                    Name = "Första maj",
                    IsSunday = true,
                    Introduced = new DateTime(1892, 01, 01)
                };

                return new FixedDateHoliday(day, new DateTime(_year, 05, 01));
            }
        }

        public Holiday NationalDay
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.NationalDay)
                {
                    Name = "Sveriges nationaldag",
                    IsSunday = true,
                    Introduced = new DateTime(2005, 01, 01)
                };

                return new FixedDateHoliday(day, new DateTime(_year, 06, 06));
            }
        }

        public Holiday FeastOfTheAnnunciation
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.FeastOfTheAnnunciation)
                {
                    Name = "Jungfru Marie bebådelsedag",
                    Deprecated = new DateTime(1954, 01, 01)
                };

                return new FixedDateHoliday(day, new DateTime(_year, 03, 25));
            }
        }

        public Holiday EriksDay
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.EriksDay)
                {
                    Name = "Eriksmässa",
                    Deprecated = new DateTime(1572, 01, 01),
                };

                return new FixedDateHoliday(day, new DateTime(_year, 05, 18));
            }
        }

        public Holiday MidsummerEve
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.MidsummerEve)
                {
                    Name = "Midsommarafton",
                    WorkTimeReduction = 8
                };

                return new DayOfWeekIntervalHoliday(
                                new DateTime(_year, 06, 19),
                                new DateTime(_year, 06, 25),
                                DayOfWeek.Friday,
                                day);
            }
        }

        public Holiday Midsummer
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.Midsummer)
                {
                    Name = "Midsommardagen",
                    WorkTimeReduction = 8
                };

                return new DayOfWeekIntervalHoliday(
                                new DateTime(_year, 06, 20),
                                new DateTime(_year, 06, 26),
                                DayOfWeek.Saturday,
                                day);
            }
        }

        public Holiday Halloween
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.Halloween)
                {
                    Name = "Allhelgonaafton",
                    WorkTimeReduction = 4
                };

                return new DayOfWeekIntervalHoliday(
                                new DateTime(_year, 10, 30),
                                new DateTime(_year, 11, 05),
                                DayOfWeek.Friday,
                                day);
            }
        }

        public Holiday AllSaintsDay
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.AllSaintsDay)
                {
                    Name = "Alla helgons dag",
                    IsSunday = true
                };

                return new DayOfWeekIntervalHoliday(
                                new DateTime(_year, 10, 31),
                                new DateTime(_year, 11, 06),
                                DayOfWeek.Saturday,
                                day);
            }
        }

        public Holiday AllSaintsDay2
        {
            get
            {
                var day = new HolidayMetadata(HolidayCode.AllSaintsDay2)
                {
                    Name = "Allhelgonadagen",
                    IsSunday = _year <= 1953,
                    WorkTimeReduction = _year > 1953 ? 8 : 0,
                };

                return new FixedDateHoliday(day, new DateTime(_year, 11, 01));
            }
        }
    }
}