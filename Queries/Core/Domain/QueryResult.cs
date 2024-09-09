
namespace Queries.Core.Domain;

/// <summary>
/// Dette Query-objekt bruges til at returnere resultater af objekter fra en query.
/// Den indeholder både det samlede antal elementer, der matcher queryen,
/// samt en samling af de faktiske resultater.
/// </summary>
/// <typeparam name="T">Typen af objekter i resultatsættet.</typeparam>
public class QueryResult<T>
{
    // Bruges bl.a. til at kunne lave pagning
    public int TotalItems { get; set; }
    public IEnumerable<T> Items { get; set; }
}
