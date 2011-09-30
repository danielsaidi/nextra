using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NExtra.Testing
{
    ///<summary>
    /// This class can be used to validate metadata
    /// conditions that has been placed on any type.
    ///</summary>
    public class MetadataValidator
    {
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        public MetadataValidator(object obj)
        {
            MetadataRegistrator.Register(obj.GetType());

            ValidationErrors = new List<ValidationResult>();
            ValidationContext = new ValidationContext(obj, null, null);
            ValidationResult = Validator.TryValidateObject(obj, ValidationContext, ValidationErrors, true);
        }


        /// <summary>
        /// The resulting validation context.
        /// </summary>
        public ValidationContext ValidationContext { get; private set; }

        /// <summary>
        /// The resulting validation errors.
        /// </summary>
        public List<ValidationResult> ValidationErrors { get; private set; }
        
        /// <summary>
        /// The resulting validation result.
        /// </summary>
        public bool ValidationResult { get; private set; }
    }
}