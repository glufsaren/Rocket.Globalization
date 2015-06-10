// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHolidayFactory.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the IHolidayFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Rocket.Globalization
{
    public interface IHolidayFactory
    {
        IHolidays Create(Country country);
    }
}