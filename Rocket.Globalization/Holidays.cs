// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Holidays.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Holidays type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Rocket.Globalization
{
    public abstract class Holidays
    {
        private readonly ConcurrentDictionary<int, List<Holiday>> _years =
            new ConcurrentDictionary<int, List<Holiday>>();

        protected readonly List<Holiday> _holidays = new List<Holiday>();

        public IEnumerable<Holiday> Get(int year)
        {
            //List<Holiday> holidays;

            //if (!_years.TryGetValue(year, out holidays))
            //{
                AddHolidays(year);

                //_years.TryAdd(year, _holidays.Where(holiday => holiday.IsActive).OrderBy(holiday => holiday.Date).ToList());
            //}

            //return holidays;

            return _holidays.Where(holiday => holiday.IsActive).OrderBy(holiday => holiday.Date);
        }

        protected abstract void AddHolidays(int year);
    }
}