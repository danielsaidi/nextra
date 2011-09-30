using System.Web.UI;

namespace NExtra.Web.Extensions
{
	/// <summary>
	/// Extension methods for System.Web.UI.StateBag. These
    /// methods apply to every class that inherits StateBag,
    /// e.g. ViewState.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public static class StateBagExtensions
    {
        /// <summary>
        /// Retrieve an types value from a StateBag instance.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="stateBag">The StateBag instance of interest.</param>
        /// <param name="key">The key for the item.</param>
        /// <param name="fallbackValue">An optional fallback value, if the item would not exist.</param>
        /// <returns>Item or fallback value.</returns>
        public static T Get<T>(this StateBag stateBag, string key, T fallbackValue = default(T))
        {
            return stateBag[key] == null ? fallbackValue : (T)stateBag[key];
        }

		/// <summary>
		/// Add an item into a StateBag instance.
		/// </summary>
		/// <typeparam name="T">The value type.</typeparam>
		/// <param name="stateBag">The StateBag instance of interest.</param>
		/// <param name="key">The key for the item.</param>
		/// <param name="item">The item to add.</param>
		public static void Set<T>(this StateBag stateBag, string key, T item)
		{
			stateBag[key] = item;
		}
	}
}
