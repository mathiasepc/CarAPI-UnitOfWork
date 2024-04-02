using Endpoint.Utilities.Models;
using System;

namespace Endpoint.Utilities.Interface;

public interface IRepo
{
    Task<IEnumerable<Make>> GetMake();
    Task<IEnumerable<Feature>> GetFeatured();
    Task Insert(Vehicle vehicle);
    Task<Vehicle> GetVehicleById(Guid id, bool includeRelated = true);
    Task RemoveVehicle(Vehicle vehicle);
}
