// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwedishHolidaysTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the SwedishHolidaysTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using Rocket.Globalization.Sweden;
using Rocket.Test;

using Should;

namespace Rocket.Globalization.Test.Unit
{
    [TestFixture]
    public class SwedishHolidaysTest
    {
        [TestFixture]
        public class When_getting_swedish_holidays : BaseUnitTest
        {
            private EasterHolidays _easterHolidays;
            private IEnumerable<Holiday> _holidays;
            private Holiday _maundyThursday;
            private Holiday _goodFriday;
            private Holiday _holySaturday;
            private Holiday _easter;
            private Holiday _easterMonday;
            private Holiday _ascensionThursday;
            private Holiday _pentecostEve;
            private Holiday _pentecost;

            protected override void Arrange()
            {
                _easterHolidays = new EasterHolidays();
            }

            protected override void Act()
            {
                _holidays = _easterHolidays.Get(2015);
            }

            protected override void Assemble()
            {
                _maundyThursday = GetHoliday(HolidayCode.MaundyThursday);
                _goodFriday = GetHoliday(HolidayCode.GoodFriday);
                _holySaturday = GetHoliday(HolidayCode.HolySaturday);
                _easter = GetHoliday(HolidayCode.Easter);
                _easterMonday = GetHoliday(HolidayCode.EasterMonday);
                _ascensionThursday = GetHoliday(HolidayCode.AscensionThursday);
                _pentecostEve = GetHoliday(HolidayCode.PentecostEve);
                _pentecost = GetHoliday(HolidayCode.Pentecost);
            }

            [Test]
            public void It_gets_maundry_thursday()
            {
                _maundyThursday.Date.ShouldEqual(new DateTime(2015, 04, 02));
            }

            [Test]
            public void It_gets_good_friday()
            {
                _goodFriday.Date.ShouldEqual(new DateTime(2015, 04, 03));
            }

            [Test]
            public void It_gets_holy_saturday()
            {
                _holySaturday.Date.ShouldEqual(new DateTime(2015, 04, 04));
            }

            [Test]
            public void It_gets_easter()
            {
                _easter.Date.ShouldEqual(new DateTime(2015, 04, 05));
            }

            [Test]
            public void It_gets_easter_monday()
            {
                _easterMonday.Date.ShouldEqual(new DateTime(2015, 04, 06));
            }

            [Test]
            public void It_gets_ascension_thursday()
            {
                _ascensionThursday.Date.ShouldEqual(new DateTime(2015, 05, 14));
            }

            [Test]
            public void It_gets_pentecost_eve()
            {
                _pentecostEve.Date.ShouldEqual(new DateTime(2015, 05, 23));
            }

            [Test]
            public void It_gets_pentecost()
            {
                _pentecost.Date.ShouldEqual(new DateTime(2015, 05, 24));
            }

            private Holiday GetHoliday(HolidayCode code)
            {
                return _holidays.Single(holiday => holiday.Day.Code == code);
            }
        }
    }
}