using TicketHub.Application.DTOs;
using TicketHub.Application.Interfaces;
using TicketHub.Domain.Models;

namespace TicketHub.Application.UseCases.CustomerUseCases.Create;

public class CreateCustomerUseCase
{
    private readonly ICustomarRepository _repository;

    public CreateCustomerUseCase(ICustomarRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerEntity> ExecuteAsync(CreateCustomerRequest request)
    {
        var entity = new CustomerEntity(request.Name, request.Email, request.Cpf);
        await _repository.AddAsync(entity);
        return entity;
    }
}