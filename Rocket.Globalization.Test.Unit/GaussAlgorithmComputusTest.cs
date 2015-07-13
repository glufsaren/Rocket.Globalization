// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GaussAlgorithmComputusTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the GaussAlgorithmComputusTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using NUnit.Framework;

using Rocket.Globalization.Computus;

namespace Rocket.Globalization.Test.Unit
{
    [TestFixture]
    public class GaussAlgorithmComputusTest
    {
        [TestCase(1981, 4, 19)]
        [TestCase(2076, 4, 19)]
        [TestCase(1954, 4, 18)]
        [TestCase(2049, 4, 18)]
        [TestCase(2001, 4, 15)]
        [TestCase(1948, 3, 28)]
        [TestCase(326, 4, 3)]
        [TestCase(327, 3, 26)]
        [TestCase(328, 4, 14)]
        [TestCase(1581, 3, 26)]
        [TestCase(1582, 4, 15)]
        [TestCase(1583, 4, 10)]
        public void When_getting_date_for_easter_expect_date_returned(int year, int expectedMonth, int expectedDay)
        {
            var easter = new GaussAlgorithmComputus().GetDate(year);

            Assert.AreEqual(new DateTime(year, expectedMonth, expectedDay), easter);
        }
    }
}
