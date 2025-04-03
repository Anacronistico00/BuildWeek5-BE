using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs.Animale;
using BuildWeek5_BE.DTOs.Visita;
using BuildWeek5_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_BE.Services
{
    public class VisitaService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VisitaService> _logger;

        public VisitaService(ApplicationDbContext context, ILogger<VisitaService> logger)
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

        public async Task<Visita> CreateVisitaAsync(AddVisitaRequestDto visita)
        {
            try
            {
                var newVisita = new Visita()
                {
                    DataVisita = visita.DataVisita,
                    ObiettivoEsame = visita.ObiettivoEsame,
                    DescrizioneCura = visita.DescrizioneCura,
                    PuppyId = visita.PuppyId,
                };
                return newVisita;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }


        public async Task<List<GetVisitaDto>?> GetAllVisiteAsync()
        {
            try
            {
                var visite = await _context.Visite
                    .Include(v => v.Animale)
                    .ToListAsync();

                List<GetVisitaDto> visiteList = visite.Select(v =>
                new GetVisitaDto()
                {
                    Id = v.Id,
                    DataVisita = v.DataVisita,
                    ObiettivoEsame = v.ObiettivoEsame,
                    DescrizioneCura = v.DescrizioneCura,
                    PuppyId = v.PuppyId,
                    Animale = new AnimaleDto()
                    {
                        Nome = v.Animale.Nome,
                        Tipologia = v.Animale.Tipologia,
                    }
                }).ToList();
                return visiteList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }


        public async Task<bool> addVisitaAsync(Visita visita)
        {
            try
            {
                _context.Visite.Add(visita);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateVisitaAsync(int id, UpdateVisitaRequestDto visitaDto)
        {
            try
            {
                var visita = await _context.Visite.FindAsync(id);
                if (visita == null)
                    return false;

                visita.DataVisita = visitaDto.DataVisita;
                visita.ObiettivoEsame = visitaDto.ObiettivoEsame;
                visita.DescrizioneCura = visitaDto.DescrizioneCura;

                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteVisitaAsync(int id)
        {
            try
            {
                var visita = await _context.Visite.FindAsync(id);
                if (visita == null)
                    return false;

                _context.Visite.Remove(visita);
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
