using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Common.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsBetween(this decimal number, decimal min, decimal max) => number >= min && number <= max; 
        public static string ToFixedString(this decimal number) => number.ToString("F2").Replace(",", ".");
    }
}
