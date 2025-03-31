using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs.Puppy;
using BuildWeek5_BE.Models;

namespace BuildWeek5_BE.Services
{
    public class PuppyService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PuppyService> _logger;

        public PuppyService(ApplicationDbContext context, ILogger<PuppyService> logger)
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

        public async Task<Puppy> CreatePuppyAsync(AddPuppyRequestDto puppy)
        {
            try
            {
                var newPuppy = new Puppy()
                {
                    DataRegistrazione = DateOnly.FromDateTime(DateTime.Now),
                    Nome = puppy.Nome,
                    Tipologia = puppy.Tipologia,
                    ColoreMantello = puppy.ColoreMantello,
                    DataNascita = puppy.DataNascita,
                    MicrochipPresente = puppy.MicrochipPresente,
                    NumeroMicrochip = puppy.NumeroMicrochip,
                    UserId = puppy.UserId
                };
                return newPuppy;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> addPuppyAsync(Puppy puppy)
        {
            try
            {
                _context.Puppies.Add(puppy);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }
    }
}
