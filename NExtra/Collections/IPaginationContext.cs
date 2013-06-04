using System.Collections.Generic;
using System.Linq;

namespace NExtra.Collections
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can handle collection pagination.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IPaginationContext<out T>
    {
        /// <summary>
        /// Get the original collection that was used to initialize the context.
        /// </summary>
        IQueryable<T> Collection { get; }

        /// <summary>
        /// The page index for a "next" page; -1 if none exists.
        /// </summary>
        int NextPageLink { get; }

        /// <summary>
        /// The total number of available pages.
        /// </summary>
        int PageCount { get; }

        /// <summary>
        /// The total number of page links to display.
        /// </summary>
        int PageLinkCount { get; }

        /// <summary>
        /// The max number of page links to display; minimum 1.
        /// </summary>
        int PageLinkMaxCount { get; set; }

        /// <summary>
        /// The page links to display in a pagination component.
        /// </summary>
        List<int> PageLinks { get; }

        /// <summary>
        /// The current page number; minimum 1 and maximum PageCount.
        /// </summary>
        int PageNumber { get; set; }

        /// <summary>
        /// The max number of items to display per page; minimum 1.
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// The page index for a "previous" page; -1 if none exists.
        /// </summary>
        int PreviousPageLink { get; }

        /// <summary>
        /// Whether or not a "next" page link should be displayed.
        /// </summary>
        bool ShowNextPageLink { get; }

        /// <summary>
        /// Whether or not a "previous" page link should be displayed.
        /// </summary>
        bool ShowPreviousPageLink { get; }

        /// <summary>
        /// The paginated, resulting collection, based on the context setup.
        /// </summary>
        IQueryable<T> GetPaginationResult();
    }
}