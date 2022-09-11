using Winery.API.Data.Contexts;
using Winery.API.Models.Entities.Tanks;

namespace Winery.API.Repositories.Tanks
{
    public class TankRepository : ITankRepository
    {
        private readonly WineryDbContext dbContext;

        public TankRepository(WineryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task InsertTankAsync(Tank tank)
        {
            await dbContext.Tank.AddAsync(tank);
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<Tank> SelectAllTanks() =>
            dbContext.Tank;


        public async Task<Tank> SelectTankByIdAsync(Guid id) =>
            await dbContext.Tank.FindAsync(id);

        public async Task UpdateTankAsync(Tank tank)
        {
            dbContext.Tank.Update(tank);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteTankAsync(Tank tank)
        {
            dbContext.Tank.Remove(tank);
            await dbContext.SaveChangesAsync();
        }
    }
}
