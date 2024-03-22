using Endpoint.Utilities.Models.LinkTables;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Endpoint.Utilities.Models;

[Table("Features")]
public class Feature : BaseModel
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    // Vehicle reference M - M
    public ICollection<VehicleFeature>? Vehicles { get; set; }

    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public Feature()
    {
        Vehicles = new Collection<VehicleFeature>();
    }
}
