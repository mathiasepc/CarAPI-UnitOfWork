using System.ComponentModel.DataAnnotations;

namespace Endpoint.Application.Resources;

public class ContactResource
{
    [Required(ErrorMessage = "Mangler navn på kontakt.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Mangler Email.")]
    public string Email { get; set; }
    public string Phone { get; set; }
}
