
namespace Queries.Extensions;

public interface IQueryObject
{
    string SortBy { get; set; }
    bool IsSortAscending { get; set; }
    int Page { get; set; }
    Byte PageSize { get; set; }
}
