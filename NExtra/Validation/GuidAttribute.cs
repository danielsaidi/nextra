using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation
{
	/// <summary>
	/// This attribute can be used to validate whether or
	/// not a string represents a valid GUID.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
    public class GuidAttribute : RegularExpressionAttribute, IValidator
    {
		public GuidAttribute()
            : base(Expression) { }

	    public const string Expression =
	        @"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$";
    }
}
