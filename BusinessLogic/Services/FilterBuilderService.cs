using System.Linq.Expressions;

namespace BusinessLogic.Services;

/// <summary>
/// Service to build filter expressions based on a filtering string without writing custom logic for each entity type.
/// </summary>
public class FilterBuilderService
{
    /// <summary>
    /// Build a filter expression based on a filtering string.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filter"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public Expression<Func<T, bool>> BuildFilter<T>(string filter)
    {
        // Split the filter string into conditions
        var filterConditions = filter.Split("and", StringSplitOptions.RemoveEmptyEntries);

        // Parameter for entity that is being filtered
        var parameter = Expression.Parameter(typeof(T), "entity");

        // Filter expression declaration
        Expression filterExpression = Expression.Constant(true);

        // Build the filter expression based on the conditions
        foreach (var condition in filterConditions)
        {
            // Split the condition into parts
            var parts = condition.Trim().Split(' ');

            var propertyName = parts[0];
            var matchMode = parts[1];

            // Get the property of the entity by which the comparison will be made
            var property = Expression.Property(parameter, propertyName);

            // Get the value to compare the property to
            var value = parts.Length > 2 ? string.Join(" ", parts.Skip(2)) : string.Empty;
            
            // Build the comparison expression based on the match mode
            Expression comparisonExpression = matchMode switch
            {
                "startsWith" => Expression.Call(property, typeof(string).GetMethod("StartsWith", [typeof(string)]), Expression.Constant(value)),
                "contains" => Expression.Call(property, typeof(string).GetMethod("Contains", [typeof(string)]), Expression.Constant(value)),
                "notContains" => Expression.Not(Expression.Call(property, typeof(string).GetMethod("Contains", [typeof(string)]), Expression.Constant(value))),
                "endsWith" => Expression.Call(property, typeof(string).GetMethod("EndsWith", [typeof(string)]), Expression.Constant(value)),
                "equals" => Expression.Equal(property, Expression.Constant(value)),
                "notEquals" => Expression.NotEqual(property, Expression.Constant(value)),
                "in" => InExpression(property, value),
                "notIn" => NotInExpression(property, value),
                _ => throw new ArgumentException($"Invalid match mode: {matchMode}"),
            };

            // Add built comparison expression to the filter expression
            filterExpression = Expression.AndAlso(filterExpression, comparisonExpression);
        }

        // Apply the filter expression to the entity
        var lambdaExpression = Expression.Lambda<Func<T, bool>>(filterExpression, parameter);

        return lambdaExpression;
    }

    /// <summary>
    /// Build an "in" comparison expression.
    /// </summary>
    /// <param name="property"></param>
    /// <param name="value"></param>
    /// <returns><seealso cref="BinaryExpression"/> to filter entities that have the property value in the given list of values</returns>
    private BinaryExpression InExpression(Expression property, string value)
    {
        var comparisonExpression = InComparsion(property, value);

        return Expression.AndAlso(ExcludeEmpty(property), comparisonExpression);
    }

    /// <summary>
    /// Build a "not in" comparison expression.
    /// </summary>
    /// <param name="property"></param>
    /// <param name="value"></param>
    /// <returns><seealso cref="UnaryExpression"/> to filter entities that have the property value not in the given list of values</returns>
    private UnaryExpression NotInExpression(Expression property, string value)
    {
        var comparisonExpression = Expression.Not(InComparsion(property, value));

        return comparisonExpression;
    }

    /// <summary>
    /// Build "in" comparsion logic to be used for "in" and "not in" expressions.
    /// </summary>
    /// <param name="property"></param>
    /// <param name="value"></param>
    /// <returns><seealso cref="MethodCallExpression"/> to filter entities that have the property value in the given list of values</returns>
    private MethodCallExpression InComparsion(Expression property, string value)
    {
        var values = value.Split(',').ToArray();
        var arrayConstant = Expression.Constant(values);
        var containsMethod = typeof(Enumerable).GetMethods()
            .First(m => m.Name == nameof(Enumerable.Contains) && m.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(string));
        var allMethod = typeof(Enumerable).GetMethods()
            .First(m => m.Name == nameof(Enumerable.All) && m.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(string));
        var xParameter = Expression.Parameter(typeof(string), "x");
        var lambda = Expression.Lambda(Expression.Call(containsMethod, property, xParameter), xParameter);
        return Expression.Call(allMethod, arrayConstant, lambda);
    }

    /// <summary>
    /// Build an expression to exclude empty values from the "in" comparison.
    /// </summary>
    /// <param name="property"></param>
    /// <returns><seealso cref="BinaryExpression"/> to filter entities that have the property value in the given list of values and the property value is not empty</returns>
    private static BinaryExpression ExcludeEmpty(Expression property)
    {
        return Expression.NotEqual(Expression.Call(typeof(Enumerable), "Any", [typeof(string)], property), Expression.Constant(false));
    }
}
