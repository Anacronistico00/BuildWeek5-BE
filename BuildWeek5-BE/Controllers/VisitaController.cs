using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs.Visita;
using BuildWeek5_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek5_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitaController : ControllerBase
    {
        private readonly VisitaService _visitaService;
        private readonly ILogger<VisitaController> _logger;
        private readonly ApplicationDbContext _context;

        public VisitaController(VisitaService visitaService, ILogger<VisitaController> logger, ApplicationDbContext context)
        {
            _visitaService = visitaService;
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        
        public async Task<IActionResult> Create([FromBody] AddVisitaRequestDto visita)
        {
            try
            {
              
                var newVisita = await _visitaService.CreateVisitaAsync(visita);
                if (newVisita == null)
                    return StatusCode(500, "Errore durante la creazione della visita");

                var success = await _visitaService.addVisitaAsync(newVisita);
                if (!success)
                    return StatusCode(500, "Errore durante il salvataggio della visita");

                return Ok(newVisita);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione della visita");
                return StatusCode(500, "Si è verificato un errore interno");
            }
        }

        [HttpGet]
  
    
        public async Task<IActionResult> GetAllVisite()
        {
            try
            {
                var visite = await _visitaService.GetAllVisiteAsync();
                return Ok(visite);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero delle visite");
                return StatusCode(500, "Si è verificato un errore interno");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisita(int id, [FromBody] AddVisitaRequestDto visitaDto)
        {
            try
            {
                var updatedVisita = await _visitaService.UpdateVisitaAsync(id, visitaDto);
                if (updatedVisita == null)
                    return NotFound("Visita non trovata");

                return Ok(updatedVisita);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante l'aggiornamento della visita");
                return StatusCode(500, "Si è verificato un errore interno");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisita(int id)
        {
            try
            {
                var success = await _visitaService.DeleteVisitaAsync(id);
                if (!success)
                    return NotFound("Visita non trovata o errore durante l'eliminazione");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante l'eliminazione della visita");
                return StatusCode(500, "Si è verificato un errore interno");
            }
        }
    }
}
