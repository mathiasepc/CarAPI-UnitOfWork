
using Queries.Core.Domain;

namespace Queries.Core.IRepositories;

public interface IMakeRepo
{
    Task<IEnumerable<Make>> GetMake();
}
