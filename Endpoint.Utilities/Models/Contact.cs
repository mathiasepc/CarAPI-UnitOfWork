using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Endpoint.Utilities.Models;
// Da det er en complex type, som findes i vehicle, behøver vi ikke en Key.
[ComplexType]
[Table("Contact")]
public class Contact
{
    [Required(ErrorMessage = "Navn mangler.")]
    [StringLength(255)]
    public string Name { get; set; }
    [StringLength(255)]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Telefonnummer mangler.")]
    [StringLength(255)]
    public string Phone { get; set; }
}
