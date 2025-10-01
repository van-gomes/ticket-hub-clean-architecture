using TicketHub.Application.DTOs;
using TicketHub.Application.Interfaces;

namespace TicketHub.Application.UseCases.CustomerUseCases.GetAll;

public class GetAllCustomersUseCase
{
    private readonly ICustomerRepository _repository;

    public GetAllCustomersUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCustomerByIdResponse>> ExecuteAsync()
    {
        var customers = await _repository.GetAllAsync();
        return customers.Select(c => new GetCustomerByIdResponse(c.Id, c.Name, c.Email, c.Cpf)).ToList();
    }
}