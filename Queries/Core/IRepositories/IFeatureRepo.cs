
using Queries.Core.Domain;

namespace Queries.Core.IRepositories;

public interface IFeatureRepo
{
    Task<IEnumerable<Feature>> GetFeatured();
}
