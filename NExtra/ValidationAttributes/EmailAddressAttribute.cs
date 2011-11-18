using System.ComponentModel.DataAnnotations;

namespace NExtra.ValidationAttributes
{
    /// <summary>
    /// This attribute can be used to validate whether or
    /// not a string represents a valid e-mail address.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public class EmailAddressAttribute : RegularExpressionAttribute
    {
		public EmailAddressAttribute()
			: base(Expression) { }

        public const string Expression =
            @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
	}
}
