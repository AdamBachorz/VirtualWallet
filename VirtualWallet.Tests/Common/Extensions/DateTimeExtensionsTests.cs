using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Common.Extensions;

namespace VirtualWallet.Tests.Common.Extensions
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [TestCase(1, ExpectedResult = "Styczeń")]
        [TestCase(2, ExpectedResult = "Luty")]
        [TestCase(3, ExpectedResult = "Marzec")]
        [TestCase(4, ExpectedResult = "Kwiecień")]
        [TestCase(5, ExpectedResult = "Maj")]
        [TestCase(6, ExpectedResult = "Czerwiec")]
        [TestCase(7, ExpectedResult = "Lipiec")]
        [TestCase(8, ExpectedResult = "Sierpień")]
        [TestCase(9, ExpectedResult = "Wrzesień")]
        [TestCase(10, ExpectedResult = "Październik")]
        [TestCase(11, ExpectedResult = "Listopad")]
        [TestCase(12, ExpectedResult = "Grudzień")]
        public string ShouldGetMonthName(int month)
        {
            return new DateTime(2021, month, 1).GetMonthName();
        }
    }
}
