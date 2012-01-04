using System.ComponentModel.DataAnnotations;

namespace NExtra.ValidationAttributes.Ssn
{
	/// <summary>
	/// This attribute can be used to validate whether or not a string
	/// represents a valid Finnish Social Security Number.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public class FinnishSsnAttribute : RegularExpressionAttribute
    {
        public FinnishSsnAttribute(SsnSeparatorMode separatorMode)
            : base(Expression(separatorMode)) { }


        private const string NoSeparatorExpression = "^\\b(0[1-9]|[12]\\d|3[01])(0[1-9]|1[0-2])\\d{5}\\w\\b$";

        private const string OptionalSeparatorExpression = "^\\b(0[1-9]|[12]\\d|3[01])(0[1-9]|1[0-2])\\d{2}[-+a]?\\d{3}\\w\\b$";

        private const string RequiredSeparatorExpression = "^\\b(0[1-9]|[12]\\d|3[01])(0[1-9]|1[0-2])\\d{2}[-+a]\\d{3}\\w\\b$";


        public static string Expression(SsnSeparatorMode separatorMode)
        {
            switch (separatorMode)
            {
                case SsnSeparatorMode.None:
                    return NoSeparatorExpression;
                case SsnSeparatorMode.Required:
                    return RequiredSeparatorExpression;
                default:
                    return OptionalSeparatorExpression;
            }
        }

		public override bool IsValid(object value)
        {
            if (value == null || value.ToString() == string.Empty)
                return true;

            return base.IsValid(value) && IsValidChecksum(value.ToString());
        }

        private static bool IsValidChecksum(string value)
        {
            value = RemoveSeparator(value);

            var numbers = value.Substring(0, 9);
            var checksum = int.Parse(numbers) % 31;

            var valueLast = value.Substring(9);
            var expectedLast = "0123456789ABCDEFHJKLMNPRSTUVWXY".Substring(checksum, 1);

            return valueLast == expectedLast;
        }

        private static string RemoveSeparator(string value)
        {
            var separator = value[6];
            if ("-+A".Contains(separator.ToString()))
                value = value.Substring(0, 6) + value.Substring(7, 4);

            return value;
        }
	}
}
