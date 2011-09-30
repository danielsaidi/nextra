using NExtra.DataAnnotations;

namespace NExtra.ValidationAttributes
{
	/// <summary>
	/// This attribute can be used to validate whether or not
	/// a string represents a valid Swedish postal code, with
	/// five digits and an optional space after the 3rd digit.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public class SwedishPostalCodeAttribute : OptionalRegularExpressionAttribute
    {
	    /// <summary>
	    /// Create an instance of the attribute class.
        /// </summary>
        /// <param name="required">Whether or not the attribute is required.</param>
	    /// <param name="optionalSpace">Whether or not to allow an optional space after the 3rd digit.</param>
	    public SwedishPostalCodeAttribute(bool required = true, bool optionalSpace = false)
			: base(optionalSpace ? "^\\d{3}\\ ?\\d{2}$" : "^\\d{5}$", required) { }
	}
}
