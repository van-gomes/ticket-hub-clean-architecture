using TicketHub.Domain.Models;

namespace TicketHub.Application.Interfaces;

public interface ICustomarRepository
{
    Task<CustomerEntity?> GetByIdAsync(Guid id);
    Task<List<CustomerEntity>> GetAllAsync();
    Task AddAsync(CustomerEntity customerEntity);
}