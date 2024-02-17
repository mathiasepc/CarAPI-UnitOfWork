using Endpoint.Utilities.Models;
using Microsoft.EntityFrameworkCore;


namespace Endpoint.Repository.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> option) : base(option) { }
    public DbSet<Make>  Makes { get; set; }
}
