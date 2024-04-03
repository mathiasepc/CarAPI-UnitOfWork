using Endpoint.Repository.Database;
using Endpoint.Utilities.Interface;
using Endpoint.Utilities.Models;
using Microsoft.EntityFrameworkCore;

namespace Endpoint.Repository.Repositories;

public class Repo : IRepo
{
    private readonly DatabaseContext context;
    public Repo(DatabaseContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Make>> GetMake()
    {
        return await context.Makes.Include(m => m.Models).ToListAsync();
    }

    public async Task<IEnumerable<Feature>> GetFeatured()
    {
        return await context.Features.ToListAsync();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        context.Vehicles.Add(vehicle);
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

    public void RemoveVehicle(Vehicle vehicle)
    {
        context.Remove(vehicle);
    }
}
