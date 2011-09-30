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
    /// Link:       http://www.saidi.se/nextra
    /// 
    /// The various OrderBy methods were made by Mark Gravell:
    /// http://stackoverflow.com/users/23354/marc-gravell
    /// </remarks>
    public static class IQueryableExtensions
    {
	    /// <summary>
        /// Apply any given sorting on an IQueryable.
	    /// </summary>
        /// <typeparam name="T">The type that is handled by the IQueryable.</typeparam>
        /// <param name="source">The IQueryable to sort.</param>
	    /// <param name="propertyName">The name of the property to sort by.</param>
	    /// <param name="methodName">The name of the sort method to use.</param>
	    /// <returns>The sorted result.</returns>
	    private static IQueryable<T> ApplyOrder<T>(this IQueryable<T> source, string propertyName, string methodName)
	    {
	        var type = typeof(T);
	        var propertyNames = propertyName.Split('.');
	        var arg = Expression.Parameter(type, "x");
	        Expression expr = arg;

	        //Use reflection (not ComponentModel) to mirror LINQ
	        foreach (var prop in propertyNames)
	        {
	            var pi = type.GetProperty(prop);
	            expr = Expression.Property(expr, pi);
	            type = pi.PropertyType;
	        }

	        var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
	        var lambda = Expression.Lambda(delegateType, expr, arg);

	        var result = typeof(Queryable).GetMethods().Single(
	            method => method.Name == methodName
	                      && method.IsGenericMethodDefinition
	                      && method.GetGenericArguments().Length == 2
	                      && method.GetParameters().Length == 2)
	            .MakeGenericMethod(typeof(T), type)
	            .Invoke(null, new object[] { source, lambda });

	        return (IQueryable<T>)result;
	    }

	    /// <summary>
        /// Sort an IQueryable, ascending by any property.
        /// </summary>
        /// <typeparam name="T">The type that is handled by the IQueryable.</typeparam>
        /// <param name="source">The IQueryable to sort.</param>
        /// <param name="propertyName">The name of the property to sort by.</param>
        /// <returns>The Sorted result.</returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.ApplyOrder(propertyName, "OrderBy");
        }

        /// <summary>
        /// Sort an IQueryable, descending by any property.
        /// </summary>
        /// <typeparam name="T">The type that is handled by the IQueryable.</typeparam>
        /// <param name="source">The IQueryable to sort.</param>
        /// <param name="propertyName">The name of the property to sort by.</param>
        /// <returns>The Sorted result.</returns>
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
        /// <typeparam name="T">The type that is handled by the IQueryable.</typeparam>
        /// <param name="source">The IQueryable to sort.</param>
        /// <param name="propertyName">The name of the property to sort by.</param>
        /// <returns>The Sorted result.</returns>
        public static IQueryable<T> ThenBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.ApplyOrder(propertyName, "ThenBy");
        }

        /// <summary>
        /// Continue sorting an IQueryable, descending by any property.
        /// </summary>
        /// <typeparam name="T">The type that is handled by the IQueryable.</typeparam>
        /// <param name="source">The IQueryable to sort.</param>
        /// <param name="propertyName">The name of the property to sort by.</param>
        /// <returns>The Sorted result.</returns>
        public static IQueryable<T> ThenByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.ApplyOrder(propertyName, "ThenByDescending");
        }
    }
}
