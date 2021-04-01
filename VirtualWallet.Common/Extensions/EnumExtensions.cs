using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace VirtualWallet.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string Description(this Enum @enum)
        {
            var enumType = @enum
                .GetType()
                .GetField(@enum.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), true)
                .FirstOrDefault() as DescriptionAttribute;

            return enumType?.Description ?? string.Empty;
        }
    }
}
