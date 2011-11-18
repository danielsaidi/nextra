using System.ComponentModel.DataAnnotations;

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
	public class SwedishPostalCodeAttribute : RegularExpressionAttribute
    {
	    public SwedishPostalCodeAttribute(bool optionalSpace = false)
			: base(optionalSpace ? "^\\d{3}\\ ?\\d{2}$" : "^\\d{5}$") { }
	}
}
