using Endpoint.Utilities.Models;
using System;

namespace Endpoint.Utilities.Interface;

public interface IRepo
{
    Task<IEnumerable<Make>> GetMake();
    Task<IEnumerable<Feature>> GetFeatured();
    void AddVehicle(Vehicle vehicle);
    Task<Vehicle> GetVehicleById(Guid id, bool includeRelated = true);
    void RemoveVehicle(Vehicle vehicle);
}
