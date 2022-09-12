using Microsoft.AspNetCore.Mvc;
using Winery.API.Models.DTOs.Sectors;
using Winery.API.Models.Entities.Sectors;
using Winery.API.Services.Sectors;

namespace Winery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorsController : ControllerBase
    {
        private readonly ISectorService sectorService;

        public SectorsController(ISectorService sectorService)
        {
            this.sectorService = sectorService;

        }

        [HttpPost]
        public async Task<ActionResult<string>> AddSector(CreateSectorDto createSectorDto)
        {
            try
            {
                (bool result, string message) = await sectorService.AddSectorAsync(createSectorDto);

                if (result)
                {
                    return Ok(message);
                }

                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Sector>>> GetAllSectors(string search)
        {
            try
            {
                List<Sector> sectors = await sectorService.RetrieveAllSectors(search);
                return Ok(sectors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetSector(Guid id)
        {
            try
            {
                Sector sector = await sectorService.RetrieveSectorById(id);
                return Ok(sector);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateSector(UpdateSectorDto updateSectorDto)
        {
            try
            {
                (bool result, string message) = await sectorService.UpdateSectorAsync(updateSectorDto);

                if (result)
                {
                    return Ok(message);
                }

                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteSector(Guid id)
        {
            try
            {
                (bool result, string message) = await sectorService.DeleteSectorByIdAsync(id);

                if (result)
                {
                    return Ok(message);
                }

                return BadRequest(message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
