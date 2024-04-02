using Endpoint.Repository.Database;
using Endpoint.Utilities.Interface;
using Microsoft.EntityFrameworkCore;

namespace Endpoint.Repository;

/// <summary>
/// Her laver vi en save repository for alle repository. 
/// Grunden til dette er, at hvis den fejler på en save, men ikke en anden, kan vi få data som ikke skal gemmes.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext context;
    public UnitOfWork(DatabaseContext context)
    {
        this.context = context;
    }
    public async Task<bool> CompleteAsync()
    {
        try
        {
            // Gem ændringer asynkront
            await context.SaveChangesAsync();
            // Returner true, hvis gemmeprocessen fuldførtes succesfuldt
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            // Håndter konkurrencedatabasefejl her
            // F.eks. hvis rækken blev ændret eller slettet af en anden samtidig
            return false;
        }
        catch (DbUpdateException)
        {
            // Håndter generelle databasefejl her
            return false;
        }
    }
}
