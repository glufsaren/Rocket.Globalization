// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHolidays.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the IHolidays type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Rocket.Globalization
{
    public interface IHolidays
    {
        IEnumerable<Holiday> Get(int year);
    }
}