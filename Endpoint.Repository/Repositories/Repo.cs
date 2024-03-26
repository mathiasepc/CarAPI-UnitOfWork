using Endpoint.Repository.Database;
using Endpoint.Utilities.Interface;
using Endpoint.Utilities.Models;
using Microsoft.EntityFrameworkCore;

namespace Endpoint.Repository.Repositories;

public class Repo : IRepo
{
    private readonly DatabaseContext _context;
    public Repo(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Make>> GetMake()
    {
        return await _context.Makes.Include(m => m.Models).ToListAsync();
    }

    public async Task<IEnumerable<Feature>> GetFeatured()
    {
        return await _context.Features.ToListAsync();
    }

    public async Task<bool> Insert(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);

        await SaveAsync();

        return true;
    }

    public async Task<Vehicle> GetVehicleById(Guid id)
    {
        return id != null ? await _context?.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id) : new Vehicle();
    }

    public async Task<bool> SaveAsync()
    {
        await _context.SaveChangesAsync();

        return true; 
    }

    public async Task<Guid> DeleteVehicle(Vehicle vehicle)
    {
        _context.Remove(vehicle);

        var saveResult = await SaveAsync();

        return saveResult == true ? vehicle.Id : Guid.Empty;
    }
}
