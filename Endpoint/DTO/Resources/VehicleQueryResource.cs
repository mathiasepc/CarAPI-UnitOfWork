namespace Endpoint.DTO.Resources;

// Den nedarver ikke fra base, da den må være optional.
public class VehicleQueryResource
{
    public Guid? MakeId { get; set; }
    public string? SortBy { get; set; }
    public bool IsSortAscending { get; set; } = true;
    public int? Page { get; set; }
    public byte? PageSize { get; set; }
}
