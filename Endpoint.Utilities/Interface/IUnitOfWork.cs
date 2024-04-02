
namespace Endpoint.Utilities.Interface;

/// <summary>
/// Her laver vi en safe repository for alle repository. 
/// Grunden til dette er, at hvis den fejler på en safe, men ikke en anden, kan vi få data som ikke skal gemmes.
/// </summary>
public interface IUnitOfWork
{
    Task<bool> CompleteAsync();
}
