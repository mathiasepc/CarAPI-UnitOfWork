using Queries.Core.Domain.LinkTables;
using System.Collections.ObjectModel;

namespace Queries.Core.Domain;

public class Vehicle : BaseModel
{
    public bool IsRegistered { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.Now;
    public Contact Contact { get; set; }

    // Model reference 1 - M
    public Guid ModelId { get; set; }
    public Model Model { get; set; }
    // Features reference M - M
    public ICollection<VehicleFeature> Features { get; set; }


    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public Vehicle()
    {
        Features = new Collection<VehicleFeature>();
    }
}
