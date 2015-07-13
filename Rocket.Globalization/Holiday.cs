// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Holiday.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Holiday type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using Rocket.Globalization.Sweden;

namespace Rocket.Globalization
{
    public abstract class Holiday
    {
        private readonly Day _day;

        public Day Day
        {
            get
            {
                return _day;
            }
        }

        private static readonly IEqualityComparer<Holiday> CodeComparerInstance = new CodeEqualityComparer();

        private readonly IList<Holiday> _holidays = new List<Holiday>();

        protected Holiday(Day day)
        {
            _day = day;
            AddDayInformation();
        }

        public static IEqualityComparer<Holiday> CodeComparer
        {
            get
            {
                return CodeComparerInstance;
            }
        }

        public DateTime Date { get; set; }

        public int WorkTimeReduction { get; set; }

        public HolidayCode Code { get; set; }

        public string Name { get; set; }

        public bool IsSunday { get; set; }

        public bool IsSaturday { get; set; }

        public DateTime? Introduced { get; set; }

        public DateTime? Deprecated { get; set; }

        public bool IsActive
        {
            get
            {
                var depricated = Deprecated != null && Date >= Deprecated;
                var introduced = Introduced == null || Date >= Introduced;

                return !depricated && introduced;
            }
        }

        public Holiday AddDependency(Holiday holiday)
        {
            if (!_holidays.Contains(holiday))
            {
                _holidays.Add(holiday);
            }

            return this;
        }

        public IEnumerable<Holiday> AddDates()
        {
            var dates = new List<Holiday> { this };

            AddDates(dates);

            return dates;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Holiday)obj);
        }

        public override int GetHashCode()
        {
            return (int)Code;
        }

        private static void AddDates(List<Holiday> holidays, Holiday holiday)
        {
            holiday.AddDates(holidays);
            holidays.Add(holiday);
        }

        private void AddDates(List<Holiday> holidays)
        {
            _holidays
                .ToList()
                .ForEach(holiday => AddDates(holidays, holiday));
        }

        private bool Equals(Holiday other)
        {
            return Code == other.Code;
        }

        private sealed class CodeEqualityComparer : IEqualityComparer<Holiday>
        {
            public bool Equals(Holiday x, Holiday y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                return x.Code == y.Code;
            }

            public int GetHashCode(Holiday obj)
            {
                return (int)obj.Code;
            }
        }

        private void AddDayInformation()
        {
            WorkTimeReduction = _day.WorkTimeReduction;
            Code = _day.Code;
            Name = _day.Name;
            IsSunday = _day.IsSunday;
            IsSaturday = _day.IsSaturday;
            Introduced = _day.Introduced;
            Deprecated = _day.Deprecated;
        }
    }
}