using Azure.Core;
using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs.Account;
using BuildWeek5_BE.DTOs.Animale;
using BuildWeek5_BE.DTOs.Clienti;
using BuildWeek5_BE.DTOs.Puppy;
using BuildWeek5_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_BE.Services
{
    public class ClienteService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ClienteService> _logger;

        public ClienteService(ApplicationDbContext context, ILogger<ClienteService> logger)
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

        public async Task<Cliente> CreateCustomerAsync(AddClienteRequestDto cliente)
        {
            try
            {
                var newCliente = new Cliente()
                {
                    Nome = cliente.Nome,
                    Cognome = cliente.Cognome,
                    CodiceFiscale = cliente.CodiceFiscale,
                    DataDiNascita = cliente.DataDiNascita,
                    Indirizzo = cliente.Indirizzo
                };
                return newCliente;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> AddCustomerAsync(Cliente cliente)
        {
            try
            {
                _context.Clienti.Add(cliente);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<List<Cliente>> GetCustomersAsync()
        {
            try
            {
                return await _context.Clienti.Include(u => u.Animali).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<GetClientiDto>?> GetCustomersDtoAsync(List<Cliente> clienti)
        {
            try
            {
                List<GetClientiDto> AnimaliDto = clienti.Select(c =>
                new GetClientiDto()
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Cognome = c.Cognome,
                    CodiceFiscale = c.CodiceFiscale,
                    DataDiNascita = c.DataDiNascita,
                    Indirizzo = c.Indirizzo,
                    Animali = c.Animali?.Select(animale => new AnimaleDto
                    {
                        Nome = animale.Nome,
                        Tipologia = animale.Tipologia
                    }).ToList()
                }).ToList();
                return AnimaliDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}
