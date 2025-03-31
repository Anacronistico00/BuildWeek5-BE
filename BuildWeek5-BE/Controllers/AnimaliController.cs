using BuildWeek5_BE.Data;
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
    public class AnimaliController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AnimaleService> _logger;
        private readonly AnimaleService _animaleService;

        public AnimaliController(ApplicationDbContext context, ILogger<AnimaleService> logger, AnimaleService animaleService)
        {
            _context = context;
            _logger = logger;
            _animaleService = animaleService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPuppy ([FromBody] AddAnimaleRequestDto puppy)
        {
            var newPuppy = await _animaleService.CreatePuppyAsync(puppy);

            if (newPuppy == null)
            {
                return BadRequest(new
                {
                    message = "Failed to add a new Puppy!!!"
                }
                );
            }

            var result = await _animaleService.AddPuppyAsync(newPuppy);


            return result ? Ok(new AddAnimaleResponseDto()
            {
                Message = "Puppy correctly added!",
            }) : BadRequest(new AddAnimaleResponseDto()
            {
                Message = "Something went wrong!"
            });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPuppies()
        {
            try
            {

                List<Animale> puppies = await _animaleService.GetPuppiesAsync();

                if (puppies == null)
                {
                    return BadRequest(new GetAnimaleResponseDto()
                    {
                        Message = "Something went wrong",
                        Puppies = null
                    });
                }

                if (!puppies.Any())
                {
                    return NotFound(new GetAnimaleResponseDto()
                    {
                        Message = "No puppies found!",
                        Puppies = null
                    });
                }

                var puppiesDto = await _animaleService.GetPuppiesDtoAsync(puppies);

                return Ok(new GetAnimaleResponseDto()
                {
                    Message = "Puppies correctly get",
                    Puppies = puppiesDto
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
        public async Task<IActionResult> GetPuppyById(int id)
        {
            var result = await _animaleService.GetPuppyDtoByIdAsync(id);

            return result != null ? Ok(new GetAnimaleByIdResponseDto()
            {
                Message = "Puppy correctly found!",
                Puppy = result
            }) : BadRequest(new
            {
                message = "Something went wrong!"
            });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePuppy(int id)
        {
            var result = await _animaleService.DeletePuppyAsync(id);

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
        public async Task<IActionResult> UpdatePuppy(int id, [FromBody] UpdateAnimaleRequestDto puppyDto)
        {
            var result = await _animaleService.UpdatePuppyAsync(id, puppyDto);

            return result ? Ok(new { Message = "Puppy correctly updated!" })
                          : BadRequest(new { Message = "Something went wrong!" });
        }
    }
}
