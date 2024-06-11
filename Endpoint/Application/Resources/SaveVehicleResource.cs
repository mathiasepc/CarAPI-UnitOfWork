using Endpoint.Application.Validation;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Endpoint.Application.Resources;

public class SaveVehicleResource : BaseModelResource
{
    public bool IsRegistered { get; set; }
    public ContactResource Contact { get; set; }

    [Required]
    [GuidValidation]
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
