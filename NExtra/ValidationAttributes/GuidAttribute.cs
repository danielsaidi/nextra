using NExtra.DataAnnotations;

namespace NExtra.ValidationAttributes
{
	/// <summary>
	/// This attribute can be used to validate whether or
	/// not a string represents a valid GUID.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public class GuidAttribute : OptionalRegularExpressionAttribute
    {
        /// <summary>
        /// Create an instance of the attribute class.
        /// </summary>
        /// <param name="required">Whether or not the attribute is required.</param>
		public GuidAttribute(bool required = true)
            : base(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$", required) { }
	}
}
