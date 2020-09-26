using Microsoft.EntityFrameworkCore;

namespace Codie2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Codie2.Models.Cargo> Cargo { get; set; }
        public DbSet<Codie2.Models.TimesCodie> Times { get; set; }
    }
}
