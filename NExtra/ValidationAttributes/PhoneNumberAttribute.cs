using System.ComponentModel.DataAnnotations;

namespace NExtra.ValidationAttributes
{
    /// <summary>
    /// This attribute can be used to validate whether or
    /// not a string represents a valid phone number.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public class PhoneNumberAttribute : RegularExpressionAttribute
    {
		public PhoneNumberAttribute()
			: base(Expression) { }

        public const string Expression =
           @"^\+?[0-9 ]{0,}?\-?[0-9 ]{0,}$";
	}
}
