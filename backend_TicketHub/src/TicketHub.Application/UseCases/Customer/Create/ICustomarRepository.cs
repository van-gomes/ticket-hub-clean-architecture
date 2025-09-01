using TicketHub.Domain.Entities;

namespace TicketHub.Application.Interfaces;

public interface ICustomerRepository
{
    Task SaveAsync(Customer customer);
}