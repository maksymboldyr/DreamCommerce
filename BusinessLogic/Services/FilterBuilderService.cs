using System;
using System.Collections.Generic;
using System.Linq;
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

                Expression comparisonExpression;
                switch (matchMode)
                {
                    case "startsWith":
                        comparisonExpression = Expression.Call(property, typeof(string).GetMethod("StartsWith", new[] { typeof(string) }), Expression.Constant(value));
                        break;
                    case "contains":
                        comparisonExpression = Expression.Call(property, typeof(string).GetMethod("Contains", new[] { typeof(string) }), Expression.Constant(value));
                        break;
                    case "notContains":
                        comparisonExpression = Expression.Not(Expression.Call(property, typeof(string).GetMethod("Contains", new[] { typeof(string) }), Expression.Constant(value)));
                        break;
                    case "endsWith":
                        comparisonExpression = Expression.Call(property, typeof(string).GetMethod("EndsWith", new[] { typeof(string) }), Expression.Constant(value));
                        break;
                    case "equals":
                        comparisonExpression = Expression.Equal(property, Expression.Constant(value));
                        break;
                    case "notEquals":
                        comparisonExpression = Expression.NotEqual(property, Expression.Constant(value));
                        break;
                    case "in":
                        comparisonExpression = InExpression(property, value);
                        break;
                    case "notIn":
                        comparisonExpression = NotInExpression(property, value);                        
                        break;
                    default:
                        throw new ArgumentException($"Invalid match mode: {matchMode}");
                }

                filterExpression = Expression.AndAlso(filterExpression, comparisonExpression);
            }

            var lambdaExpression = Expression.Lambda<Func<T, bool>>(filterExpression, parameter);

            return lambdaExpression;
        }

        private Expression InExpression(Expression property, string value)
        {
            var comparisonExpression = InComparsion(property, value);

            return Expression.AndAlso(ExcludeEmpty(property), comparisonExpression);
        }

        private Expression NotInExpression(Expression property, string value)
        {
            var comparisonExpression = Expression.Not(InComparsion(property, value));

            return comparisonExpression;
        }

        private Expression InComparsion(Expression property, string value)
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

        private Expression ExcludeEmpty(Expression property)
        {
            return Expression.NotEqual(Expression.Call(typeof(Enumerable), "Any", new[] { typeof(string) }, property), Expression.Constant(false));
        }
    }
}
