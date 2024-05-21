using Microsoft.EntityFrameworkCore;
using Queries.Core.Domain.LinkTables;
using Queries.Persistence.EntityConfigurations;
using System.Collections.ObjectModel;

namespace Queries.Core.Domain;

[EntityTypeConfiguration(typeof(FeatureConfiguration))]
public class Feature : BaseModel
{
    public string Name { get; set; }

    // Vehicle reference M - M
    public ICollection<VehicleFeature> VehicleFeatures { get; set; }


    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public Feature()
    {
        VehicleFeatures = new Collection<VehicleFeature>();
    }
}
