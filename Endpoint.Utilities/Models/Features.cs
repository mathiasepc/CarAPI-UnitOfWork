using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Endpoint.Utilities.Models;

[Table("Features")]
public class Features : BaseModel
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    // Vehicle reference M - M
    public ICollection<Vehicle>? Vehicles { get; set; }

    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public Features()
    {
        Vehicles = new Collection<Vehicle>();
    }
}
