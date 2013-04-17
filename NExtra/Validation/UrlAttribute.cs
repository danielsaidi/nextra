using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation
{
	/// <summary>
	/// This attribute can be used to verify if a string
	/// represents a URL.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public class UrlAttribute : RegularExpressionAttribute, IValidator
	{
		public UrlAttribute()
			: base(Expression) { }

	    public const string Expression =
	        @"^(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
	}
}
