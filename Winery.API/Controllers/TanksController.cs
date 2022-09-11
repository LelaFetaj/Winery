using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Winery.API.Models.DTOs.Tanks;
using Winery.API.Models.Entities.Tanks;
using Winery.API.Repositories.Tanks;
using Winery.API.Services.Tanks;

namespace Winery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TanksController : ControllerBase
    {
        private readonly ITankService tankService;

        public TanksController(ITankService tankService)
        {
            this.tankService = tankService;
        }
        
        [HttpPost]
        public async Task<ActionResult<string>> AddTank (CreateTankDto createTankDto)
        {
            try
            {
                (bool result, string message) = await tankService.AddTankAsync(createTankDto);

                if (result)
                {
                    return Ok(message);
                }

                return Problem(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Tank>>> GetAllTanks(string search)
        {
            try
            {
                List<Tank> tanks = await tankService.RetrieveAllTanks(search);
                return Ok(tanks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Tank>>> GetAllTanksBySectorId(Guid sectorId)
        {
            try
            {
                List<Tank> tanks = await tankService.RetrieveAllTanksBySectorId(sectorId);
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
                Tank tank = await tankService.RetrieveTankById(id);
                return Ok(tank);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateTank(UpdateTankDto updateTankDto)
        {
            try
            {
                (bool result, string message) = await tankService.UpdateTankAsync(updateTankDto);

                if (result)
                {
                    return Ok(message);
                }

                return Problem(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTank(Guid id)
        {
            try
            {
                (bool result, string message) = await tankService.DeleteTankByIdAsync(id);

                if (result)
                {
                    return Ok(message);
                }

                return Problem(message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
