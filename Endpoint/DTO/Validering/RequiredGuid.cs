using System.ComponentModel.DataAnnotations;

namespace Endpoint.DTO.Validering;

// !!!!!! Denne klasse er egentlig ikke nødvendig. Men en god illustration for, hvordan man fremadrettet kan lave Costum validering !!!!!

/// <summary>
/// Den går ind og validere på Guid. Men man kan bare ikke lade den være tom. Den når aldrig valideringen hvis JSON-objektet er tomt.
/// F.eks. kan ModelId="" ikke nå validering.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class RequiredGuid : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult(ErrorMessage ?? "Guid is required");

        if (value is Guid guidValue)
        {
            if (guidValue == Guid.Empty)
            {
                return new ValidationResult(ErrorMessage ?? "Guid cannot be empty.");
            }

            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Invalid Guid format.");
    }
}
