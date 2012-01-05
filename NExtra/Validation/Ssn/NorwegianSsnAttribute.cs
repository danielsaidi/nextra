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
    /// For now, the validator only checks the format of the string. A
    /// more thorough checksum validation should be implemented, so be
    /// asport and fill out the blanks, if you use this class and find
    /// it incomplete.
    /// 
    /// To validate more complex scenarios, like correct sex or region,
    /// create a separate class and override the IsValid method.
	/// </remarks>
	public class NorwegianSsnAttribute : RegularExpressionAttribute
    {
        public const string Expression = "^\\b(0[1-9]|[12]\\d|3[01])([04][1-9]|[15][0-2])\\d{7}\\b$";


        public NorwegianSsnAttribute()
            : base(Expression) { }


        public override bool IsValid(object value)
        {
            // Use the default RegularExpressionAttribute behavior
            if (value == null || value.ToString() == string.Empty)
                return true;

            return base.IsValid(value) && IsValidChecksum(value.ToString());
		}

        private static bool IsValidChecksum(string value)
        {
            return true;
        }
	}
}
