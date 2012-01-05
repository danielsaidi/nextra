using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation.Ssn
{
	/// <summary>
	/// This attribute can be used to validate whether or not a string
	/// represents a valid Norwegian Social Security Number.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
    /// 
    /// To validate more complex scenarios, like correct sex or region,
    /// create a separate class and override the IsValid method.
	/// </remarks>
	public class NorwegianSsnAttribute : RegularExpressionAttribute, IValidator
    {
        public const string Expression = "^\\b(0[1-9]|[12]\\d|3[01])([04][1-9]|[15][0-2])\\d{7}\\b$";

        private readonly IValidator checksumValidator;

        
        public NorwegianSsnAttribute()
            : this(new NorwegianSsnChecksumValidator()) { }

        public NorwegianSsnAttribute(IValidator checksumValidator)
            : base(Expression)
        {
            this.checksumValidator = checksumValidator;
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
