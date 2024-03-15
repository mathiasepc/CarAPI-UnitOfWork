using System.ComponentModel.DataAnnotations.Schema;

namespace Endpoint.Utilities.Models.LinkTables;

[Table("VehicleFeatures")]
public class VehicleFeature
{
    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }

    public Guid FeatureId { get; set; }
    public Features Feature { get; set; }
}
