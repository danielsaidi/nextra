using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation
{
    /// <summary>
    /// This attribute can be used to validate if a string
    /// is long enough, given a minimum length. 
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class MinLengthAttribute : ValidationAttribute, IValidator
    {
        private readonly int minLength;


        public MinLengthAttribute(int minLength)
        {
            this.minLength = minLength;
        }

        
        public override bool IsValid(object value)
        {
            var str = value as string;
            return str != null && str.Length >= minLength;
        }
    }
}
