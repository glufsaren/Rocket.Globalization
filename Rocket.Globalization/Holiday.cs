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
    public abstract class Holiday
    {
        private readonly HolidayMetadata _metadata;

        private readonly IList<Holiday> _holidays = new List<Holiday>();

        protected Holiday(HolidayMetadata metadata)
        {
            _metadata = metadata;
        }

        public HolidayMetadata Metadata
        {
            get
            {
                return _metadata;
            }
        }

        public DateTime Date { get; protected set; }

        public bool IsActive
        {
            get
            {
                var depricated = _metadata.Deprecated != null && Date >= _metadata.Deprecated;
                var introduced = _metadata.Introduced == null || Date >= _metadata.Introduced;

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
    }
}