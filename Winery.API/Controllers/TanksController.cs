using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Winery.API.Models.Entities.Tanks;
using Winery.API.Repositories.Tanks;

namespace Winery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TanksController : ControllerBase
    {
        private readonly ITankRepository tankRepository;

        public TanksController(ITankRepository tankRepository)
        {
            this.tankRepository = tankRepository;
        }
        
        [HttpPost]
        public async Task<ActionResult> AddTank (Tank tank)
        {
            try
            {
                await tankRepository.InsertTankAsync(tank);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Tank>>> GetAllTanks()
        {
            try
            {
                List<Tank> tanks = await tankRepository.SelectAllTanks().ToListAsync();
                return Ok(tanks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tank>> GetTank(Guid id)
        {
            try
            {
                Tank tank = await tankRepository.SelectTankByIdAsync(id);
                return Ok(tank);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTank(Tank tank)
        {
            try
            {
                await tankRepository.UpdateTankAsync(tank);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTank(Guid id)
        {
            try
            {
                Tank tank = await tankRepository.SelectTankByIdAsync(id);
                await tankRepository.DeleteTankAsync(tank);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
