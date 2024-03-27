using System.Collections.ObjectModel;

namespace Endpoint.Controllers.Resources;

public class VehicleResource : BaseModelResource
{
    public bool IsRegistered { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.Now;
    public ContactResource Contact { get; set; }
    public ModelResource Model { get; set; }

    // Features reference M - M
    public ICollection<FeaturedResource>? Features { get; set; }

    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public VehicleResource()
    {
        Features = new Collection<FeaturedResource>();
    }
}
