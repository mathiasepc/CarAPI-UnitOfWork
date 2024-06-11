using System.ComponentModel.DataAnnotations;

namespace Endpoint.Application.Validation
{
    public class GuidValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           return value == null || (Guid)value == Guid.Empty 
                ? new ValidationResult("Guid må ikke være tom.") 
                : ValidationResult.Success;
        }
    }
}
