using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation.Ssn
{
    /// <summary>
    /// This attribute can be used to verify if a string
	/// represents a Finnish Social Security Number.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public class FinnishSsnAttribute : RegularExpressionAttribute, IValidator
    {
        private const string DashExpression = "^\\b(0[1-9]|[12]\\d|3[01])(0[1-9]|1[0-2])\\d{2}[-+a]\\d{3}\\w\\b$";
        private const string NoDashExpression = "^\\b(0[1-9]|[12]\\d|3[01])(0[1-9]|1[0-2])\\d{5}\\w\\b$";
        private const string OptionalDashExpression = "^\\b(0[1-9]|[12]\\d|3[01])(0[1-9]|1[0-2])\\d{2}[-+a]?\\d{3}\\w\\b$";

        private readonly IValidator _checksumValidator;


        public FinnishSsnAttribute(UseSeparator useSeparator)
            : this(useSeparator, new FinnishSsnChecksumValidator()) { }

        public FinnishSsnAttribute(UseSeparator useSeparator, IValidator checksumValidator)
            : base(Expression(useSeparator))
        {
            this._checksumValidator = checksumValidator;
        }


        public static string Expression(UseSeparator useSeparator)
        {
            switch (useSeparator)
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
