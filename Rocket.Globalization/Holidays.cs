// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Holidays.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Holidays type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Rocket.Globalization
{
    public abstract class Holidays
    {
        private readonly List<Holiday> _holidays = new List<Holiday>();

        protected List<Holiday> Holidays1
        {
            get
            {
                return _holidays;
            }
        }

        public IEnumerable<Holiday> Get(int year)
        {
            AddHolidays(year);

            return Holidays1
                .Where(holiday => holiday.IsActive)
                .OrderBy(holiday => holiday.Date);
        }

        protected abstract void AddHolidays(int year);
    }
}