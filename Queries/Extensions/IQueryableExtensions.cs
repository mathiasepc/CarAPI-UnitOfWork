using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace Queries.Extensions;

/// <summary>
/// Denne Extension er til IQueryable. 
/// Den laves ift. at SortBy() eller SortByDescending()
/// </summary>
public static class IQueryableExtensions 
{

    /// <summary>
    /// Udfra variablen IsSortAscending er sandt eller falsk, sorter Ascending eller descending
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query">query: variablen sorteringen vil blive anvendt på. Query kommer fra kaldet.</param>
    /// <param name="queryObj">queryObj: er den variable som indeholder kriterierne for sorteringen.</param>
    /// <param name="columnsMap">columnsMap: Mappingen som er blevet lavet. på et objekt</param>
    /// <returns></returns>
    public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
    {
        // Hvis SortBy er null eller vi sortere på Id.
        if(queryObj.SortBy.IsNullOrEmpty() || !columnsMap.ContainsKey(queryObj.SortBy))
            return query;

        return queryObj.IsSortAscending
            ? query = query.OrderBy(columnsMap[queryObj.SortBy])
            : query = query.OrderByDescending(columnsMap[queryObj.SortBy]);
    }


    public static IQueryable<T> ApplyPaing<T>(this IQueryable<T> query, IQueryObject queryObj)
    {
        if(queryObj.Page <= 0)
            queryObj.Page = 1;

        // Hvis PageSize = 0. Crasher den.
        if(queryObj.PageSize <= 0)
            queryObj.PageSize = 10;

        // Skip() springer over de elementer, der er på de tidligere sider.
        // .Take() henter kun det antal elementer, der er nødvendige for den aktuelle side.
        return query = query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
    }
}
