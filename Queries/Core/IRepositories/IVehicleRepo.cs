using Queries.Core.Domain;

namespace Queries.Core.IRepositories;

public interface IVehicleRepo
{
    Task<IEnumerable<Vehicle>> GetVehicles(VehicleQuery filter);
    Task<Vehicle> GetVehicleById(Guid id, bool includeRelated = true);
    void AddVehicle(Vehicle vehicle);
    void RemoveVehicle(Vehicle vehicle);
}
