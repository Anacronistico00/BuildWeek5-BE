using BuildWeek5_BE.Data;
using BuildWeek5_BE.Services;
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
    }
}
