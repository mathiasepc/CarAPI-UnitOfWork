using Queries.Extensions;

namespace Queries.Core.Domain;

// Den nedarver ikke fra base, da den må være optional.
// Samtidig mere overskueligt, at den har sine egne id'er. Man kan se hvad den filtre på-


// Hvis flere properties, som skal på filteres, indsæt her.
// F.eks. ModelId.
public class VehicleQuery : IQueryObject
{
    public Guid? MakeId { get; set; }
    public string? SortBy { get; set; }
    public bool IsSortAscending { get; set; } = true;
}
