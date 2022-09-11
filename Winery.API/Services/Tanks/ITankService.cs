using Winery.API.Models.DTOs.Tanks;
using Winery.API.Models.Entities.Tanks;

namespace Winery.API.Services.Tanks
{
    public interface ITankService
    {
        Task<(bool, string)> AddTankAsync(CreateTankDto createTankDto);

        Task<List<Tank>> RetrieveAllTanks(string search);
        
        Task<List<Tank>> RetrieveAllTanksBySectorId(Guid sectorId);

        Task<Tank> RetrieveTankById(Guid id);

        Task<(bool, string)> UpdateTankAsync(UpdateTankDto updateTankDto);

        Task<(bool, string)> DeleteTankByIdAsync(Guid id);
        
    }
}
