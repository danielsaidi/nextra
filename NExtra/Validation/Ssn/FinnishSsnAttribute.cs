using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation.Ssn
{
	/// <summary>
	/// This attribute can be used to validate whether or not a string
	/// represents a valid Finnish Social Security Number.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// 
    /// To validate more complex scenarios, like correct sex or region,
    /// create a separate class and override the IsValid method.
	/// </remarks>
	public class FinnishSsnAttribute : RegularExpressionAttribute, IValidator
    {
        public const string NoSeparatorExpression = "^\\b(0[1-9]|[12]\\d|3[01])(0[1-9]|1[0-2])\\d{5}\\w\\b$";
        public const string OptionalSeparatorExpression = "^\\b(0[1-9]|[12]\\d|3[01])(0[1-9]|1[0-2])\\d{2}[-+a]?\\d{3}\\w\\b$";
        public const string RequiredSeparatorExpression = "^\\b(0[1-9]|[12]\\d|3[01])(0[1-9]|1[0-2])\\d{2}[-+a]\\d{3}\\w\\b$";

        private readonly IValidator checksumValidator;

        
        public FinnishSsnAttribute(RequiredMode separatorMode)
            : this(separatorMode, new FinnishSsnChecksumValidator()) { }

        public FinnishSsnAttribute(RequiredMode separatorMode, IValidator checksumValidator)
            : base(Expression(separatorMode))
        {
            this.checksumValidator = checksumValidator;
        }


        public static string Expression(RequiredMode separatorMode)
        {
            switch (separatorMode)
            {
                case RequiredMode.None:
                    return NoSeparatorExpression;
                case RequiredMode.Required:
                    return RequiredSeparatorExpression;
                default:
                    return OptionalSeparatorExpression;
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
