using Microsoft.EntityFrameworkCore;
using Winery.API.Models.DTOs.Sectors;
using Winery.API.Models.Entities.Sectors;
using Winery.API.Repositories.Sectors;

namespace Winery.API.Services.Sectors
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository sectorRepository;

        public SectorService(ISectorRepository sectorRepository)
        {
            this.sectorRepository = sectorRepository;
        }

        public async Task<(bool, string)> AddSectorAsync(CreateSectorDto createSectorDto)
        {
            bool exists = await sectorRepository
                .SelectAllSectors()
                .AnyAsync(x => x.Code == createSectorDto.Code);

            if (exists)
            {
                return (false, "A sector with the same code already exists.");
            }

            Sector sector = new Sector
            {
                Code = createSectorDto.Code,
                IsActive = createSectorDto.IsActive
            };

            await sectorRepository.InsertSectorAsync(sector);

            return (true, "Success");
        }


        public async Task<List<Sector>> RetrieveAllSectors(string search)
        {
            List<Sector> sectors = await sectorRepository
                .SelectAllSectors()
                .Where(x => string.IsNullOrWhiteSpace(search) || x.Code.Contains(search))
                .ToListAsync();

            return sectors;
        }

        public async Task<Sector> RetrieveSectorById(Guid id) =>
            await sectorRepository.SelectSectorByIdAsync(id);


        public async Task<(bool, string)> UpdateSectorAsync(UpdateSectorDto updateSectorDto)
        {

            Sector sector = await sectorRepository.SelectSectorByIdAsync(updateSectorDto.Id);

            if (sector == null)
            {
                return (false, $"Couldn't find sector with id: {updateSectorDto.Id}");
            }

            bool exists = await sectorRepository
                .SelectAllSectors()
                .AnyAsync(x => x.Code == updateSectorDto.Code);

            if(exists)
            {
                return (false, "A sector with the same code already exists.");
            }

            sector.Code = updateSectorDto.Code;
            sector.IsActive = updateSectorDto.IsActive;
            await sectorRepository.UpdateSectorAsync(sector);

            return (true, "Success");
        }

        public async Task<(bool, string)> DeleteSectorByIdAsync(Guid id)
        {
            Sector sector = await sectorRepository
                .SelectAllSectors() 
                .Include(x => x.Tanks) 
                .FirstOrDefaultAsync(x => x.Id == id);

            if (sector == null)
            {
                return (false, $"Couldn't find sector with id: {id}");
            }

            if (sector.Tanks.Count > 0)
            {
                return (false, "Cannot delete sector because it has existing tanks");
            }

            await sectorRepository.DeleteSectorAsync(sector);

            return (true, "Success");
        }
    }
}
