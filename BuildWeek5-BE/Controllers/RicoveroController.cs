using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs;
using BuildWeek5_BE.DTOs.Ricovero;
using BuildWeek5_BE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildWeek5_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RicoveroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RicoveroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ricovero
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<RicoveroDetailDto>>> GetRicoveri()
        {
            var ricoveri = await _context.Ricoveri
                .Include(r => r.Puppy)
                .Select(r => new RicoveroDetailDto
                {
                    RicoveroId = r.RicoveroId,
                    PuppyId = r.PuppyId,
                    PuppyNome = r.Puppy.Nome,
                    DataInizioRicovero = r.DataInizioRicovero,
                    Descrizione = r.Descrizione,
                    DataFineRicovero = r.DataFineRicovero
                })
                .ToListAsync();

            return ricoveri;
        }

        // GET: api/Ricovero/attivi
        [HttpGet("attivi")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<RicoveroDetailDto>>> GetRicoveriAttivi()
        {
            var ricoveriAttivi = await _context.Ricoveri
                .Include(r => r.Puppy)
                .Where(r => r.DataFineRicovero == null)
                .Select(r => new RicoveroDetailDto
                {
                    RicoveroId = r.RicoveroId,
                    PuppyId = r.PuppyId,
                    PuppyNome = r.Puppy.Nome,
                    DataInizioRicovero = r.DataInizioRicovero,
                    Descrizione = r.Descrizione,
                    DataFineRicovero = r.DataFineRicovero
                })
                .ToListAsync();

            return ricoveriAttivi;
        }

        // GET: api/Ricovero/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RicoveroDetailDto>> GetRicovero(int id)
        {
            var ricovero = await _context.Ricoveri
                .Include(r => r.Puppy)
                .FirstOrDefaultAsync(r => r.RicoveroId == id);

            if (ricovero == null)
            {
                return NotFound();
            }

            var ricoveroDto = new RicoveroDetailDto
            {
                RicoveroId = ricovero.RicoveroId,
                PuppyId = ricovero.PuppyId,
                PuppyNome = ricovero.Puppy.Nome,
                DataInizioRicovero = ricovero.DataInizioRicovero,
                Descrizione = ricovero.Descrizione,
                DataFineRicovero = ricovero.DataFineRicovero
            };

            return ricoveroDto;
        }

        // POST: api/Ricovero
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RicoveroDetailDto>> PostRicovero([FromBody] CreateRicoveroDto createRicoveroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var puppy = await _context.Puppies.FindAsync(createRicoveroDto.PuppyId);
            if (puppy == null)
            {
                return BadRequest("Puppy non trovato");
            }

            // controllo se esiste già un ricovero
            var ricoveroAttivo = await _context.Ricoveri
                .Where(r => r.PuppyId == createRicoveroDto.PuppyId && r.DataFineRicovero == null)
                .FirstOrDefaultAsync();

            if (ricoveroAttivo != null)
            {
                return BadRequest("Questo puppy ha già un ricovero attivo. Chiudi il ricovero esistente prima di crearne uno nuovo.");
            }

            var ricovero = new Ricovero
            {
                PuppyId = createRicoveroDto.PuppyId,
                DataInizioRicovero = createRicoveroDto.DataInizioRicovero,
                Descrizione = createRicoveroDto.Descrizione,
                DataFineRicovero = createRicoveroDto.DataFineRicovero
            };

            _context.Ricoveri.Add(ricovero);
            await _context.SaveChangesAsync();

            var ricoveroDetailDto = new RicoveroDetailDto
            {
                RicoveroId = ricovero.RicoveroId,
                PuppyId = ricovero.PuppyId,
                PuppyNome = puppy.Nome,
                DataInizioRicovero = ricovero.DataInizioRicovero,
                Descrizione = ricovero.Descrizione,
                DataFineRicovero = ricovero.DataFineRicovero
            };

            return CreatedAtAction(nameof(GetRicovero), new { id = ricovero.RicoveroId }, ricoveroDetailDto);
        }

        // PUT: api/Ricovero/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RicoveroDetailDto>> PutRicovero(int id, UpdateRicoveroDto updateRicoveroDto)
        {
            var ricovero = await _context.Ricoveri.FindAsync(id);
            if (ricovero == null)
            {
                return NotFound();
            }

            // controllo chiusura ricovero (aggiungendo una data di fine)
            if (ricovero.DataFineRicovero == null && updateRicoveroDto.DataFineRicovero.HasValue)
            {
                // controllo data fine successiva a data inizio
                if (updateRicoveroDto.DataFineRicovero.Value <= ricovero.DataInizioRicovero)
                {
                    return BadRequest("La data di fine ricovero deve essere successiva alla data di inizio.");
                }
            }
            // controllo riapertura ricovero (rimuovendo la data di fine)
            else if (ricovero.DataFineRicovero.HasValue && !updateRicoveroDto.DataFineRicovero.HasValue)
            {
                // controllo presenza latri ricoveri stesso puppy
                var altroRicoveroAttivo = await _context.Ricoveri
                    .Where(r => r.PuppyId == ricovero.PuppyId && r.RicoveroId != id && r.DataFineRicovero == null)
                    .AnyAsync();

                if (altroRicoveroAttivo)
                {
                    return BadRequest("Non è possibile riaprire questo ricovero perché esiste già un ricovero attivo per questo puppy.");
                }
            }

            ricovero.Descrizione = updateRicoveroDto.Descrizione;
            ricovero.DataFineRicovero = updateRicoveroDto.DataFineRicovero;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RicoveroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var updatedRicovero = await _context.Ricoveri
                .Include(r => r.Puppy)
                .FirstOrDefaultAsync(r => r.RicoveroId == id);

            var ricoveroDetailDto = new RicoveroDetailDto
            {
                RicoveroId = updatedRicovero.RicoveroId,
                PuppyId = updatedRicovero.PuppyId,
                PuppyNome = updatedRicovero.Puppy.Nome,
                DataInizioRicovero = updatedRicovero.DataInizioRicovero,
                Descrizione = updatedRicovero.Descrizione,
                DataFineRicovero = updatedRicovero.DataFineRicovero
            };

            return ricoveroDetailDto;
        }

        // DELETE: api/Ricovero/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteRicovero(int id)
        {
            var ricovero = await _context.Ricoveri.FindAsync(id);
            if (ricovero == null)
            {
                return NotFound();
            }

            _context.Ricoveri.Remove(ricovero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RicoveroExists(int id)
        {
            return _context.Ricoveri.Any(e => e.RicoveroId == id);
        }
    }
}
