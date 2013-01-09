namespace NExtra.Validation.Ssn
{
    /// <summary>
    /// This attribute can be used to validate whether or
    /// not a string has a format that results in a valid
    /// Swedish checksum.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
    internal class SwedishSsnChecksumValidator : IValidator
    {
        private readonly IValidator checksumValidator;


        public SwedishSsnChecksumValidator()
            : this(new LuhnAttribute()) { }

        public SwedishSsnChecksumValidator(IValidator checksumValidator)
        {
            this.checksumValidator = checksumValidator;
        }


        public bool IsValid(object value)
        {
            var stringValue = RemoveSeparator(value);

            return checksumValidator.IsValid(stringValue);
        }

        private static string RemoveSeparator(object value)
        {
            return value.ToString().Replace("-", "");
        }
    }
}
