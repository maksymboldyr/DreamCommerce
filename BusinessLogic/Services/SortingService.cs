using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogic.Services;

/// <summary>
/// Service to build sorting expressions based on string sort field and sort order parameters.
/// </summary>
/// <typeparam name="T"></typeparam>
public class SortingService<T>
{
    /// <summary>
    /// Get a sorting expression based on the sort field and sort order.
    /// </summary>
    /// <param name="sortField"></param>
    /// <param name="sortOrder"></param>
    /// <returns></returns>
    public Func<IQueryable<T>, IOrderedQueryable<T>> GetSortExpression(string sortField, string sortOrder)
    {
        // Normalize sort order
        if (sortOrder == "1" || sortOrder == "undefined")
        {
            sortOrder = "asc";
        }

        if (sortOrder == "-1")
        {
            sortOrder = "desc";
        }

        var param = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(param, sortField);

        // Handle sorting by list
        if (typeof(IEnumerable<IComparable>).IsAssignableFrom(property.Type))
        {
            // Sorting lists lexicographically
            var keySelector = Expression.Lambda<Func<T, IEnumerable<IComparable>>>(property, param);

            return sortOrder.ToLower() switch
            {
                "asc" => query => query.OrderBy(item => keySelector.Compile()(item), new ListComparer<IComparable>()),
                "desc" => query => query.OrderByDescending(item => keySelector.Compile()(item), new ListComparer<IComparable>()),
                _ => query => query.OrderBy(item => keySelector.Compile()(item), new ListComparer<IComparable>()),
            };
        }

        // Handle sorting for other types (strings, numbers, etc.)
        var keySelectorForOthers = Expression.Lambda<Func<T, object>>(
            Expression.Convert(property, typeof(object)), param);

        return sortOrder.ToLower() switch
        {
            "asc" => query => query.OrderBy(keySelectorForOthers),
            "desc" => query => query.OrderByDescending(keySelectorForOthers),
            _ => query => query.OrderBy(keySelectorForOthers), // Default to ascending
        };
    }
}

/// <summary>
/// Custom comparer for lists to compare lexicographically.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ListComparer<T> : IComparer<IEnumerable<T>> where T : IComparable
{
    public int Compare(IEnumerable<T> x, IEnumerable<T> y)
    {
        if (x == null || y == null)
            return x == null ? (y == null ? 0 : -1) : 1;

        using var enumX = x.GetEnumerator();
        using var enumY = y.GetEnumerator();

        while (enumX.MoveNext() && enumY.MoveNext())
        {
            int result = enumX.Current.CompareTo(enumY.Current);
            if (result != 0)
                return result;
        }

        // If all elements are equal, the shorter list comes first
        return x.Count().CompareTo(y.Count());
    }
}
