using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs.Farmacia;
using BuildWeek5_BE.DTOs.Puppy;
using BuildWeek5_BE.Models;
using BuildWeek5_BE.Models.Farmacia;
using BuildWeek5_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek5_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaciaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FarmaciaService> _logger;
        private readonly FarmaciaService _farmaciaService;

        public FarmaciaController(ApplicationDbContext context, ILogger<FarmaciaService> logger, FarmaciaService farmaciaService)
        {
            _context = context;
            _logger = logger;
            _farmaciaService = farmaciaService;
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
