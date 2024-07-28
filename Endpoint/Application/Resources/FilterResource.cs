namespace Endpoint.Application.Resources;

// Den nedarver ikke fra base, da den må være optional.
public class FilterResource
{
    public Guid? MakeId { get; set; }
}
