using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Queries.Core.Domain;

[Table("Models")]
public class Model : BaseModel
{
    public string Name { get; set; }

    // Make reference 1 - M
    public Guid MakeId { get; set; }
    public Make Make { get; set; }

    // Vehicle reference 1 - M
    public ICollection<Vehicle>? Vehicles { get; set; }

    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public Model()
    {
        Vehicles = new Collection<Vehicle>();
    }
}