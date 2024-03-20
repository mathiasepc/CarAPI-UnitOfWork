using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Endpoint.Controllers.Resources;

public class VehicleResource : BaseModelResource
{
    public bool IsRegistered { get; set; }

    // Complex type. Contact bliver ikke oprettet som egentabel. Men som en egenskab i vehicle
    [Required]
    public ContactResource ContactResource { get; set; }

    // Model reference 1 - M
    public Guid ModelId { get; set; }
    // Features reference M - M
    public ICollection<Guid>? Features { get; set; }

    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public VehicleResource()
    {
        Features = new Collection<Guid>();
    }
}
