using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation
{
    /// <summary>
    /// This attribute can be used to verify if a string
    /// represents a valid e-mail address.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public class EmailAddressAttribute : RegularExpressionAttribute, IValidator
    {
		public EmailAddressAttribute()
			: base(Expression) { }

        public const string Expression = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
	}
}
