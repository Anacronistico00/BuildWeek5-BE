using BuildWeek5_BE.DTOs.Farmacia.Vendita;
using BuildWeek5_BE.Data;
using BuildWeek5_BE.Services;
using BuildWeek5_BE.Services.Farmacia;
using BuildWeek5_BE.Services.Farmacia.Vendita;
using BuildWeek5_BE.DTOs.Farmacia.Fornitore;
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


        // -----------------------------------------------   Fine Controller Fornitore   ---------------------------------------------------------------------------//




    }
}
