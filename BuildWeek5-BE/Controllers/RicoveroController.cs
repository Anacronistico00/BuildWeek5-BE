using BuildWeek5_BE.DTOs;
using BuildWeek5_BE.DTOs.Ricovero;
using BuildWeek5_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildWeek5_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RicoveroController : ControllerBase
    {
        private readonly RicoveroService _ricoveroService;

        public RicoveroController(RicoveroService ricoveroService)
        {
            _ricoveroService = ricoveroService;
        }

        // GET: api/Ricovero
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<RicoveroDetailDto>>> GetRicoveri()
        {
            return Ok(await _ricoveroService.GetRicoveriAsync());
        }

        // GET: api/Ricovero/attivi
        [HttpGet("attivi")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<RicoveroDetailDto>>> GetRicoveriAttivi()
        {
            return Ok(await _ricoveroService.GetRicoveriAttiviAsync());
        }

        // GET: api/Ricovero/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RicoveroDetailDto>> GetRicovero(int id)
        {
            var ricovero = await _ricoveroService.GetRicoveroByIdAsync(id);
            if (ricovero == null) return NotFound();
            return Ok(ricovero);
        }

        // POST: api/Ricovero
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RicoveroDetailDto>> PostRicovero([FromBody] CreateRicoveroDto createRicoveroDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var newRicovero = await _ricoveroService.CreateRicoveroAsync(createRicoveroDto);
                return CreatedAtAction(nameof(GetRicovero), new { id = newRicovero.RicoveroId }, newRicovero);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Ricovero/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RicoveroDetailDto>> PutRicovero(int id, UpdateRicoveroDto updateRicoveroDto)
        {
            try
            {
                var updatedRicovero = await _ricoveroService.UpdateRicoveroAsync(id, updateRicoveroDto);
                return Ok(updatedRicovero);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Ricovero/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRicovero(int id)
        {
            var success = await _ricoveroService.DeleteRicoveroAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
