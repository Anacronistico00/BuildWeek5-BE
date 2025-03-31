using BuildWeek5_BE.DTOs.Ricovero;
using BuildWeek5_BE.Data;
using BuildWeek5_BE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildWeek5_BE.DTOs;

namespace BuildWeek5_BE.Services
{
    public class RicoveroService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RicoveroService> _logger;

        public RicoveroService(ApplicationDbContext context, ILogger<RicoveroService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<RicoveroDetailDto>> GetRicoveriAsync()
        {
            try
            {
                return await _context.Ricoveri
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero di tutti i ricoveri");
                throw;
            }
        }

        public async Task<List<RicoveroDetailDto>> GetRicoveriAttiviAsync()
        {
            try
            {
                return await _context.Ricoveri
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero dei ricoveri attivi");
                throw;
            }
        }

        public async Task<RicoveroDetailDto> GetRicoveroByIdAsync(int id)
        {
            try
            {
                var ricovero = await _context.Ricoveri
                    .Include(r => r.Puppy)
                    .FirstOrDefaultAsync(r => r.RicoveroId == id);

                if (ricovero == null)
                    return null;

                return new RicoveroDetailDto
                {
                    RicoveroId = ricovero.RicoveroId,
                    PuppyId = ricovero.PuppyId,
                    PuppyNome = ricovero.Puppy.Nome,
                    DataInizioRicovero = ricovero.DataInizioRicovero,
                    Descrizione = ricovero.Descrizione,
                    DataFineRicovero = ricovero.DataFineRicovero
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero del ricovero con ID {id}");
                throw;
            }
        }

        public async Task<RicoveroDetailDto> CreateRicoveroAsync(CreateRicoveroDto createRicoveroDto)
        {
            try
            {
                var puppy = await _context.Puppies.FindAsync(createRicoveroDto.PuppyId);
                if (puppy == null)
                    throw new ArgumentException("Puppy non trovato");

                var ricoveroAttivo = await _context.Ricoveri
                    .Where(r => r.PuppyId == createRicoveroDto.PuppyId && r.DataFineRicovero == null)
                    .FirstOrDefaultAsync();

                if (ricoveroAttivo != null)
                    throw new InvalidOperationException("Questo puppy ha già un ricovero attivo. Chiudi il ricovero esistente prima di crearne uno nuovo.");

                var ricovero = new Ricovero
                {
                    PuppyId = createRicoveroDto.PuppyId,
                    DataInizioRicovero = createRicoveroDto.DataInizioRicovero,
                    Descrizione = createRicoveroDto.Descrizione,
                    DataFineRicovero = createRicoveroDto.DataFineRicovero
                };

                _context.Ricoveri.Add(ricovero);
                await _context.SaveChangesAsync();

                return new RicoveroDetailDto
                {
                    RicoveroId = ricovero.RicoveroId,
                    PuppyId = ricovero.PuppyId,
                    PuppyNome = puppy.Nome,
                    DataInizioRicovero = ricovero.DataInizioRicovero,
                    Descrizione = ricovero.Descrizione,
                    DataFineRicovero = ricovero.DataFineRicovero
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione di un nuovo ricovero");
                throw;
            }
        }

        public async Task<RicoveroDetailDto> UpdateRicoveroAsync(int id, UpdateRicoveroDto updateRicoveroDto)
        {
            try
            {
                var ricovero = await _context.Ricoveri.FindAsync(id);
                if (ricovero == null)
                    return null;

                if (ricovero.DataFineRicovero == null && updateRicoveroDto.DataFineRicovero.HasValue)
                {
                    if (updateRicoveroDto.DataFineRicovero.Value <= ricovero.DataInizioRicovero)
                        throw new InvalidOperationException("La data di fine ricovero deve essere successiva alla data di inizio.");
                }
                else if (ricovero.DataFineRicovero.HasValue && !updateRicoveroDto.DataFineRicovero.HasValue)
                {
                    var altroRicoveroAttivo = await _context.Ricoveri
                        .Where(r => r.PuppyId == ricovero.PuppyId && r.RicoveroId != id && r.DataFineRicovero == null)
                        .AnyAsync();

                    if (altroRicoveroAttivo)
                        throw new InvalidOperationException("Non è possibile riaprire questo ricovero perché esiste già un ricovero attivo per questo puppy.");
                }

                ricovero.Descrizione = updateRicoveroDto.Descrizione;
                ricovero.DataFineRicovero = updateRicoveroDto.DataFineRicovero;

                await _context.SaveChangesAsync();

                var updatedRicovero = await _context.Ricoveri
                    .Include(r => r.Puppy)
                    .FirstOrDefaultAsync(r => r.RicoveroId == id);

                return new RicoveroDetailDto
                {
                    RicoveroId = updatedRicovero.RicoveroId,
                    PuppyId = updatedRicovero.PuppyId,
                    PuppyNome = updatedRicovero.Puppy.Nome,
                    DataInizioRicovero = updatedRicovero.DataInizioRicovero,
                    Descrizione = updatedRicovero.Descrizione,
                    DataFineRicovero = updatedRicovero.DataFineRicovero
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiornamento del ricovero con ID {id}");
                throw;
            }
        }

        public async Task<bool> DeleteRicoveroAsync(int id)
        {
            try
            {
                var ricovero = await _context.Ricoveri.FindAsync(id);
                if (ricovero == null)
                    return false;

                _context.Ricoveri.Remove(ricovero);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione del ricovero con ID {id}");
                throw;
            }
        }
    }
}