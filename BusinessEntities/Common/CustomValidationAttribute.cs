using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Common
{
    public class CustomValidationAttribute
    {
        public class NotSameAsAttribute : ValidationAttribute
        {
            private readonly string _otherProperty;

            public NotSameAsAttribute(string otherProperty)
            {
                _otherProperty = otherProperty;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherProperty);
                var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);

                if (value != null && value.Equals(otherPropertyValue))
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }
        }
    }
}