using BuildWeek5_BE.DTOs.Farmacia;
using BuildWeek5_BE.DTOs.Farmacia.Vendita;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildWeek5_BE.Services.Farmacia.Vendita
{
    public interface IVenditaService
    {
        Task<List<VenditaDto>> GetAllVenditeAsync();
        Task<VenditaDto> GetVenditaByIdAsync(int id);
        Task<List<VenditaDto>> GetVenditeByUserIdAsync(string userId);
        Task<List<VenditaDto>> GetVenditeByProdottoIdAsync(int prodottoId);
        Task<VenditaDto> CreateVenditaAsync(CreateVenditaDto createVenditaDto, string userId);
        Task<VenditaDto> UpdateVenditaAsync(int id, UpdateVenditaDto updateVenditaDto);
        Task<bool> DeleteVenditaAsync(int id);
    }
}
