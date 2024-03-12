using Endpoint.Utilities.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Endpoint.Controllers.Resources;

public class ContactResource {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

public class VehicleResource
{
    public bool IsRegistered { get; set; }
    public DateTime LastUpdated { get; set; }

    // Complex type. Contact bliver ikke oprettet som egentabel. Men som en egenskab i vehicle
    public ContactResource ContactResource { get; set; }

    // Model reference 1 - M
    public Guid ModelId { get; set; }
    // Features reference M - M
    public ICollection<Features> Features { get; set; }

    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public VehicleResource()
    {
        Features = new Collection<Features>();
    }
}
