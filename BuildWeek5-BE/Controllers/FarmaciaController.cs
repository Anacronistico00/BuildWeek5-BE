using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs.Farmacia;
using BuildWeek5_BE.DTOs.Farmacia.Vendita;
using BuildWeek5_BE.Services;
using BuildWeek5_BE.Services.Farmacia.Vendita;
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
        private readonly VenditaService _venditaService;

        public FarmaciaController(
            ApplicationDbContext context,
            ILogger<VenditaService> logger,
            VenditaService venditaService)
        {
            _context = context;
            _logger = logger;
            _venditaService = venditaService;
        }

        // Endpoint ottenere tutte le vendite
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

        // Endpoint ottenere vendita specifica per ID
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

        // Endpoint per ottenere le vendite di un utente specifico
        [HttpGet("vendite/utente/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<VenditaDto>>> GetVenditeByUserId(string userId)
        {
            try
            {
                var vendite = await _venditaService.GetVenditeByUserIdAsync(userId);
                return Ok(vendite);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero delle vendite per l'utente con ID {userId}");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta");
            }
        }

        // Endpoint per ottenere le vendite di un prodotto specifico
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

        // Endpoint creare nuova vendita
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

        // Endpoint aggiornare vendita esistente
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

        // Endpoint eliminare vendita
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
    }
}
