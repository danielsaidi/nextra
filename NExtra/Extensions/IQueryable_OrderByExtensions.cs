using System;
using System.Linq;
using System.Linq.Expressions;

namespace NExtra.Extensions
{
	/// <summary>
	/// Extension methods for System.Linq.IQueryableExtensions.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// The various OrderBy methods were built by Mark Gravell:
    /// http://stackoverflow.com/users/23354/marc-gravell
    /// </remarks>
    public static class IQueryable_OrderByExtensions
    {
	    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.ApplyOrder(propertyName, "OrderBy");
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool descending)
        {
            return descending ? source.OrderBy(propertyName) : source.OrderByDescending(propertyName);
        }

        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.ApplyOrder(propertyName, "OrderByDescending");
        }

        public static IQueryable<T> ThenBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.ApplyOrder(propertyName, "ThenBy");
        }

        public static IQueryable<T> ThenBy<T>(this IQueryable<T> source, string propertyName, bool descending)
        {
            return descending ? source.ThenBy(propertyName) : source.ThenByDescending(propertyName);
        }

        public static IQueryable<T> ThenByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.ApplyOrder(propertyName, "ThenByDescending");
        }


	    private static IQueryable<T> ApplyOrder<T>(this IQueryable<T> source, string propertyName, string methodName)
	    {
	        var type = typeof(T);
	        var arg = Expression.Parameter(type, "x");
	        Expression expr = arg;

	        //Use reflection (not ComponentModel) to mirror LINQ
	        foreach (var pi in propertyName.Split('.').Select(typeof(T).GetProperty))
	        {
	            expr = Expression.Property(expr, pi);
	            type = pi.PropertyType;
	        }

	        var result = typeof(Queryable).GetMethods().Single(
	            method => method.Name == methodName
	                      && method.IsGenericMethodDefinition
	                      && method.GetGenericArguments().Length == 2
	                      && method.GetParameters().Length == 2)
	            .MakeGenericMethod(typeof(T), type)
	            .Invoke(null, new object[] { source, ApplyOrder_GetLambda<T>(type, arg, expr) });

	        return (IQueryable<T>)result;
	    }

	    private static Type ApplyOrder_GetDelegateType<T>(Type type)
	    {
	        return typeof(Func<,>).MakeGenericType(typeof(T), type);
	    }

	    private static LambdaExpression ApplyOrder_GetLambda<T>(Type type, ParameterExpression arg, Expression expr)
	    {
	        return Expression.Lambda(ApplyOrder_GetDelegateType<T>(type), expr, arg);
	    }
    }
}
