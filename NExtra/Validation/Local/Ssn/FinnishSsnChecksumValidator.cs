namespace NExtra.Validation.Ssn
{
	/// <summary>
	/// This attribute can be used to validate whether or
	/// not a string has a format that results in a valid
	/// Finnish checksum.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
    internal class FinnishSsnChecksumValidator : IValidator
    {
        public bool IsValid(object value)
        {
            var stringValue = RemoveSeparator(value);

            var numbers = stringValue.Substring(0, 9);
            var checksum = int.Parse(numbers) % 31;

            var valueLast = stringValue.Substring(9);
            var expectedLast = "0123456789ABCDEFHJKLMNPRSTUVWXY".Substring(checksum, 1);

            return valueLast == expectedLast;
        }

        private static string RemoveSeparator(object value)
        {
            var stringValue = value.ToString();

            var separator = stringValue[6];
            if ("-+A".Contains(separator.ToString()))
                stringValue = stringValue.Substring(0, 6) + stringValue.Substring(7, 4);

            return stringValue;
        }
    }
}
