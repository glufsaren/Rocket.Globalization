// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParametersExtensions.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the ParametersExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.Globalization
{
    internal static class ParametersExtensions
    {
        public static Parameters St(this int n)
        {
            return new Parameters
                       {
                           Number = n
                       };
        }

        public static Parameters Nd(this int n)
        {
            return new Parameters
                       {
                           Number = n
                       };
        }

        public static Parameters Rd(this int n)
        {
            return new Parameters
                       {
                           Number = n
                       };
        }

        public static Parameters Th(this int n)
        {
            return new Parameters
                       {
                           Number = n
                       };
        }

        public static Parameters Days(this int days)
        {
            return new Parameters
            {
                Days = days
            };
        }

        public static Parameters Monday(this Parameters param)
        {
            param.DayOfWeek = DayOfWeek.Monday;
            return param;
        }

        public static Parameters Tuesday(this Parameters param)
        {
            param.DayOfWeek = DayOfWeek.Tuesday;
            return param;
        }

        public static Parameters Wednesday(this Parameters param)
        {
            param.DayOfWeek = DayOfWeek.Wednesday;
            return param;
        }

        public static Parameters Thursday(this Parameters param)
        {
            param.DayOfWeek = DayOfWeek.Thursday;
            return param;
        }

        public static Parameters Friday(this Parameters param)
        {
            param.DayOfWeek = DayOfWeek.Friday;
            return param;
        }

        public static Parameters Saturday(this Parameters param)
        {
            param.DayOfWeek = DayOfWeek.Saturday;
            return param;
        }

        public static Parameters Sunday(this Parameters param)
        {
            param.DayOfWeek = DayOfWeek.Sunday;
            return param;
        }

        public static Parameters After(this Parameters param, Holiday holiday)
        {
            param.Number = param.Number;
            param.Date = holiday.Date;
            param.Parent = holiday;

            return param;
        }

        public static Parameters Before(this Parameters param, Holiday holiday)
        {
            param.Number = param.Number * -1;
            param.Days = param.Days * -1;
            param.Date = holiday.Date;
            param.Parent = holiday;

            return param;
        }

        public static DayOfWeekOffsetHoliday Is(this Parameters parameters, Day day)
        {
            parameters.Day = day;

            var holiday = new DayOfWeekOffsetHoliday(parameters);

            parameters.Parent.AddDependency(holiday);

            return holiday;
        }

        public static NumberOfDaysOffsetHoliday IsX(this Parameters parameters, Day day)
        {
            parameters.Day = day;

            var holiday = new NumberOfDaysOffsetHoliday(parameters.Date, parameters.Days, day);

            parameters.Parent.AddDependency(holiday);

            return holiday;
        }

        public static Holiday Modify(this Holiday holiday, Action<Holiday> func)
        {
            func(holiday);

            return holiday;
        }
    }
}