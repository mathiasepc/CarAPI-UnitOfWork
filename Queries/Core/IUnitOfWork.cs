using Queries.Core.IRepositories;

namespace Queries.Core;

public interface IUnitOfWork : IDisposable
{
    public IVehicleRepo VehicleRepo { get; }
    public IMakeRepo MakeRepo { get; }
    public IFeatureRepo FeatureRepo { get; }
    Task<int> CompleteASync();
}
