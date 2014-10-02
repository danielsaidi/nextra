using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation.Ssn
{
	/// <summary>
	/// This attribute can be used to verify if a string
	/// represents a Swedish Social Security Number. The
	/// format is yymmdd-xxxx with various dash modes.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// The SSN must conform to the Luhn algorithm. This
    /// algorithm will verify the checksum, and will run
    /// server-side, in the IsValid method.
	/// </remarks>
	public class SwedishSsnAttribute : RegularExpressionAttribute, IValidator
    {
        private const string DashExpression = "^\\b\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])[-+]\\d{4}\\b$";
        private const string NoDashExpression = "^\\b\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])\\d{4}\\b$";
        private const string OptionalDashExpression = "^\\b\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])[-+]?\\d{4}\\b$";

	    private readonly IValidator _checksumValidator;


        public SwedishSsnAttribute(UseSeparator useDash)
            : this(useDash, new SwedishSsnChecksumValidator()) { }

        public SwedishSsnAttribute(UseSeparator useDash, IValidator checksumValidator)
            : base(Expression(useDash))
        {
            this._checksumValidator = checksumValidator;
        }


        public static string Expression(UseSeparator useDash)
        {
            switch (useDash)
            {
                case UseSeparator.No:
                    return NoDashExpression;
                case UseSeparator.Yes:
                    return DashExpression;
                default:
                    return OptionalDashExpression;
            }
        }

		public override bool IsValid(object value)
        {
            // Use the default RegularExpressionAttribute behavior
            if (value == null || value.ToString() == string.Empty)
                return true;

            return base.IsValid(value) && _checksumValidator.IsValid(value);
		}
	}
}
