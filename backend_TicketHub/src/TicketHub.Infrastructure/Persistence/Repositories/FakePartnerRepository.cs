using TicketHub.Application.Interfaces;
using TicketHub.Domain.Models;

namespace TicketHub.Infrastructure.Persistence.Repositories
{
    public class FakePartnerRepository : IPartnerRepository
    {
        // Lista em memória simulando um banco de dados
        private readonly List<PartnerEntity> _partners = new();

        public Task<PartnerEntity> CreateAsync(PartnerEntity partner)
        {
            // Adiciona o parceiro à lista
            _partners.Add(partner);

            // Retorna o parceiro criado (como Task simulando operação assíncrona)
            return Task.FromResult(partner);
        }

        public Task<PartnerEntity?> GetByIdAsync(Guid id)
        {
            // Busca pelo ID
            var partner = _partners.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(partner);
        }

        public Task<List<PartnerEntity>> GetAllAsync()
        {
            // Retorna todos os parceiros
            return Task.FromResult(_partners.ToList());
        }
    }
}