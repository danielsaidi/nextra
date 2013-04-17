using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation
{
	/// <summary>
    /// This attribute can be used to verify if a string
    /// represents a valid GUID.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
    public class GuidAttribute : RegularExpressionAttribute, IValidator
    {
		public GuidAttribute()
            : base(Expression) { }

	    public const string Expression =
	        @"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$";
    }
}
