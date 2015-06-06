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

    /// <summary>
    /// http://www.samlogic.com/swedish-net-classes/classes/samlogic-calendar-library/class-swedish-calendar.htm
    /// </summary>
    public abstract class Holiday : IHoliday
    {
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

        private static readonly IEqualityComparer<Holiday> CodeComparerInstance = new CodeEqualityComparer();

        public static IEqualityComparer<Holiday> CodeComparer
        {
            get
            {
                return CodeComparerInstance;
            }
        }

        protected bool Equals(Holiday other)
        {
            return Code == other.Code;
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

        private readonly IList<Holiday> _holidays = new List<Holiday>();

        public HolidayCode Code { get; protected set; }

        public DateTime Date { get; set; }

        public string LocalName { get; set; }

        public abstract short WorkReduction { get; protected set; }

        public abstract DateTime? Depricated { get; protected set; }

        public IEnumerable<Country> Countries
        {
            get
            {
                yield return Country.Sweden;
            }
        }

        public IEnumerable<Holiday> GetDates2(List<Holiday> holidays)
        {
            GetDates(holidays);

            holidays.Add(this);

            return holidays.OrderBy(holiday => holiday.Date);
        }

        public IEnumerable<Holiday> GetDates(List<Holiday> holidays)
        {
            //var x = _holidays.SelectMany(h => h.GetDates(holidays)).Union(_holidays).Union(new[] { this });

            //

            _holidays
            .ToList()
            .ForEach(h => GetValue(holidays, h));

            return holidays;
        }

        private static void GetValue(List<Holiday> holidays, Holiday h)
        {
            h.GetDates(holidays);
            holidays.Add(h);
        }

        public Holiday AddDependency(Holiday holiday)
        {
            if (!_holidays.Contains(holiday))
            {
                _holidays.Add(holiday);
            }

            return this;
        }
    }
}