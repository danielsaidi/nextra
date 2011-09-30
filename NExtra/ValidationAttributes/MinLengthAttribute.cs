using System.ComponentModel.DataAnnotations;

namespace NExtra.ValidationAttributes
{
    /// <summary>
    /// This attribute can be used to validate whether or
    /// not a string is long enough, given a min length. 
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class MinLengthAttribute : ValidationAttribute
    {
        private readonly int minLength;

        /// <summary>
        /// Create an instance of the attribute class.
        /// </summary>
        /// <param name="minLength">The minimum string le</param>
        public MinLengthAttribute(int minLength)
        {
            this.minLength = minLength;
        }

        /// <summary>
        /// Validate whether or not an object is valid according to the attribute.
        /// </summary>
        /// <param name="value">The object to validate.</param>
        /// <returns>Whether or not the object is valid.</returns>
        public override bool IsValid(object value)
        {
            var str = value as string;
            return str != null && str.Length >= minLength;
        }
    }
}
