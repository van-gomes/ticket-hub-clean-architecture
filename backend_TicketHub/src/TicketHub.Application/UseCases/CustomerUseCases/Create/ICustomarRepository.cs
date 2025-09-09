using TicketHub.Domain.Models;
using TicketHub.Domain.Models;

namespace TicketHub.Application.Interfaces;

public interface ICustomerRepository
{
    Task<CustomerEntity?> GetByIdAsync(Guid id);
    Task AddAsync(CustomerEntity customerEntity);
}