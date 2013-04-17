using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation
{
    /// <summary>
    /// This attribute can be used to verify if a string
    /// is long enough, given a minimum length. 
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
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
