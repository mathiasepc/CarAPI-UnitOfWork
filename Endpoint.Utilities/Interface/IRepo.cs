using Endpoint.Utilities.Models;
using System;

namespace Endpoint.Utilities.Interface;

public interface IRepo
{
    Task<IEnumerable<Make>> GetMake();
    Task<IEnumerable<Feature>> GetFeatured();
    Task<bool> Insert(Vehicle vehicle);
    Task<Vehicle> GetVehicleById(Guid id);

    Task<bool> SaveAsync();
    Task<Guid> DeleteVehicle(Vehicle vehicle);
}
