
namespace Queries.Core.Domain;

// Den nedarver ikke fra base, da den må være optional. 
public class Filter
{
    public Guid? MakeId { get; set; }
}
