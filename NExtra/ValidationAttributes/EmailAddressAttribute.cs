using NExtra.DataAnnotations;

namespace NExtra.ValidationAttributes
{
	/// <summary>
	/// This attribute can be used to validate whether or
	/// not a string represents a valid e-mail address.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public class EmailAddressAttribute : OptionalRegularExpressionAttribute
	{
        /// <summary>
        /// Create an instance of the attribute class.
        /// </summary>
        /// <param name="required">Whether or not the attribute is required.</param>
		public EmailAddressAttribute(bool required = true)
			: base(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", required) { }
	}
}
