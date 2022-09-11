using Winery.API.Models.DTOs.Sectors;
using Winery.API.Models.Entities.Sectors;

namespace Winery.API.Services.Sectors
{
    public interface ISectorService
    {
        Task<(bool, string)> AddSectorAsync(CreateSectorDto createSectorDto);

        Task<List<Sector>> RetrieveAllSectors(string search);

        Task<Sector> RetrieveSectorById(Guid id);

        Task<(bool, string)> UpdateSectorAsync(UpdateSectorDto updateSectorDto);

        Task<(bool, string)> DeleteSectorByIdAsync(Guid id);
    }
}
