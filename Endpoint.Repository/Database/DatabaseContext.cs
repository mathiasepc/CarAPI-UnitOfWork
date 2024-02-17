using Endpoint.Utilities.Models;
using Microsoft.EntityFrameworkCore;


namespace Endpoint.Repository.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> option) : base(option) { }

    //Så længe, at Model er konfigureret rigtigt. Behøver jeg kun at istansiere Makes tabel.
    public DbSet<Make>  Makes { get; set; }
}
