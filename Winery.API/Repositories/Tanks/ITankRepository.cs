using Winery.API.Models.Entities.Tanks;

namespace Winery.API.Repositories.Tanks
{
    public interface ITankRepository
    {
        Task InsertTankAsync(Tank tank);
        IQueryable<Tank> SelectAllTanks();
        Task<Tank> SelectTankByIdAsync(Guid id);
        Task UpdateTankAsync(Tank tank);
        Task DeleteTankAsync(Tank tank);

    }
}
