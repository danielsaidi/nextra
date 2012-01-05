using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation
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
            : base(Expression(optionalSpace)) { }


        private const string NoSpaceExpression = "^\\d{5}$";

        private const string OptionalSpaceExpression = "^\\d{3}\\ ?\\d{2}$";


        public static string Expression(bool optionalSpace)
        {
            return optionalSpace ? OptionalSpaceExpression : NoSpaceExpression;
        }
	}
}
