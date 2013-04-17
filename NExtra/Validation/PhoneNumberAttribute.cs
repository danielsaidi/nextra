using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation
{
    /// <summary>
    /// This attribute can be used to verify if a string
    /// represents a phone number. The expression allows
    /// one initial optional plus sign and two ranges of
    /// digits and spaces, separated by an optional dash.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public class PhoneNumberAttribute : RegularExpressionAttribute, IValidator
    {
		public PhoneNumberAttribute()
			: base(Expression) { }

        public const string Expression =
           @"^\+?[0-9 ]{0,}?\-?[0-9 ]{0,}$";
	}
}
