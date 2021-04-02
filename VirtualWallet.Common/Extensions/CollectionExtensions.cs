using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualWallet.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddPredicatedOn<E>(this ICollection<E> collection, E element, Func<E, bool> predicate)
        {
            if (predicate(element))
            {
                collection.Add(element);
            }
        }

        public static void AddIfNotNull<E>(this ICollection<E> collection, E element) => AddPredicatedOn(collection, element, e => e != null);
        public static void AddIfNotExists<E>(this ICollection<E> collection, E element) => AddPredicatedOn(collection, element, e => !collection.Contains(e));

    }
}