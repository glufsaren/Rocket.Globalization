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

namespace Rocket.Globalization
{
    public abstract class Holiday : IHoliday
    {
        private readonly IList<Holiday> _holidays = new List<Holiday>();

        public Day Day { get; internal set; }

        public DateTime Date { get; set; }

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

            return dates
                .OrderBy(holiday => holiday.Date);
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

                return x.Day.Code == y.Day.Code;
            }

            public int GetHashCode(Holiday obj)
            {
                return (int)obj.Day.Code;
            }
        }

        private static readonly IEqualityComparer<Holiday> CodeComparerInstance = new CodeEqualityComparer();

        public static IEqualityComparer<Holiday> CodeComparer
        {
            get
            {
                return CodeComparerInstance;
            }
        }

        private bool Equals(Holiday other)
        {
            return Day.Code == other.Day.Code;
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
            return (int)Day.Code;
        }
    }
}