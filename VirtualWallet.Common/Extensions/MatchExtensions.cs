using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VirtualWallet.Common.Extensions
{
    public static class MatchExtensions
    {
        public static string ValueOrDefault(this Match match, string defaultValue)
        {
            if (!match.Success)
            {
                return defaultValue;
            }

            return match.Value.OrDefault(defaultValue);
        }
        public static string ValueOrEmpty(this Match match) => ValueOrDefault(match, string.Empty);

        public static string GroupOrDefault(this Match match, string groupName, string defaultValue)
        {
            if (!match.Success)
            {
                return defaultValue;
            }

            return match.Groups[groupName]?.Value.OrDefault(defaultValue);
        }

        public static string GroupOrEmpty(this Match match, string groupName) => GroupOrDefault(match, groupName, string.Empty);

        public static IEnumerable<Match> ToEnumerable(this MatchCollection matchCollection)
        {
            foreach (Match match in matchCollection)
            {
                yield return match;
            }
        }
    }
}
