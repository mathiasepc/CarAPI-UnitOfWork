using Queries.Core.Domain;

namespace Queries.Core.IRepositories;

public interface IVehicleRepo
{
    void AddVehicle(Vehicle vehicle);
    Task<Vehicle> GetVehicleById(Guid id, bool includeRelated = true);
    void RemoveVehicle(Vehicle vehicle);
}
