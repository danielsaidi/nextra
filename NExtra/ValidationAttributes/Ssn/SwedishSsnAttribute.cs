using System.ComponentModel.DataAnnotations;

namespace NExtra.ValidationAttributes.Ssn
{
	/// <summary>
	/// This attribute can be used to validate whether or not a string
	/// represents a valid Swedish Social Security Number.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
    /// 
    /// The SSN must conform to the Luhn algorithm. To validate a more
    /// complex scenario like correct sex or region, create a separate
    /// class and override the IsValid method.
	/// </remarks>
	public class SwedishSsnAttribute : RegularExpressionAttribute
    {
        public SwedishSsnAttribute(SsnSeparatorMode separatorMode)
            : base(Expression(separatorMode)) { }


        private const string NoDashExpression = "^\\d{10}$";

        private const string OptionalDashExpression = "^\\d{6}-?\\d{4}$";

        private const string RequiredDashExpression = "^\\d{6}-\\d{4}$";


        public static string Expression(SsnSeparatorMode separatorMode)
        {
            switch (separatorMode)
            {
                case SsnSeparatorMode.None:
                    return NoDashExpression;
                case SsnSeparatorMode.Required:
                    return RequiredDashExpression;
                default:
                    return OptionalDashExpression;
            }
        }

		public override bool IsValid(object value)
        {
            if (value == null || value.ToString() == string.Empty)
                return true;

            return base.IsValid(value) && IsValidChecksum(value.ToString());
		}

        private static bool IsValidChecksum(string value)
        {
            value = value.Replace("-", "");

            return new LuhnAttribute().IsValid(value);
        }
	}
}
