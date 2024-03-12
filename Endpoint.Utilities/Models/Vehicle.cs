using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Endpoint.Utilities.Models;

[Table("Vehicles")]
public class Vehicle : BaseModel
{
    public bool IsRegistered { get; set; }
    public DateTime? LastUpdated { get; set; }

    // Complex type. Contact bliver ikke oprettet som egentabel. Men som en egenskab i vehicle
    public Contact Contact { get; set; }

    // Model reference 1 - M
    public Guid? ModelId { get; set; }
    public Model? Model { get; set; }
    // Features reference M - M
    public ICollection<Features>? Features { get; set; }

    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public Vehicle()
    {
        Features = new Collection<Features>();
    }
}
