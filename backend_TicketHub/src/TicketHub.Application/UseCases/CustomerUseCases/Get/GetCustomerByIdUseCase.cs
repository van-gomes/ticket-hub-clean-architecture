using TicketHub.Application.DTOs;
using TicketHub.Application.Interfaces;

namespace TicketHub.Application.UseCases.CustomerUseCases.GetById;

public class GetCustomerByIdUseCase
{
    private readonly  ICustomarRepository _repository;

    public GetCustomerByIdUseCase(ICustomarRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetCustomerByIdResponse?> ExecuteAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id);
        if (customer is null) return null;

        return new GetCustomerByIdResponse(customer.Id, customer.Name, customer.Email, customer.Cpf);
    }
}