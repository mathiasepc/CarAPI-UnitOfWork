using System.Collections.ObjectModel;

namespace Endpoint.Controllers.Resources;

public class VehicleResource : BaseModelResource
{
    public bool IsRegistered { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.Now;
    public ContactResource Contact { get; set; }
    public KeyValuePairResource Model { get; set; }
    public KeyValuePairResource Make { get; set; }

    // Features reference M - M
    public ICollection<KeyValuePairResource>? Features { get; set; }

    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public VehicleResource()
    {
        Features = new Collection<KeyValuePairResource>();
    }
}
