using System;
using System.ComponentModel.DataAnnotations;
using NExtra.Extensions;

namespace NExtra.DataAnnotations
{
    [Obsolete("This class is no longer used in .NExtra and will be removed in future versions.")]
    public abstract class OptionalRegularExpressionAttribute : RegularExpressionAttribute
    {
        protected OptionalRegularExpressionAttribute(string pattern, bool required) : base(pattern)
        {
            Required = required;
        }


        public bool Required { get; private set; }


        public override bool IsValid(object value)
        {
            if (value == null || value.ToString().IsNullOrEmpty())
                return !Required;
            return base.IsValid(value);
        }
    }
}
