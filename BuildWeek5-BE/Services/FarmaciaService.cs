using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs.Farmacia;
using BuildWeek5_BE.DTOs.Farmacia.Fornitore;
using BuildWeek5_BE.DTOs.Puppy;
using BuildWeek5_BE.Models.Farmacia;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_BE.Services
{
    public class FarmaciaService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FarmaciaService> _logger;

        public FarmaciaService(ApplicationDbContext context, ILogger<FarmaciaService> logger)
        {
            _context = context;
            _logger = logger;
        }

        private async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<Prodotto> CreateProductAsync(AddProdottoRequestDto prodotto)
        {
            try
            {
                var newProduct = new Prodotto()
                {
                    Nome = prodotto.Nome,
                    FornitoreId = prodotto.FornitoreId,
                    UsiProdotto = prodotto.UsiProdotto,
                    CassettoId = prodotto.CassettoId,
                    ArmadiettoId = prodotto.ArmadiettoId
                };
                return newProduct;
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> AddProductAsync(Prodotto prodotto)
        {
            try
            {
                _context.Prodotti.Add(prodotto);
                return await SaveAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<List<Prodotto>?> GetProdottiAsync()
        {
            try
            {
                return await _context.Prodotti.Include(f => f.Fornitore).Include(c => c.Cassetto).Include(a => a.Armadietto).ToListAsync();
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<GetProdottoDto>?> GetProdottiDtoAsync(List<Prodotto> prodotti)
        {
            try
            {
                List<GetProdottoDto> prodottoDto = prodotti.Select(p => 
                new GetProdottoDto 
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    UsiProdotto = p.UsiProdotto,
                    Fornitore = p.Fornitore != null ? new FornitoreDto
                    {
                        Id = p.Fornitore.Id,
                        Nome = p.Fornitore.Nome,
                        Recapito = p.Fornitore.Recapito,
                        Indirizzo = p.Fornitore.Indirizzo
                    } : null,
                    Cassetto = p.Cassetto != null ? new CassettoDto
                    {
                        CassettoId = p.Cassetto.CassettoId,
                        ArmadiettoId = p.Armadietto.ArmadiettoId
                    } : null
                }).ToList();
                return prodottoDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<GetProdottoByIdDto?> GetProdottoByIdAsync(int id)
        {
            try
            {
                var prodottoById = await _context.Prodotti.Include(f => f.Fornitore).Include(c => c.Cassetto).Include(a => a.Armadietto).Include(v => v.UtenteProdotto).FirstOrDefaultAsync(p => p.Id == id);

                if (prodottoById != null)
                {
                    var prodottoDto = new GetProdottoByIdDto()
                    {
                        Id = prodottoById.Id,
                        Nome = prodottoById.Nome,
                        UsiProdotto = prodottoById.UsiProdotto,
                        Fornitore = prodottoById.Fornitore != null ? new FornitoreDto
                        {
                            Id = prodottoById.Fornitore.Id,
                            Nome = prodottoById.Fornitore.Nome,
                            Recapito = prodottoById.Fornitore.Recapito,
                            Indirizzo = prodottoById.Fornitore.Indirizzo
                        } : null,
                        Cassetto = prodottoById.Cassetto != null ? new CassettoDto
                        {
                            CassettoId = prodottoById.Cassetto.CassettoId,
                            ArmadiettoId = prodottoById.Armadietto.ArmadiettoId
                        } : null,
                        vendite = prodottoById.UtenteProdotto != null
                        ? prodottoById.UtenteProdotto.Select(v => new UtenteProdottoDto()
                        {
                            CodiceFiscale = v.Cliente.CodiceFiscale,
                            DataAcquisto = v.DataAcquisto,
                            NumeroRicettaMedica = v.NumeroRicettaMedica
                        }).ToList() : null,
                    };
                return prodottoDto;
                }
            return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<GetProdottoDto>?> SearchByNameAsync(string name)
        {
            try
            {
                var prodottiByName = await _context.Prodotti.Include(f => f.Fornitore).Include(c => c.Cassetto).Include(a => a.Armadietto).Include(v => v.UtenteProdotto).Where(p => p.Nome.ToLower().Contains(name.ToLower())).ToListAsync();

                if (prodottiByName != null)
                {
                    var prodottoDto = prodottiByName.Select(p =>
                 new GetProdottoDto()
                 {
                     Id = p.Id,
                     Nome = p.Nome,
                     UsiProdotto = p.UsiProdotto,
                     Fornitore = p.Fornitore != null ? new FornitoreDto
                     {
                         Id = p.Fornitore.Id,
                         Nome = p.Fornitore.Nome,
                         Recapito = p.Fornitore.Recapito,
                         Indirizzo = p.Fornitore.Indirizzo
                     } : null,
                     Cassetto = p.Cassetto != null ? new CassettoDto
                     {
                         CassettoId = p.Cassetto.CassettoId,
                         ArmadiettoId = p.Armadietto.ArmadiettoId
                     } : null
                 }).ToList();
                return prodottoDto;
                }
            return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
        public async Task<bool> DeleteProdottoAsync(int id)
        {
            try
            {
                var existingProduct = await _context.Prodotti.FirstOrDefaultAsync(p => p.Id == id);

                if (existingProduct == null)
                {
                    return false;
                }

                _context.Prodotti.Remove(existingProduct);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateProdottoAsync(int id, UpdateProdottoRequestDto prodottoDto)
        {
            try
            {
                var existingProduct = await _context.Prodotti.FirstOrDefaultAsync(p => p.Id == id);

                if (existingProduct == null)
                {
                    return false;
                }

                existingProduct.Nome = prodottoDto.Nome;
                existingProduct.FornitoreId = prodottoDto.FornitoreId;
                existingProduct.UsiProdotto = prodottoDto.UsiProdotto;
                existingProduct.CassettoId = prodottoDto.CassettoId;
                existingProduct.ArmadiettoId = prodottoDto.ArmadiettoId;

                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }
    }
}
