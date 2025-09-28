using TicketHub.Domain.Models;

namespace TicketHub.Application.Interfaces;

public interface IPartnerRepository
{
    Task<PartnerEntity> CreateAsync(PartnerEntity partner);
    Task<PartnerEntity?> GetByIdAsync(Guid id);
    Task<List<PartnerEntity>> GetAllAsync();
}