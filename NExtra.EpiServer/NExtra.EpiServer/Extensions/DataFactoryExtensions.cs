using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;

namespace NExtra.EpiServer.Extensions
{
    /// <summary>
    /// Extension methods for EPiServer.DataFactory.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class DataFactoryExtensions
    {
        /// <summary>
        /// Retrieve all direct children of a certain type for a PageReference instance.
        /// </summary>
        /// <typeparam name="T">The type of children to return.</typeparam>
        /// <param name="dataFactory">The DataFactory instance to use.</param>
        /// <param name="pageReference">The PageReference instance to load children for.</param>
        /// <returns>All direct children that are of a certain type.</returns>
        public static IEnumerable<T> GetChildrenOfType<T>(this DataFactory dataFactory, PageReference pageReference)
        {
            return dataFactory.GetChildren(pageReference)
                .Where(child => child is T)
                .Cast<T>();
        }

        /// <summary>
        /// Retrieve all descendents of a certain type for a PageReference instance.
        /// </summary>
        /// <typeparam name="T">The type of descendents to return.</typeparam>
        /// <param name="dataFactory">The DataFactory instance to use.</param>
        /// <param name="pageReference">The PageReference instance to load children for.</param>
        /// <returns>All descendents that are of a certain type.</returns>
        public static IEnumerable<T> GetDescendentsOfType<T>(this DataFactory dataFactory, PageReference pageReference)
        {
            return dataFactory.GetDescendents(pageReference)
                .Where(descendent => descendent is T)
                .Cast<T>();
        }
    }
}
