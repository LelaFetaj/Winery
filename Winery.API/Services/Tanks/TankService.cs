using Microsoft.EntityFrameworkCore;
using Winery.API.Models.DTOs.Tanks;
using Winery.API.Models.Entities.Tanks;
using Winery.API.Repositories.Tanks;

namespace Winery.API.Services.Tanks
{
    public class TankService : ITankService
    {
        private readonly ITankRepository tankRepository;

        public TankService(ITankRepository tankRepository)
        {
            this.tankRepository = tankRepository;
        }

        public async Task<(bool, string)> AddTankAsync(CreateTankDto createTankDto)
        {
            if (createTankDto.Quantity > createTankDto.Volume
                || createTankDto.Volume < 0
                || createTankDto.Quantity < 0)
            {
                return (false, "Quantity cannot be larger than volume.");
            }

            bool exists = await tankRepository
               .SelectAllTanks()
               .AnyAsync(x => x.Code == createTankDto.Code);

            if (exists)
            {
                return (false, "A tank with the same code already exists.");
            }

            Tank tank = new Tank
            {
                Code = createTankDto.Code,
                Type = createTankDto.Type,
                Volume = createTankDto.Volume,
                Quantity = createTankDto.Quantity,
                SectorId = createTankDto.SectorId
            };

            await tankRepository.InsertTankAsync(tank);

            return (true, "Success");
        }

        public async Task<List<Tank>> RetrieveAllTanks(string search)
        {
            List<Tank> tanks = await tankRepository
                .SelectAllTanks()
                .Where(x => string.IsNullOrWhiteSpace(search) || x.Code.Contains(search))
                .ToListAsync();

            return tanks;
        }

        public async Task<List<Tank>> RetrieveAllTanksBySectorId(Guid sectorId)
        {
            List<Tank> tanks = await tankRepository
                .SelectAllTanks()
                .Where(x => x.SectorId == sectorId)
                .ToListAsync();

            return tanks;
        }

        public async Task<Tank> RetrieveTankById(Guid id) =>
            await tankRepository.SelectTankByIdAsync(id);

        public async Task<(bool, string)> UpdateTankAsync(UpdateTankDto updateTankDto)
        {
            if (updateTankDto.Quantity > updateTankDto.Volume
               || updateTankDto.Volume < 0
               || updateTankDto.Quantity < 0)
            {
                return (false, "Quantity cannot be larger than volume.");
            }

            Tank tank = await tankRepository.SelectTankByIdAsync(updateTankDto.Id);

            if (tank == null)
            {
                return (false, $"Couldn't find tank with id: {updateTankDto.Id}");
            }

            bool exists = await tankRepository
               .SelectAllTanks()
               .AnyAsync(x => x.Code == updateTankDto.Code);

            if (exists)
            {
                return (false, "A tank with the same code already exists.");
            }

            tank.Code = updateTankDto.Code;
            tank.Type = updateTankDto.Type;
            tank.Volume = updateTankDto.Volume;
            tank.Quantity = updateTankDto.Quantity;
            tank.SectorId = updateTankDto.SectorId;
            await tankRepository.UpdateTankAsync(tank);

            return (true, "Success");
        }

        public async Task<(bool, string)> DeleteTankByIdAsync(Guid id)
        {
            Tank tank = await tankRepository.SelectTankByIdAsync(id);

            if (tank == null)
            {
                return (false, $"Couldn't find tank with id: {id}");
            }

            await tankRepository.DeleteTankAsync(tank);

            return (true, "Success");
        }
    }
}
