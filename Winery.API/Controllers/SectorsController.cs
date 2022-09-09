using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Winery.API.Models.Entities.Sectors;
using Winery.API.Repositories.Sectors;

namespace Winery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorsController : ControllerBase
    {
        private readonly ISectorRepository sectorRepository;

        public SectorsController (ISectorRepository sectorRepository)
        {
            this.sectorRepository = sectorRepository;

        }

        [HttpPost]
        public async Task<ActionResult> AddSector(Sector sector)
        {
            try
            {
                await sectorRepository.InsertSectorAsync(sector);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Sector>>> GetAllSectors()
        {
            try
            {
                List<Sector> sectors = await sectorRepository.SelectAllSectors().ToListAsync();
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
                Sector sector = await sectorRepository.SelectSectorByIdAsync(id);
                return Ok(sector);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }          
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSector(Sector sector)
        {
            try
            {
                await sectorRepository.UpdateSectorAsync(sector);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSector(Guid id)
        {
            try
            {
                Sector sector = await sectorRepository.SelectSectorByIdAsync(id);
                await sectorRepository.DeleteSectorAsync(sector);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
