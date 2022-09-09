using Microsoft.EntityFrameworkCore;
using Winery.API.Models.Entities.Sectors;
using Winery.API.Models.Entities.Tanks;

namespace Winery.API.Data.Contexts
{
    public class WineryDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public WineryDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = this._configuration.GetConnectionString(name: "DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetTableRelations(modelBuilder);
        }

        private static void SetTableRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tank>()
                .HasOne(x => x.Sector)
                .WithMany(x => x.Tanks)
                .HasForeignKey(x => x.SectorId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Tank> Tank { get; set; }
        public DbSet<Sector> Sector { get; set; }

    }
}
