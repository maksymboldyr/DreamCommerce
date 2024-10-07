using System.Linq.Expressions;

namespace BusinessLogic.Services
{
    public class FilterBuilderService
    {
        public Expression<Func<T, bool>> BuildFilter<T>(string filter)
        {
            var filterConditions = filter.Split("and", StringSplitOptions.RemoveEmptyEntries);

            var parameter = Expression.Parameter(typeof(T), "entity");

            Expression filterExpression = Expression.Constant(true);

            foreach (var condition in filterConditions)
            {
                var parts = condition.Trim().Split(' ');

                var propertyName = parts[0];
                var matchMode = parts[1];

                var property = Expression.Property(parameter, propertyName);

                var value = parts.Length > 2 ? string.Join(" ", parts.Skip(2)) : string.Empty;
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
                filterExpression = Expression.AndAlso(filterExpression, comparisonExpression);
            }

            var lambdaExpression = Expression.Lambda<Func<T, bool>>(filterExpression, parameter);

            return lambdaExpression;
        }

        private BinaryExpression InExpression(Expression property, string value)
        {
            var comparisonExpression = InComparsion(property, value);

            return Expression.AndAlso(ExcludeEmpty(property), comparisonExpression);
        }

        private UnaryExpression NotInExpression(Expression property, string value)
        {
            var comparisonExpression = Expression.Not(InComparsion(property, value));

            return comparisonExpression;
        }

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

        private static BinaryExpression ExcludeEmpty(Expression property)
        {
            return Expression.NotEqual(Expression.Call(typeof(Enumerable), "Any", [typeof(string)], property), Expression.Constant(false));
        }
    }
}
