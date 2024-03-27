using System.Collections.ObjectModel;

namespace Endpoint.Controllers.Resources;

public class SaveVehicleResource : BaseModelResource
{
    public bool IsRegistered { get; set; }
    public ContactResource Contact { get; set; }
    public Guid ModelId { get; set; }
    // Features reference M - M
    public ICollection<Guid>? Features { get; set; }

    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public SaveVehicleResource()
    {
        Features = new Collection<Guid>();
    }
}
