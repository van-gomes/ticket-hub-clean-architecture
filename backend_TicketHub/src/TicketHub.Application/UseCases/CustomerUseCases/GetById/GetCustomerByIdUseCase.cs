using TicketHub.Application.DTOs;
using TicketHub.Application.Interfaces;

namespace TicketHub.Application.UseCases.Customer.GetById;

public class GetCustomerByIdUseCase
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByIdUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetCustomerByIdResponse?> ExecuteAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id);
        if (customer == null)
        {
            return null;
        }

        return new GetCustomerByIdResponse
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            Cpf = customer.Cpf
        };
    }
}