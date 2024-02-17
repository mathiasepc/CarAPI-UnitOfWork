using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Endpoint.Utilities.Models;

[Table("Models")]
public class Model
{
    public Guid id { get; set; }
    [Required]
    [StringLength(255)]
    public string name { get; set; }
    public Make Make { get; set; }
    public Guid MakeId { get; set; }
}