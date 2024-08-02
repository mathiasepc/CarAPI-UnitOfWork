using Microsoft.EntityFrameworkCore;
using Queries.Core.Domain;
using Queries.Core.IRepositories;
using Queries.Extensions;
using System.Linq.Expressions;

namespace Queries.Persistence.Repositories;

public class VehicleRepo : IVehicleRepo
{
    private readonly PlutoContext context;
    public VehicleRepo(PlutoContext context)
    {
        this.context = context;
    }

    public async Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery queryObj)
    {
        var result = new QueryResult<Vehicle>();

        // Ved at tilføje AsQueryable gør det muligt at hente data på database niveau fra variablen, senere i koden.
        var query = context.Vehicles
            .Include(v => v.Model)
            .ThenInclude(v => v.Make)
            .Include(v => v.Features)
            .ThenInclude(vf => vf.Feature)
            .AsQueryable();

        if (queryObj.MakeId.HasValue)
            // Tilføjer .Where() til query.
            query = query.Where(v => v.Model.MakeId == queryObj.MakeId);

        // Object initialization: laver en mapning af sortering på kolonner for vehicle
        var columnsMap = new Dictionary<string, Expression<Func<Vehicle, object>>>()
        {
            ["make"] = v => v.Model.Make.Name,
            ["model"] = v => v.Model.Name,
            ["contactName"] = v => v.Contact.Name 
        };

        query = query.ApplyOrdering(queryObj, columnsMap);

        // Regner total items ud
        result.TotalItems = await query.CountAsync();

        // Paging
        query = query.ApplyPaing(queryObj);

        // Sætter items
        result.Items = await query.ToListAsync();

        return result;
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
        return !includeRelated 
            ? await context.Vehicles.FindAsync(id) 
            : await context?.Vehicles
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
