namespace Endpoint.Resources;

// Den nedarver ikke fra base, da den må være optional.
public class VehicleQueryResource
{
    public Guid? MakeId { get; set; }
    public string? SortBy { get; set; }
    public bool IsSortAscending { get; set; } = true;
}
