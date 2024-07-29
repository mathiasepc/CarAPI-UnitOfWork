using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace Queries.Extensions;

/// <summary>
/// Denne Extension er til IQueryable. 
/// Den laves ift. at SortBy() eller SortByDescending()
/// </summary>
public static class IQueryableExtensions 
{

    /// <typeparam name="T"></typeparam>
    /// <param name="query">query: variablen sorteringen vil blive anvendt på</param>
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
}
