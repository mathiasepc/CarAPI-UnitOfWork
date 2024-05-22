
namespace Queries.Core.Domain.LinkTables;

public class VehicleFeature
{
    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }

    public Guid FeatureId { get; set; }
    public Feature Feature { get; set; }
}
