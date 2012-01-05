using System.ComponentModel.DataAnnotations;

namespace NExtra.ValidationAttributes.Ssn
{
	/// <summary>
	/// This attribute can be used to validate whether or not a string
	/// represents a valid Swedish Social Security Number, on the form
	/// yymmdd-xxxx or yymmddxxxx.
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
        public const string NoDashExpression = "^\\b\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])\\d{4}\\b$";
        public const string OptionalDashExpression = "^\\b\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])[-+]?\\d{4}\\b$";
        public const string RequiredDashExpression = "^\\b\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])[-+]\\d{4}\\b$";


        public SwedishSsnAttribute(SsnSeparatorMode separatorMode)
            : this(separatorMode, new LuhnAttribute()) { }

        public SwedishSsnAttribute(SsnSeparatorMode separatorMode, ValidationAttribute luhnValidator)
            : base(Expression(separatorMode)) { }


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
            // Use the default RegularExpressionAttribute behavior
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
