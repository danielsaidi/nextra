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
    public static class IQueryable_PaginateExtensions
    {
	    public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int pageNumber, int pageSize)
	    {
	        return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
	    }
    }
}
