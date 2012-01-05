using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation
{
	/// <summary>
	/// This attribute can be used to validate whether or
	/// not a string conforms to the LUHN algorithm.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public class LuhnAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var str = value.ToString();

            var sum = 0;
            for (var i = 0; i < str.Length; i++)
            {
                var temp = (str[i] - '0') << (1 - (i & 1));
                if (temp > 9) temp -= 9;
                sum += temp;
            }

            return (sum % 10) == 0; 
        }
    }
}
