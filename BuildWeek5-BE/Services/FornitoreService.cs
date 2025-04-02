using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs.Farmacia.Fornitore;
using BuildWeek5_BE.Models.Farmacia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildWeek5_BE.Services.Farmacia
{
    public class FornitoreService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FornitoreService> _logger;

        public FornitoreService(ApplicationDbContext context, ILogger<FornitoreService> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Ottieni tutti i fornitori
        public async Task<List<FornitoreDto>> GetAllFornitoriAsync()
        {
            try
            {
                return await _context.Fornitori
                    .Select(f => new FornitoreDto
                    {
                        Id = f.Id,
                        Nome = f.Nome,
                        Recapito = f.Recapito,
                        Indirizzo = f.Indirizzo
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero di tutti i fornitori");
                throw;
            }
        }

        // Ottieni un fornitore per ID
        public async Task<FornitoreDto> GetFornitoreByIdAsync(int id)
        {
            try
            {
                var fornitore = await _context.Fornitori
                    .FirstOrDefaultAsync(f => f.Id == id);

                if (fornitore == null)
                {
                    return null;
                }

                return new FornitoreDto
                {
                    Id = fornitore.Id,
                    Nome = fornitore.Nome,
                    Recapito = fornitore.Recapito,
                    Indirizzo = fornitore.Indirizzo
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero del fornitore con ID {id}");
                throw;
            }
        }

        // Ottieni dettagli completi di un fornitore (con i suoi prodotti sarebbe da implementare)
        public async Task<FornitoreDetailDto> GetFornitoreDetailByIdAsync(int id)
        {
            try
            {
                var fornitore = await _context.Fornitori
                    .Include(f => f.Prodotti)
                    .FirstOrDefaultAsync(f => f.Id == id);

                if (fornitore == null)
                {
                    return null;
                }

                return new FornitoreDetailDto
                {
                    Id = fornitore.Id,
                    Nome = fornitore.Nome,
                    Recapito = fornitore.Recapito,
                    Indirizzo = fornitore.Indirizzo,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero dei dettagli del fornitore con ID {id}");
                throw;
            }
        }

        // Crea un nuovo fornitore
        public async Task<FornitoreDto> CreateFornitoreAsync(CreateFornitoreDto createFornitoreDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var fornitore = new Fornitore
                {
                    Nome = createFornitoreDto.Nome,
                    Recapito = createFornitoreDto.Recapito,
                    Indirizzo = createFornitoreDto.Indirizzo
                };

                _context.Fornitori.Add(fornitore);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new FornitoreDto
                {
                    Id = fornitore.Id,
                    Nome = fornitore.Nome,
                    Recapito = fornitore.Recapito,
                    Indirizzo = fornitore.Indirizzo
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Errore durante la creazione di un nuovo fornitore");
                throw;
            }
        }

        // Aggiorna un fornitore esistente
        public async Task<FornitoreDto> UpdateFornitoreAsync(int id, UpdateFornitoreDto updateFornitoreDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var fornitore = await _context.Fornitori.FindAsync(id);
                if (fornitore == null)
                {
                    throw new KeyNotFoundException($"Fornitore con ID {id} non trovato");
                }

                if (!string.IsNullOrEmpty(updateFornitoreDto.Nome))
                {
                    fornitore.Nome = updateFornitoreDto.Nome;
                }

                if (!string.IsNullOrEmpty(updateFornitoreDto.Recapito))
                {
                    fornitore.Recapito = updateFornitoreDto.Recapito;
                }

                if (!string.IsNullOrEmpty(updateFornitoreDto.Indirizzo))
                {
                    fornitore.Indirizzo = updateFornitoreDto.Indirizzo;
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new FornitoreDto
                {
                    Id = fornitore.Id,
                    Nome = fornitore.Nome,
                    Recapito = fornitore.Recapito,
                    Indirizzo = fornitore.Indirizzo
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, $"Errore durante l'aggiornamento del fornitore con ID {id}");
                throw;
            }
        }

        // Elimina un fornitore
        public async Task<bool> DeleteFornitoreAsync(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var fornitore = await _context.Fornitori
                    .Include(f => f.Prodotti)
                    .FirstOrDefaultAsync(f => f.Id == id);

                if (fornitore == null)
                {
                    return false;
                }

                // First remove the associated products
                if (fornitore.Prodotti != null && fornitore.Prodotti.Any())
                {
                    _context.Prodotti.RemoveRange(fornitore.Prodotti);
                }

                // Then remove the fornitore
                _context.Fornitori.Remove(fornitore);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (InvalidOperationException)
            {
                await transaction.RollbackAsync();
                throw;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, $"Errore durante l'eliminazione del fornitore con ID {id}");
                throw;
            }
        }

        // Cerca fornitori per nome
        public async Task<List<FornitoreDto>> SearchFornitoriByNameAsync(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    return await GetAllFornitoriAsync();
                }

                return await _context.Fornitori
                    .Where(f => f.Nome.Contains(searchTerm))
                    .Select(f => new FornitoreDto
                    {
                        Id = f.Id,
                        Nome = f.Nome,
                        Recapito = f.Recapito,
                        Indirizzo = f.Indirizzo
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la ricerca di fornitori con termine '{searchTerm}'");
                throw;
            }
        }
    }
}
