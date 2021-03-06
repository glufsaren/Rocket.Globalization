﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DayOfWeekIntervalHoliday.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the DayOfWeekIntervalHoliday type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization.DateCalculations
{
    public class DayOfWeekIntervalHoliday : Holiday
    {
        public DayOfWeekIntervalHoliday(DateTime start, DateTime end, DayOfWeek dayOfWeek, HolidayMetadata metadata)
            : base(metadata)
        {
            for (var date = start.Date; date.Date <= end.Date; date = date.AddDays(1))
            {
                if (date.DayOfWeek != dayOfWeek)
                {
                    continue;
                }

                Date = date;
                break;
            }
        }
    }
}