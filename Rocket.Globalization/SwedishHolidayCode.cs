// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwedishHolidayCode.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the SwedishHolidayCode type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Rocket.Globalization
{
    /// <summary>
    /// List of all swedish holidays, current and defunct.
    /// </summary>
    public enum SwedishHolidayCode
    {
        /// <summary>
        /// Swedish holiday <code>Nyårsafton</code>.
        /// </summary>
        NewYearsDay,

        TwelfthNight,

        Epiphany,

        MaundyThursday,

        GoodFriday,

        HolySaturday,

        Easter,

        /// <summary>
        /// Annandag påsk Rörligt datum, dagen efter påskdagen.
        /// </summary>
        EasterMonday,

        WalpurgisNight,

        WorkersDay,

        AscensionThursday,

        NationalDay,

        /// <summary>
        /// Pingstafton.
        /// </summary>
        PentecostEve,

        /// <summary>
        /// Pingstdagen
        /// </summary>
        Pentecost,

        MidsummerEve,

        Midsummer,

        Halloween,

        AllSaintsDay,

        ChristmasEve,

        Christmas,

        BoxingDay,

        NewYear,

        // ------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Kyndelsmässodagen 2 februari (till och med 1771).
        /// Sedan 1772 firas kyndelsmässodagen i Sverige på söndagen som infaller 2-8 februari, såvida det inte är fastlagssöndagen då.
        /// </summary>
        Candlemas,

        /// <summary>
        /// Fastlagssöndagen, Sunday before Ash Wednesday
        /// </summary>
        Quinquagesima,

        /// <summary>
        /// Annandag pingst, till och med 2004.
        /// </summary>
        PentecostMonday,
    }
}