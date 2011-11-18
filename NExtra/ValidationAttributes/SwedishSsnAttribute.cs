using System.ComponentModel.DataAnnotations;

namespace NExtra.ValidationAttributes
{
	/// <summary>
	/// This attribute can be used to validate whether or not a string
	/// represents a valid Swedish Social Security Number, on the form
    /// yymmddxxxx or yymmdd-xxxx.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
    /// 
    /// The dash is optional, but the last four digits must be correct
    /// according to the Luhn algorithm. To validate more complex data
    /// conditions, e.g. that the region must be correct, inherit this
    /// class and override the IsValid method.
	/// </remarks>
	public class SwedishSsnAttribute : RegularExpressionAttribute
    {
	    public SwedishSsnAttribute(bool requireDash = true)
            : base(requireDash ? "^\\d{6}-\\d{4}$" : "^\\d{10}$") { }


		public override bool IsValid(object value)
		{
            //Abort if the value is null
            if (value == null)
                return false;

            //Abort if basic validation failed
            if (!base.IsValid(value))
                return false;

            //Remove possible dash
			var noDash = value.ToString().Replace("-", "");

            //Return false if the value is too short
            if (noDash.Length < 10)
                return false;

			//Verify the Luhn algorithm
			var sum = 0;
			for (var i = 0; i < 9; i++)
			{
			    int tmpInt;
                if (!int.TryParse(noDash[i].ToString(), out tmpInt))
                    return false;

				tmpInt = tmpInt * (((i + 1) % 2) + 1);
				sum += (tmpInt > 9) ? tmpInt - 9 : tmpInt;
				sum = (sum > 10) ? sum - 10 : sum;
			}

			//Verify the check digit
			return (10 - sum) == int.Parse(noDash[9].ToString());
		}
	}
}
