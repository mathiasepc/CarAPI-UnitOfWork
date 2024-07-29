using Queries.Core;
using Queries.Core.IRepositories;
using Queries.Persistence.Repositories;

namespace Queries.Persistence;

/// <summary>
/// Her laver vi en save repository for alle repository. 
/// Grunden til dette er, at hvis den fejler på en save, men ikke en anden, Gemmer den ingen af data'en.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly PlutoContext _context;
    
    public UnitOfWork(PlutoContext context)
    {
        _context = context;
        VehicleRepo = new VehicleRepo(_context);
        MakeRepo = new MakeRepo(_context);
        FeatureRepo = new FeatureRepo(_context);
    }

    public IVehicleRepo VehicleRepo { get; private set; }
    public IMakeRepo MakeRepo { get; private set; }
    public IFeatureRepo FeatureRepo { get; private set; }

    public int Complete()
    {
        // Gem ændringer asynkront
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
