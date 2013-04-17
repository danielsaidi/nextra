using System.Web.UI;

namespace NExtra.Web.Extensions
{
	/// <summary>
	/// Extension methods for System.Web.UI.StateBag.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public static class StateBagExtensions
    {
        public static T Get<T>(this StateBag stateBag, string key, T fallbackValue = default(T))
        {
            return stateBag[key] == null ? fallbackValue : (T)stateBag[key];
        }

		public static void Set<T>(this StateBag stateBag, string key, T value)
		{
			stateBag[key] = value;
		}
	}
}
