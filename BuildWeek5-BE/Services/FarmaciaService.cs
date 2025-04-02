using BuildWeek5_BE.Data;

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
    }
}
