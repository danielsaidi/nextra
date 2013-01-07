using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation
{
    /// <summary>
    /// This attribute can be used to validate whether or
    /// not a string represents a valid e-mail address.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public class EmailAddressAttribute : RegularExpressionAttribute, IValidator
    {
		public EmailAddressAttribute()
			: base(Expression) { }

        public const string Expression =
            @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
	}
}
