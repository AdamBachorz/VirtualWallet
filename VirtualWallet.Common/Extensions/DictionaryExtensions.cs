using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualWallet.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static V GetValueIfExists<K, V>(this IDictionary<K, V> dictionary, K key, V defaultValue)
        {
            try
            {
                return dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}