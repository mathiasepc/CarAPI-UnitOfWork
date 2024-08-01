using Endpoint.DTO.Validering;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Endpoint.DTO.Resources;

public class SaveVehicleResource : BaseModelResource
{
    public bool IsRegistered { get; set; }
    public ContactResource Contact { get; set; }

    [RequiredGuid]
    public Guid? ModelId { get; set; }
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
