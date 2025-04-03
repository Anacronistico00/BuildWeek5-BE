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


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPuppy([FromBody] AddClienteRequestDto cliente)
        {
            var newCustomer = await _clienteService.CreateCustomerAsync(cliente);

            if (newCustomer == null)
            {
                return BadRequest(new
                {
                    message = "Failed to add a new Puppy!!!"
                }
                );
            }

            var result = await _clienteService.AddCustomerAsync(newCustomer);


            return result ? Ok(new AddClienteResponseDto()
            {
                Message = "Customer correctly added!",
            }) : BadRequest(new AddClienteResponseDto()
            {
                Message = "Something went wrong!"
            });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCustomers()
        {
            {
                try
                {

                    List<Cliente> clienti = await _clienteService.GetCustomersAsync();

                    if (clienti == null)
                    {
                        return BadRequest(new GetClientiResponseDto()
                        {
                            Message = "Something went wrong",
                            Customer = null
                        });
                    }

                    if (!clienti.Any())
                    {
                        return NotFound(new GetClientiResponseDto()
                        {
                            Message = "No customers found!",
                            Customer = null
                        });
                    }

                    var clientiDto = await _clienteService.GetCustomersDtoAsync(clienti);

                    return Ok(new GetClientiResponseDto()
                    {
                        Message = "Customers correctly get",
                        Customer = clientiDto
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
}
