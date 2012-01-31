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
    /// Link:       http://www.dotnextra.com
    /// 
    /// The various OrderBy methods were built by Mark Gravell:
    /// http://stackoverflow.com/users/23354/marc-gravell
    /// </remarks>
    public static class IQueryableExtensions
    {
	    /// <summary>
        /// Sort an IQueryable, ascending by any property.
        /// </summary>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.ApplyOrder(propertyName, "OrderBy");
        }

        /// <summary>
        /// Sort an IQueryable, descending by any property.
        /// </summary>
        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.ApplyOrder(propertyName, "OrderByDescending");
        }

	    /// <summary>
	    /// Paginate a certain collection.
	    /// </summary>
        /// <param name="source">The IQueryable to paginate.</param>
	    /// <param name="pageNumber">The page number for the items to retrieve, starting at 1.</param>
	    /// <param name="pageSize">The max numbers of items that are displayed per page.</param>
	    /// <returns>The resulting value.</returns>
	    public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int pageNumber, int pageSize)
	    {
	        return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
	    }

        /// <summary>
        /// Continue sorting an IQueryable, ascending by any property.
        /// </summary>
        public static IQueryable<T> ThenBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.ApplyOrder(propertyName, "ThenBy");
        }

        /// <summary>
        /// Continue sorting an IQueryable, descending by any property.
        /// </summary>
        public static IQueryable<T> ThenByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.ApplyOrder(propertyName, "ThenByDescending");
        }

	    /// <summary>
	    /// Apply any given sorting on an IQueryable.
	    /// </summary>
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
