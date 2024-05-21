using Microsoft.EntityFrameworkCore;
using Queries.Core.Domain;
using Queries.Core.IRepositories;

namespace Queries.Persistence.Repositories;

public class FeatureRepo : IFeatureRepo
{
    private readonly PlutoContext context;
    
    public FeatureRepo(PlutoContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Feature>> GetFeatured()
    {
        return await context.Features.ToListAsync();
    }
}
