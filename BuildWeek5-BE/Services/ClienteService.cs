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

        public async Task<List<Cliente>> GetClientiAsync()
        {
            try
            {
                return await _context.Clienti.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<ClienteDto>> GetClientiDtoAsync()
        {
            try
            {
                var clienti = await _context.Clienti.ToListAsync();
                return clienti.Select(c => new ClienteDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Cognome = c.Cognome,
                    CodiceFiscale = c.CodiceFiscale,
                    DataDiNascita = c.DataDiNascita,
                    Indirizzo = c.Indirizzo
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<ClienteDto> GetClienteByIdAsync(int id)
        {
            try
            {
                var cliente = await _context.Clienti.FindAsync(id);
                if (cliente == null)
                    return null;

                return new ClienteDto
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Cognome = cliente.Cognome,
                    CodiceFiscale = cliente.CodiceFiscale,
                    DataDiNascita = cliente.DataDiNascita,
                    Indirizzo = cliente.Indirizzo
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<Cliente> CreateClienteAsync(ClienteDto clienteDto)
        {
            try
            {
                var cliente = new Cliente
                {
                    Nome = clienteDto.Nome,
                    Cognome = clienteDto.Cognome,
                    CodiceFiscale = clienteDto.CodiceFiscale,
                    DataDiNascita = clienteDto.DataDiNascita,
                    Indirizzo = clienteDto.Indirizzo
                };

                return cliente;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> AddClienteAsync(Cliente cliente)
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

        public async Task<bool> UpdateClienteAsync(int id, ClienteDto clienteDto)
        {
            try
            {
                var cliente = await _context.Clienti.FindAsync(id);
                if (cliente == null)
                    return false;

                cliente.Nome = clienteDto.Nome;
                cliente.Cognome = clienteDto.Cognome;
                cliente.CodiceFiscale = clienteDto.CodiceFiscale;
                cliente.DataDiNascita = clienteDto.DataDiNascita;
                cliente.Indirizzo = clienteDto.Indirizzo;

                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            try
            {
                var cliente = await _context.Clienti.FindAsync(id);
                if (cliente == null)
                    return false;

                // Verifica se il cliente ha animali associati
                var hasAnimals = await _context.Puppies.AnyAsync(a => a.ClienteId == id);
                if (hasAnimals)
                    return false;

                _context.Clienti.Remove(cliente);
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
