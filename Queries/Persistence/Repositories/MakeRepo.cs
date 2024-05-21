using Microsoft.EntityFrameworkCore;
using Queries.Core.Domain;
using Queries.Core.IRepositories;

namespace Queries.Persistence.Repositories;

public class MakeRepo : IMakeRepo
{

    private readonly PlutoContext context;

    public MakeRepo(PlutoContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Make>> GetMake()
    {
        return await context.Makes.Include(m => m.Models).ToListAsync();
    }
}
