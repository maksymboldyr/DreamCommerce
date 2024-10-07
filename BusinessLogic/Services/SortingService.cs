using System;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogic.Services;

public class SortingService<T>
{
    public Func<IQueryable<T>, IOrderedQueryable<T>> GetSortExpression(string sortField, string sortOrder)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(param, sortField);
        var keySelector = Expression.Lambda<Func<T, object>>(
            Expression.Convert(property, typeof(object)), param);

        return sortOrder.ToLower() switch
        {
            "asc" => query => query.OrderBy(keySelector),
            "desc" => query => query.OrderByDescending(keySelector),
            _ => query => query.OrderBy(keySelector), // Default to ascending
        };
    }
}
