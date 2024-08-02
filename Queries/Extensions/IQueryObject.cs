
namespace Queries.Extensions;

/// <summary>
/// Dette interface definerer strukturen for et query-objekt.
/// </summary>
public interface IQueryObject
{
    string SortBy { get; set; }
    bool IsSortAscending { get; set; }
    int Page { get; set; }
    Byte PageSize { get; set; }
}
