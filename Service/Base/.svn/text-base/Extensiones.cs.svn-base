using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public static class IEnumerableExtensions
    {
        public static void Each<T>(
            this IEnumerable<T> source,
            Action<T> action) where T : class
        {
            foreach (T item in source)
            {
                action(item);
            }
        }

        public static T FindCriteria<T>(
            this IEnumerable<T> source,
            IEqualityComparer<T> criteria, T item) where T : class
        {
            return source.Where(s => criteria.Equals(item, s)).Single<T>();
        }
    }    
}
