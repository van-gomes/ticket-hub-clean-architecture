using TicketHub.Application.Interfaces;
using TicketHub.Domain.Models;

namespace TicketHub.Infrastructure.Persistence.Repositories
{
    public class FakeCustomerRepository : ICustomarRepository
    {
        private readonly List<CustomerEntity> _customers = new();

        public Task<CustomerEntity?> GetByIdAsync(Guid id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(customer);
        }

        public Task AddAsync(CustomerEntity customer)
        {
            _customers.Add(customer);
            return Task.CompletedTask;
        }

        public Task<List<CustomerEntity>> GetAllAsync()
        {
            return Task.FromResult(_customers.ToList());
        }
    }
}
        