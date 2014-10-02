using System.Collections.Generic;
using System.Globalization;

namespace NExtra.Validation.Ssn
{
	/// <summary>
	/// This attribute can be used to validate whether or
	/// not a string has a format that results in a valid
	/// Norwegian checksum.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
    internal class NorwegianSsnChecksumValidator : IValidator
    {
        private static readonly int[] FirstMultipliers = { 3, 7, 6, 1, 8, 9, 4, 5, 2 };
        private static readonly int[] SecondMultipliers = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };


        public bool IsValid(object value)
        {
            var stringValue = value.ToString();

            return ValidateFirstCheckDigit(stringValue) && ValidateSecondCheckDigit(stringValue);
        }

	    private static int CalculateMod(string value, IList<int> multipliers)
	    {
	        var sum = 0;
	        for (var i = 0; i < multipliers.Count; i++)
	        {
	            var parse = int.Parse(value[i].ToString(CultureInfo.InvariantCulture));
                sum += parse * multipliers[i];
	        }

	        var result = 11 - sum%11;
	        if (result == 11)
	            result = 0;
	        return result;
	    }

	    private static bool ValidateFirstCheckDigit(string value)
	    {
	        var expected = int.Parse(value[9].ToString(CultureInfo.InvariantCulture));
	        var result = CalculateMod(value, FirstMultipliers);

	        return result == expected;
	    }

	    private static bool ValidateSecondCheckDigit(string value)
        {
            var expected = int.Parse(value[10].ToString(CultureInfo.InvariantCulture));
            var result = CalculateMod(value, SecondMultipliers);

            return result == expected;
        }
    }
}
