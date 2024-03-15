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

    public async Task<IEnumerable<Features>> GetFeatured()
    {
        return await _context.Features.ToListAsync();
    }

    public async Task<bool> Insert(Vehicle vehicle)
    {
        // Hent features på id

        _context.Vehicles.Add(vehicle);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Vehicle> GetById(Guid id)
    {
        return id != null ? await _context.Vehicles.FindAsync(id) : new Vehicle();
    }
}
