using System.ComponentModel.DataAnnotations;

namespace Endpoint.Application.Validation
{
    /// <summary>
    /// Da attributes ikke kan tage imod guid. Har jeg konfigureret det ekstra indstillinger.
    /// </summary>
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
