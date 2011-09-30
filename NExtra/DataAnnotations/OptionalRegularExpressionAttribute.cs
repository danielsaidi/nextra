using System.ComponentModel.DataAnnotations;
using NExtra.Extensions;

namespace NExtra.DataAnnotations
{
    /// <summary>
    /// This abstract class can be inherited by regular expression
    /// attributes classes that can either be required or optional.
    /// The class name may come to change in future versions.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public abstract class OptionalRegularExpressionAttribute : RegularExpressionAttribute
    {
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        /// <param name="pattern">The regular expression that is used to validate the data field value.</param>
        /// <param name="required">Whether or not the attribute is required.</param>
        protected OptionalRegularExpressionAttribute(string pattern, bool required) : base(pattern)
        {
            Required = required;
        }


        /// <summary>
        /// Whether or not the attribute is required.
        /// </summary>
        public bool Required { get; private set; }


        /// <summary>
        /// Checks wheter a value matches the attribute's regular expression pattern.
        /// </summary>
        /// <param name="value">The object to validate.</param>
        /// <returns>Whether or not the object is valid.</returns>
        public override bool IsValid(object value)
        {
            if (value == null || value.ToString().IsNullOrEmpty())
                return !Required;
            return base.IsValid(value);
        }
    }
}
