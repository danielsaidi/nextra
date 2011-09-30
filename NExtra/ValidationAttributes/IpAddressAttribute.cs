using NExtra.DataAnnotations;

namespace NExtra.ValidationAttributes
{
	/// <summary>
	/// This attribute can be used to validate whether or
	/// not a string represents a valid IP address.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public class IpAddressAttribute : OptionalRegularExpressionAttribute
	{
        /// <summary>
        /// Create an instance of the attribute class.
        /// </summary>
        /// <param name="required">Whether or not the attribute is required.</param>
        public IpAddressAttribute(bool required = true)
            : base(@"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$", required) { }
	}
}
