namespace NExtra.Validation.Ssn
{
	/// <summary>
	/// This attribute can be used to validate whether or
	/// not a string has a format that results in a valid
	/// Norwegian checksum.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
    internal class NorwegianSsnChecksumValidator : IValidator
    {
        public bool IsValid(object value)
        {
            return true;
        }

        private static string RemoveSeparator(object value)
        {
            return string.Empty;
        }
    }
}
