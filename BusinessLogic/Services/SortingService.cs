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
