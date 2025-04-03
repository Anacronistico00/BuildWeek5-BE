﻿using BuildWeek5_BE.Data;
using BuildWeek5_BE.DTOs.Account;
using BuildWeek5_BE.DTOs.Puppy;
using BuildWeek5_BE.Models;
using BuildWeek5_BE.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_BE.Services
{
    public class AnimaleService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AnimaleService> _logger;

        public AnimaleService(ApplicationDbContext context, ILogger<AnimaleService> logger)
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

        public async Task<Animale> CreatePuppyAsync(AddAnimaleRequestDto puppy)
        {
            try
            {
                var newPuppy = new Animale()
                {
                    Nome = puppy.Nome,
                    Tipologia = puppy.Tipologia,
                    ColoreMantello = puppy.ColoreMantello,
                    DataNascita = puppy.DataNascita,
                    MicrochipPresente = puppy.MicrochipPresente,
                    NumeroMicrochip = puppy.NumeroMicrochip,
                    CustomerId = puppy.UserId
                };
                return newPuppy;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> AddPuppyAsync(Animale puppy)
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

        public async Task<List<Animale>> GetPuppiesAsync()
        {
            try
            {
                return await _context.Puppies.Include(u => u.Customer).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<GetAnimaleDto>?> GetPuppiesDtoAsync(List<Animale> animali)
        {
            try
            {
                List<GetAnimaleDto> AnimaliDto = animali.Select(a =>
                new GetAnimaleDto()
                {
                    PuppyId = a.PuppyId,
                    DataRegistrazione = a.DataRegistrazione,
                    Nome = a.Nome,
                    Tipologia = a.Tipologia,
                    ColoreMantello = a.ColoreMantello,
                    DataNascita = a.DataNascita,
                    MicrochipPresente = a.MicrochipPresente,
                    NumeroMicrochip = a.NumeroMicrochip,
                    UserId = a.CustomerId,
                    User = a.Customer != null ? new UserDto()
                    {
                        FirstName = a.Customer.Nome,
                        LastName = a.Customer.Cognome
                    } : null
                }).ToList();
                return AnimaliDto;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<GetAnimaleDto?> GetPuppyDtoByIdAsync(int id)
        {
            try
            {
                var animaleById = await _context.Puppies.Include(u => u.Customer).FirstOrDefaultAsync(p => p.PuppyId == id);

                if (animaleById != null)
                {
                    var AnimaliDto = new GetAnimaleDto()
                    {
                        PuppyId = animaleById.PuppyId,
                        DataRegistrazione = animaleById.DataRegistrazione,
                        Nome = animaleById.Nome,
                        Tipologia = animaleById.Tipologia,
                        ColoreMantello = animaleById.ColoreMantello,
                        DataNascita = animaleById.DataNascita,
                        MicrochipPresente = animaleById.MicrochipPresente,
                        NumeroMicrochip = animaleById.NumeroMicrochip,
                        UserId = animaleById.CustomerId,
                        User = animaleById.Customer != null ? new UserDto()
                        {
                            FirstName = animaleById.Customer.Nome,
                            LastName = animaleById.Customer.Cognome
                        } : null
                    };
                return AnimaliDto;
                }

            return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> DeletePuppyAsync(int id)
        {
            try
            {
                var existingPuppy = await _context.Puppies.FirstOrDefaultAsync(p => p.PuppyId == id);

                if (existingPuppy == null)
                {
                    return false;
                }

                _context.Puppies.Remove(existingPuppy);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdatePuppyAsync(int id, UpdateAnimaleRequestDto puppyDto)
        {
            try
            {
                var existingPuppy = await _context.Puppies.FirstOrDefaultAsync(p => p.PuppyId == id);

                if (existingPuppy == null)
                {
                    return false;
                }

                existingPuppy.Nome = puppyDto.Nome;
                existingPuppy.Tipologia = puppyDto.Tipologia;
                existingPuppy.ColoreMantello = puppyDto.ColoreMantello;
                existingPuppy.DataNascita = puppyDto.DataNascita;
                existingPuppy.MicrochipPresente = puppyDto.MicrochipPresente;
                existingPuppy.NumeroMicrochip = puppyDto.NumeroMicrochip;
                existingPuppy.CustomerId = puppyDto.UserId;


                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<GetAnimaleDto> SearchByChipAsync(string chipId)
        {
            try
            {
                var animaleByChip = await _context.Puppies.Include(u => u.Customer).FirstOrDefaultAsync(p => p.NumeroMicrochip == chipId);

                if (animaleByChip != null)
                {
                    var AnimaleDto = new GetAnimaleDto()
                    {
                        PuppyId = animaleByChip.PuppyId,
                        DataRegistrazione = animaleByChip.DataRegistrazione,
                        Nome = animaleByChip.Nome,
                        Tipologia = animaleByChip.Tipologia,
                        ColoreMantello = animaleByChip.ColoreMantello,
                        DataNascita = animaleByChip.DataNascita,
                        MicrochipPresente = animaleByChip.MicrochipPresente,
                        NumeroMicrochip = animaleByChip.NumeroMicrochip,
                        UserId = animaleByChip.CustomerId,
                        User = new UserDto()
                        {
                            FirstName = animaleByChip.Customer.Nome,
                            LastName = animaleByChip.Customer.Cognome
                        }
                    };
                    return AnimaleDto;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}
