using NExtra.DataAnnotations;

namespace NExtra.ValidationAttributes
{
	/// <summary>
	/// This attribute can be used to validate whether or
	/// not a string represents a valid URL.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public class UrlAttribute : OptionalRegularExpressionAttribute
	{
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        /// <param name="required">Whether or not the attribute is required.</param>
		public UrlAttribute(bool required = true)
			: base(@"^(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?", required) { }
	}
}
