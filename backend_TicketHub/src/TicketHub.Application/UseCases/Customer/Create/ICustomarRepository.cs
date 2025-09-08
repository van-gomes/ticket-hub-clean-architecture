using TicketHub.Domain.Models;
using TicketHub.Domain.Models;

namespace TicketHub.Application.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(Guid id);
    Task AddAsync(Customer customer);
}