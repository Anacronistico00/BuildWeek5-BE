using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs.Farmacia;
using BuildWeek5_BE.DTOs.Farmacia.Vendita;
using BuildWeek5_BE.Models.Farmacia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildWeek5_BE.Services.Farmacia.Vendita
{
    public class VenditaService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VenditaService> _logger;

        public VenditaService(ApplicationDbContext context, ILogger<VenditaService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<VenditaDto>> GetAllVenditeAsync()
        {
            try
            {
                return await _context.Vendite
                    .Include(v => v.User)
                    .Include(v => v.Prodotto)
                    .Select(v => new VenditaDto
                    {
                        Id = v.Id,
                        UserId = v.UserId,
                        UserName = $"{v.User.FirstName} {v.User.LastName}",
                        ProdottoId = v.ProdottoId,
                        NomeProdotto = v.Prodotto.Nome,
                        PrezzoProdotto = 0, //prezzo non disponibile
                        NumeroRicettaMedica = v.NumeroRicettaMedica,
                        DataVendita = v.DataVendita

                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero di tutte le vendite");
                throw;
            }
        }

        public async Task<VenditaDto> GetVenditaByIdAsync(int id)
        {
            try
            {
                var vendita = await _context.Vendite
                    .Include(v => v.User)
                    .Include(v => v.Prodotto)
                    .FirstOrDefaultAsync(v => v.Id == id);

                if (vendita == null)
                {
                    return null;
                }

                return new VenditaDto
                {
                    Id = vendita.Id,
                    UserId = vendita.UserId,
                    UserName = $"{vendita.User.FirstName} {vendita.User.LastName}",
                    ProdottoId = vendita.ProdottoId,
                    NomeProdotto = vendita.Prodotto.Nome,
                    PrezzoProdotto = 0, //prezzo non disponibile
                    NumeroRicettaMedica = vendita.NumeroRicettaMedica,
                    DataVendita = vendita.DataVendita

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero della vendita con ID {id}");
                throw;
            }
        }

        public async Task<List<VenditaDto>> GetVenditeByUserIdAsync(string userId)
        {
            try
            {
                return await _context.Vendite
                    .Include(v => v.User)
                    .Include(v => v.Prodotto)
                    .Where(v => v.UserId == userId)
                    .Select(v => new VenditaDto
                    {
                        Id = v.Id,
                        UserId = v.UserId,
                        UserName = $"{v.User.FirstName} {v.User.LastName}",
                        ProdottoId = v.ProdottoId,
                        NomeProdotto = v.Prodotto.Nome,
                        PrezzoProdotto = 0, //prezzo non disponibile
                        NumeroRicettaMedica = v.NumeroRicettaMedica,
                        DataVendita = v.DataVendita

                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero delle vendite per l'utente con ID {userId}");
                throw;
            }
        }

        public async Task<List<VenditaDto>> GetVenditeByProdottoIdAsync(int prodottoId)
        {
            try
            {
                return await _context.Vendite
                    .Include(v => v.User)
                    .Include(v => v.Prodotto)
                    .Where(v => v.ProdottoId == prodottoId)
                    .Select(v => new VenditaDto
                    {
                        Id = v.Id,
                        UserId = v.UserId,
                        UserName = $"{v.User.FirstName} {v.User.LastName}",
                        ProdottoId = v.ProdottoId,
                        NomeProdotto = v.Prodotto.Nome,
                        PrezzoProdotto = 0, //prezzo non disponibile
                        NumeroRicettaMedica = v.NumeroRicettaMedica,
                        DataVendita = v.DataVendita
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero delle vendite per il prodotto con ID {prodottoId}");
                throw;
            }
        }

        public async Task<VenditaDto> CreateVenditaAsync(CreateVenditaDto createVenditaDto, string userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Verifica che il prodotto esista
                var prodotto = await _context.Prodotti.FindAsync(createVenditaDto.ProdottoId);
                if (prodotto == null)
                {
                    throw new KeyNotFoundException($"Prodotto con ID {createVenditaDto.ProdottoId} non trovato");
                }

                // Verifica che l'utente esista
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    throw new KeyNotFoundException($"Utente con ID {userId} non trovato");
                }

                // Crea la nuova vendita
                var vendita = new Models.Farmacia.Vendita
                {
                    ProdottoId = createVenditaDto.ProdottoId,
                    UserId = userId,
                    NumeroRicettaMedica = createVenditaDto.NumeroRicettaMedica,
                    DataVendita = DateTime.Now
                };

                _context.Vendite.Add(vendita);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                await _context.Entry(vendita).Reference(v => v.User).LoadAsync();
                await _context.Entry(vendita).Reference(v => v.Prodotto).LoadAsync();

                return new VenditaDto
                {
                    Id = vendita.Id,
                    UserId = vendita.UserId,
                    UserName = $"{vendita.User.FirstName} {vendita.User.LastName}",
                    ProdottoId = vendita.ProdottoId,
                    NomeProdotto = vendita.Prodotto.Nome,
                    PrezzoProdotto = 0, // prezzo non disponibile
                    NumeroRicettaMedica = vendita.NumeroRicettaMedica,
                    DataVendita = vendita.DataVendita
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Errore durante la creazione di una nuova vendita");
                throw;
            }
        }

        public async Task<VenditaDto> UpdateVenditaAsync(int id, UpdateVenditaDto updateVenditaDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var vendita = await _context.Vendite
                    .Include(v => v.User)
                    .Include(v => v.Prodotto)
                    .FirstOrDefaultAsync(v => v.Id == id);

                if (vendita == null)
                {
                    throw new KeyNotFoundException($"Vendita con ID {id} non trovata");
                }

                // Aggiorna solo numero della ricetta medica
                vendita.NumeroRicettaMedica = updateVenditaDto.NumeroRicettaMedica;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new VenditaDto
                {
                    Id = vendita.Id,
                    UserId = vendita.UserId,
                    UserName = $"{vendita.User.FirstName} {vendita.User.LastName}",
                    ProdottoId = vendita.ProdottoId,
                    NomeProdotto = vendita.Prodotto.Nome,
                    PrezzoProdotto = 0, //prezzo non disponibile
                    NumeroRicettaMedica = vendita.NumeroRicettaMedica,
                    DataVendita = vendita.DataVendita
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, $"Errore durante l'aggiornamento della vendita con ID {id}");
                throw;
            }
        }

        public async Task<bool> DeleteVenditaAsync(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var vendita = await _context.Vendite.FindAsync(id);
                if (vendita == null)
                {
                    return false;
                }

                _context.Vendite.Remove(vendita);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, $"Errore durante l'eliminazione della vendita con ID {id}");
                throw;
            }
        }
    }
}
