using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Endpoint.Utilities.Models;

[Table("Models")]
public class Model : BaseModel
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    // Make reference 1 - M
    public Make Make { get; set; }
    public Guid MakeId { get; set; }
    public ICollection<Vehicle>? Vehicles { get; set; }

    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public Model()
    {
        Vehicles = new Collection<Vehicle>();
    }
}