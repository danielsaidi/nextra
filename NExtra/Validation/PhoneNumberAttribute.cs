using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation
{
    /// <summary>
    /// This attribute can be used to validate whether or
    /// not a string represents a valid phone number. The
    /// expression allows one initial, optional plus sign
    /// and two ranges of digits and spaces, separated by
    /// one optional dash.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.dotnextra.com
	/// </remarks>
	public class PhoneNumberAttribute : RegularExpressionAttribute, IValidator
    {
		public PhoneNumberAttribute()
			: base(Expression) { }

        public const string Expression =
           @"^\+?[0-9 ]{0,}?\-?[0-9 ]{0,}$";
	}
}
