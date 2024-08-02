using Queries.Extensions;

namespace Queries.Core.Domain;


// Hvis flere properties, som skal på filteres, indsæt her.
// F.eks. ModelId.
public class VehicleQuery : IQueryObject
{
    public Guid? MakeId { get; set; }
    public string? SortBy { get; set; }
    public bool IsSortAscending { get; set; } = true;
    public int Page { get; set; }
    public byte PageSize { get; set; }
}
