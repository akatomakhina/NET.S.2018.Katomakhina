using IPredicateLogic;
using System;
using System.Collections.Generic;

namespace FilterRealization
{
    public static class Filter
    {
        public static T[] FilterDigit<T>(T[] values, IPredicate<T> predicate)
        {
            List<T> result = new List<T>();

            foreach (var element in values)
            {
                if (predicate.Predicate(element))
                {
                    result.Add(element);
                }                
            }

            return result.ToArray();
        }

        static void Validation<T>(T[] values, IPredicate<T> filter)
        {
            if (values == null || values.Length == 0)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            if (values.Length <= 0)
            {
                throw new ArgumentOutOfRangeException($"{values} must be >= 0");
            }
        }
    }
}
