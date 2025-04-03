using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs.Clienti;
using BuildWeek5_BE.DTOs.Puppy;
using BuildWeek5_BE.Models;
using BuildWeek5_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek5_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ClienteService> _logger;
        private readonly ClienteService _clienteService;

        public ClienteController(ApplicationDbContext context, ILogger<ClienteService> logger, ClienteService clienteService)
        {
            _context = context;
            _logger = logger;
            _clienteService = clienteService;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetClienti()
        {
            try
            {
                var clientiDto = await _clienteService.GetClientiDtoAsync();
                if (clientiDto == null)
                {
                    return BadRequest(new { message = "Si è verificato un errore durante il recupero dei clienti" });
                }

                if (!clientiDto.Any())
                {
                    return NotFound(new { message = "Nessun cliente trovato" });
                }

                return Ok(new { message = "Clienti recuperati con successo", clienti = clientiDto });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero dei clienti");
                return StatusCode(500, new { message = "Si è verificato un errore interno del server" });
            }
        }

        // GET: api/Clienti/id
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCliente(int id)
        {
            try
            {
                var clienteDto = await _clienteService.GetClienteByIdAsync(id);
                if (clienteDto == null)
                {
                    return NotFound(new { message = $"Cliente con ID {id} non trovato" });
                }

                return Ok(new { message = "Cliente recuperato con successo", cliente = clienteDto });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero del cliente con ID {id}");
                return StatusCode(500, new { message = "Si è verificato un errore interno del server" });
            }
        }

        // POST: api/Clienti
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostCliente([FromBody] ClienteDto clienteDto)
        {
            try
            {
                var cliente = await _clienteService.CreateClienteAsync(clienteDto);
                if (cliente == null)
                {
                    return BadRequest(new { message = "Si è verificato un errore durante la creazione del cliente" });
                }

                var result = await _clienteService.AddClienteAsync(cliente);
                if (!result)
                {
                    return BadRequest(new { message = "Si è verificato un errore durante il salvataggio del cliente" });
                }

                clienteDto.Id = cliente.Id;
                return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, new { message = "Cliente creato con successo", cliente = clienteDto });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione del cliente");
                return StatusCode(500, new { message = "Si è verificato un errore interno del server" });
            }
        }

        // PUT: api/Clienti/
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCliente(int id, [FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (id != clienteDto.Id)
                {
                    return BadRequest(new { message = "L'ID nella richiesta non corrisponde all'ID del cliente" });
                }

                var result = await _clienteService.UpdateClienteAsync(id, clienteDto);
                if (!result)
                {
                    return NotFound(new { message = $"Cliente con ID {id} non trovato o aggiornamento fallito" });
                }

                return Ok(new { message = "Cliente aggiornato con successo" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiornamento del cliente con ID {id}");
                return StatusCode(500, new { message = "Si è verificato un errore interno del server" });
            }
        }

        // DELETE: api/Clienti/
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                var result = await _clienteService.DeleteClienteAsync(id);
                if (!result)
                {
                    return NotFound(new { message = $"Cliente con ID {id} non trovato o eliminazione fallita. Potrebbe avere animali associati." });
                }

                return Ok(new { message = "Cliente eliminato con successo" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione del cliente con ID {id}");
                return StatusCode(500, new { message = "Si è verificato un errore interno del server" });
            }
        }
    }
}
