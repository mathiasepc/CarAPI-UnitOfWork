using Microsoft.EntityFrameworkCore;
using Queries.Core.Domain;
using Queries.Core.IRepositories;

namespace Queries.Persistence.Repositories;

public class VehicleRepo : IVehicleRepo
{
    private readonly PlutoContext context;
    public VehicleRepo(PlutoContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Vehicle>> GetVehicles()
    {
        return context.Vehicles
            .Include(v => v.Model)
            .ThenInclude(v => v.Make)
            .Include(v => v.Features)
            .ThenInclude(vf => vf.Feature);
    }

    /// <summary>
    /// Da det kan være tungt at hente alle relationer hele tiden, har vi tilføjet includeRelated.
    /// Det gør, at når vi ikke skal hente relationer, kan vi skrive false som input parameter ved metode kald.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="includeRelated"></param>
    /// <returns></returns>
    public async Task<Vehicle> GetVehicleById(Guid id, bool includeRelated = true)
    {
        return !includeRelated ? await context.Vehicles.FindAsync(id) :
            await context?.Vehicles
            .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
            .Include(v => v.Model)
                .ThenInclude(m => m.Make)
            .SingleOrDefaultAsync(v => v.Id == id);
    }

    public void AddVehicle(Vehicle vehicle)
    {
        context.Vehicles.Add(vehicle);
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        context.Remove(vehicle);
    }
}
