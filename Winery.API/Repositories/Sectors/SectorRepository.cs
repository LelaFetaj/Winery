using Winery.API.Data.Contexts;
using Winery.API.Models.Entities.Sectors;

namespace Winery.API.Repositories.Sectors
{
    public class SectorRepository : ISectorRepository
    {
        private readonly WineryDbContext dbContext;

        public SectorRepository(WineryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task InsertSectorAsync(Sector sector)
        {
            await dbContext.Sector.AddAsync(sector);
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<Sector> SelectAllSectors() =>
            dbContext.Sector;

        public async Task<Sector> SelectSectorByIdAsync(Guid id) =>
            await dbContext.Sector.FindAsync(id);

        public async Task UpdateSectorAsync(Sector sector)
        {
            dbContext.Sector.Update(sector);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteSectorAsync(Sector sector)
        {
            dbContext.Sector.Remove(sector);
            await dbContext.SaveChangesAsync();
        }
    }
}
