using BuildWeek5_BE.DTOs.Farmacia.Vendita;
using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs.Farmacia;
using BuildWeek5_BE.DTOs.Puppy;
using BuildWeek5_BE.Models;
using BuildWeek5_BE.Models.Farmacia;
using BuildWeek5_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BuildWeek5_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaciaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VenditaService> _logger;
        private readonly ILogger<FornitoreService> _fornitoreLogger;
        private readonly VenditaService _venditaService;
        private readonly FornitoreService _fornitoreService;


        public FarmaciaController(
            ApplicationDbContext context,
            ILogger<VenditaService> logger,
            VenditaService venditaService,
            FornitoreService fornitoreService)
        {
            _context = context;
            _logger = logger;
            _venditaService = venditaService;
            _fornitoreService = fornitoreService;
        }

        // -----------------------------------------------   Inizio Controller Vendita   ---------------------------------------------------------------------------//

        // get tutte le vendite
        [HttpGet("vendite")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<VenditaDto>>> GetAllVendite()
        {
            try
            {
                var vendite = await _venditaService.GetAllVenditeAsync();
                return Ok(vendite);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero di tutte le vendite");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }
        //get vendita in base al numero di ricettaMedica
        [HttpGet("vendite/{numeroRicetta}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<VenditaDto>> GetVenditaByNumeroRicetta(string numeroRicetta)
        {
            try
            {
                var vendita = await _venditaService.GetVenditaByNumeroRicettaAsync(numeroRicetta);

                if (vendita == null)
                {
                    return NotFound($"Vendita con numero ricetta '{numeroRicetta}' non trovata");
                }

                return Ok(vendita);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero della vendita con numero ricetta '{numeroRicetta}'");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }


        // get vendita specifica per ID
        [HttpGet("vendite/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<VenditaDto>> GetVenditaById(int id)
        {
            try
            {
                var vendita = await _venditaService.GetVenditaByIdAsync(id);
                if (vendita == null)
                {
                    return NotFound($"Vendita con ID {id} non trovata");
                }
                return Ok(vendita);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero della vendita con ID {id}");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        // get per le vendite di un utente specifico
        [HttpGet("vendite/utente/{FiscalCode}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<VenditaDto>>> GetVenditeByFiscalCode(string FiscalCode)
        {
            try
            {
                var vendite = await _venditaService.GetVenditeByFiscalCodeAsync(FiscalCode);
                return Ok(vendite);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero delle vendite per l'utente con codice fiscale {FiscalCode}");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }


        // get per le vendite di un prodotto specifico
        [HttpGet("vendite/prodotto/{prodottoId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<VenditaDto>>> GetVenditeByProdottoId(int prodottoId)
        {
            try
            {
                var vendite = await _venditaService.GetVenditeByProdottoIdAsync(prodottoId);
                return Ok(vendite);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero delle vendite per il prodotto con ID {prodottoId}");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        // creare nuova vendita
        [HttpPost("vendite")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<VenditaDto>> CreateVendita(CreateVenditaDto createVenditaDto)
        {
            try
            {
                // ID utente corrente dal token JWT
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Utente non autenticato");
                }

                var vendita = await _venditaService.CreateVenditaAsync(createVenditaDto, userId);
                return CreatedAtAction(nameof(GetVenditaById), new { id = vendita.Id }, vendita);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione di una nuova vendita");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        // aggiornare vendita esistente
        [HttpPut("vendite/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<VenditaDto>> UpdateVendita(int id, UpdateVenditaDto updateVenditaDto)
        {
            try
            {
                var vendita = await _venditaService.UpdateVenditaAsync(id, updateVenditaDto);
                return Ok(vendita);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiornamento della vendita con ID {id}");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        // eliminare vendita
        [HttpDelete("vendite/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteVendita(int id)
        {
            try
            {
                var result = await _venditaService.DeleteVenditaAsync(id);
                if (!result)
                {
                    return NotFound($"Vendita con ID {id} non trovata");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione della vendita con ID {id}");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        // -----------------------------------------------   Fine Controller Vendita   ---------------------------------------------------------------------------//




        // -----------------------------------------------   Inizio Controller Fornitore   ---------------------------------------------------------------------------//

        // get tutti i fornitori
        [HttpGet("fornitori")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<FornitoreDto>>> GetAllFornitori()
        {
            try
            {
                var fornitori = await _fornitoreService.GetAllFornitoriAsync();
                return Ok(fornitori);
            }
            catch (Exception ex)
            {
                _fornitoreLogger.LogError(ex, "Errore durante il recupero di tutti i fornitori");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        // get per un fornitore specifico per ID
        [HttpGet("fornitori/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<FornitoreDto>> GetFornitoreById(int id)
        {
            try
            {
                var fornitore = await _fornitoreService.GetFornitoreByIdAsync(id);
                if (fornitore == null)
                {
                    return NotFound($"Fornitore con ID {id} non trovato");
                }
                return Ok(fornitore);
            }
            catch (Exception ex)
            {
                _fornitoreLogger.LogError(ex, $"Errore durante il recupero del fornitore con ID {id}");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        // get per i dettagli completi di un fornitore
        [HttpGet("fornitori/{id}/dettagli")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<FornitoreDetailDto>> GetFornitoreDetailById(int id)
        {
            try
            {
                var fornitoreDetail = await _fornitoreService.GetFornitoreDetailByIdAsync(id);
                if (fornitoreDetail == null)
                {
                    return NotFound($"Fornitore con ID {id} non trovato");
                }
                return Ok(fornitoreDetail);
            }
            catch (Exception ex)
            {
                _fornitoreLogger.LogError(ex, $"Errore durante il recupero dei dettagli del fornitore con ID {id}");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        // creazione di un nuovo fornitore
        [HttpPost("fornitori")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<FornitoreDto>> CreateFornitore(CreateFornitoreDto createFornitoreDto)
        {
            try
            {
                var fornitore = await _fornitoreService.CreateFornitoreAsync(createFornitoreDto);
                return CreatedAtAction(nameof(GetFornitoreById), new { id = fornitore.Id }, fornitore);
            }
            catch (Exception ex)
            {
                _fornitoreLogger.LogError(ex, "Errore durante la creazione di un nuovo fornitore");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        // aggiornare un fornitore esistente
        [HttpPut("fornitori/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<FornitoreDto>> UpdateFornitore(int id, UpdateFornitoreDto updateFornitoreDto)
        {
            try
            {
                var fornitore = await _fornitoreService.UpdateFornitoreAsync(id, updateFornitoreDto);
                return Ok(fornitore);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _fornitoreLogger.LogError(ex, $"Errore durante l'aggiornamento del fornitore con ID {id}");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        // eliminare un fornitore
        [HttpDelete("fornitori/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteFornitore(int id)
        {
            try
            {
                var result = await _fornitoreService.DeleteFornitoreAsync(id);
                if (!result)
                {
                    return NotFound($"Fornitore con ID {id} non trovato");
                }
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _fornitoreLogger.LogError(ex, $"Errore durante l'eliminazione del fornitore con ID {id}");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        // ricerca fornitori per nome
        [HttpGet("fornitori/cerca")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<FornitoreDto>>> SearchFornitori([FromQuery] string searchTerm)
        {
            try
            {
                var fornitori = await _fornitoreService.SearchFornitoriByNameAsync(searchTerm);
                return Ok(fornitori);
            }
            catch (Exception ex)
            {
                _fornitoreLogger.LogError(ex, $"Errore durante la ricerca di fornitori con termine '{searchTerm}'");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddFarmaco([FromBody] AddProdottoRequestDto prodotto)
        {
            var newProduct = await _farmaciaService.CreateProductAsync(prodotto);

            if(newProduct == null)
            {
                return BadRequest(new AddProdottoResponseDto()
                {
                    Message = "Failed to add a new product!"
                }
                );
            }

            var result = await _farmaciaService.AddProductAsync(newProduct);

            return result ? Ok(new AddProdottoResponseDto()
            {
                Message = "Product correctly added!",
            }) : BadRequest(new AddProdottoResponseDto()
            {
                Message = "Something went wrong!"
            });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProdotti()
        {
            try
            {
                List<Prodotto> products = await _farmaciaService.GetProdottiAsync();

                if (products == null)
                {
                    return BadRequest(new GetProdottoResponseDto()
                    {
                        Message = "Something went wrong",
                        Products = null
                    });
                }

                if (!products.Any())
                {
                    return NotFound(new GetProdottoResponseDto()
                    {
                        Message = "No products found!",
                        Products = null
                    });
                }

                var productsDto = await _farmaciaService.GetProdottiDtoAsync(products);

                return Ok(new GetProdottoResponseDto()
                {
                    Message = "Products get:",
                    Products = productsDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Something went wrong!");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetProdottoById(int id)
        {
            var result = await _farmaciaService.GetProdottoByIdAsync(id);

            return result != null ? Ok(new GetProdottoByIdResponseDto()
            {
                Message = "Product correctly found!",
                Product = result
            }) : BadRequest(new
            {
                message = "Something went wrong!"
            });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProdotto(int id)
        {
            var result = await _farmaciaService.DeleteProdottoAsync(id);

            return result ? Ok(new
            {
                message = "Puppy correctly removed!",
            }) : BadRequest(new
            {
                message = "Something went wrong!"
            });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProdotto(int id, [FromBody] UpdateProdottoRequestDto prodottoDto)
        {
            var result = await _farmaciaService.UpdateProdottoAsync(id, prodottoDto);

            return result ? Ok(new { Message = "Product correctly updated!" })
                          : BadRequest(new { Message = "Something went wrong!" });
        }

        [HttpGet("{Nome}")]
        [Authorize]
        public async Task<IActionResult> SearchProduct(string Nome)
        {
            try
            {
                var result = await _farmaciaService.SearchByNameAsync(Nome);
                if (result == null)
                {
                    return BadRequest("No products Found!");
                }

                return Ok(new SearchByNameResponseDto()
                {
                    Message = "prodotti trovati:",
                    Prodotti = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Something went wrong!");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
