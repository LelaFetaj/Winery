using Winery.API.Models.Entities.Sectors;

namespace Winery.API.Repositories.Sectors
{
    public interface ISectorRepository
    {
        Task InsertSectorAsync(Sector sector);
        IQueryable<Sector> SelectAllSectors();
        Task<Sector> SelectSectorByIdAsync(Guid id);
        Task UpdateSectorAsync(Sector sector);
        Task DeleteSectorAsync(Sector sector);
    }
}
