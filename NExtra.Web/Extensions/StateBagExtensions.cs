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
        /// Retrieve a typed value from a StateBag instance.
        /// </summary>
        public static T Get<T>(this StateBag stateBag, string key, T fallbackValue = default(T))
        {
            return stateBag[key] == null ? fallbackValue : (T)stateBag[key];
        }

		/// <summary>
		/// Add a value to a StateBag instance.
		/// </summary>
		public static void Set<T>(this StateBag stateBag, string key, T item)
		{
			stateBag[key] = item;
		}
	}
}
