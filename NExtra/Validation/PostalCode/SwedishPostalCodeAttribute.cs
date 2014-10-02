using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation.PostalCode
{
	/// <summary>
	/// This attribute can be used to validate whether or not
	/// a string represents a valid Swedish postal code, with
	/// five digits and an optional space after the 3rd digit.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
	public class SwedishPostalCodeAttribute : RegularExpressionAttribute, IValidator
    {
        private const string NoSpaceExpression = "^\\d{5}$";
        private const string OptionalSpaceExpression = "^\\d{3}\\ ?\\d{2}$";
        private const string SpaceExpression = "^\\d{3}\\ \\d{2}$";


	    public SwedishPostalCodeAttribute(UseSeparator useSpace)
            : base(Expression(useSpace)) { }


        public static string Expression(UseSeparator useSpace)
        {
            switch (useSpace)
            {
                case UseSeparator.Yes:
                    return SpaceExpression;
                case UseSeparator.No:
                    return NoSpaceExpression;
                default:
                    return OptionalSpaceExpression;
            }
        }
	}
}
