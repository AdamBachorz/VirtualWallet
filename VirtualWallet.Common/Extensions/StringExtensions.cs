using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace VirtualWallet.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string text) => !string.IsNullOrWhiteSpace(text);
        public static bool HasNotValue(this string text) => !HasValue(text);

        public static bool IsDigit(this string text) => Regex.IsMatch(text, @"^\d+$");
        public static bool IsNotDigit(this string text) => !IsDigit(text);

        public static bool IsIn(this string text, bool caseSensitive, params string[] strings)
            => strings?.Any(s => caseSensitive ? s.Equals(text) : s.Equals(text, StringComparison.OrdinalIgnoreCase)) == true;
        public static bool IsIn(this string text, params string[] strings) => IsIn(text, false, strings);

        public static bool ContainsPhrase(this string text, string phrase)
            => text?.IndexOf(phrase, StringComparison.OrdinalIgnoreCase) >= 0;
        public static bool ContainsAny(this string text, params string[] strings)
            => strings?.Any(s => text.ContainsPhrase(s)) == true;

        public static string ChangeDotToComma(this string text) => text.Replace('.', ',');
        public static string ChangeCommaToDot(this string text) => text.Replace(',', '.');

        public static XCData ToXCData(this string ob) => new XCData(ob);

        public static string OrDefault(this string text, string defaultValue) => text.HasValue() ? text : defaultValue;
        public static string OrEmpty(this string text) => text.OrDefault(string.Empty);
        
        public static string ToCamelCase(this string text) => char.ToLowerInvariant(text[0]) + text.Substring(1);

        public static string RemoveText(this string text, string value)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(text))
                result = text.Replace(value, "");

            return result;
        }
        public static string RemoveSingleSpaces(this string text) => RemoveText(text, " ");
        public static string RemoveMatchPattern(this string text, string pattern) => Regex.Replace(text, pattern, string.Empty);
        public static string RemoveAllSpaces(this string text) => RemoveMatchPattern(text, @"\s+");
    }
}