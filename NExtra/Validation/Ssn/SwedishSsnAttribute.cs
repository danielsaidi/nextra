using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation.Ssn
{
	/// <summary>
	/// This attribute can be used to validate whether or not a string
	/// represents a valid Swedish Social Security Number, on the form
	/// yymmdd-xxxx or yymmddxxxx.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// The SSN must conform to the Luhn algorithm. To validate a more
    /// complex scenario like correct sex or region, create a separate
    /// class and override the IsValid method.
	/// </remarks>
	public class SwedishSsnAttribute : RegularExpressionAttribute, IValidator
    {
        public const string NoDashExpression = "^\\b\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])\\d{4}\\b$";
        public const string OptionalDashExpression = "^\\b\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])[-+]?\\d{4}\\b$";
        public const string RequiredDashExpression = "^\\b\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])[-+]\\d{4}\\b$";

	    private readonly IValidator checksumValidator;


        public SwedishSsnAttribute(RequiredMode separatorMode)
            : this(separatorMode, new SwedishSsnChecksumValidator()) { }

        public SwedishSsnAttribute(RequiredMode separatorMode, IValidator checksumValidator)
            : base(Expression(separatorMode))
        {
            this.checksumValidator = checksumValidator;
        }


        public static string Expression(RequiredMode separatorMode)
        {
            switch (separatorMode)
            {
                case RequiredMode.None:
                    return NoDashExpression;
                case RequiredMode.Required:
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

            return base.IsValid(value) && checksumValidator.IsValid(value);
		}
	}
}
