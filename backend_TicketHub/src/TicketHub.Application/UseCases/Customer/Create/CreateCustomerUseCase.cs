using TicketHub.Domain.Entities;
using TicketHub.Application.Interfaces;

namespace TicketHub.Application.UseCases;

public class CreateCustomerUseCase
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Execute(string name, string email, string cpf)
    {
        var customer = new Customer(name, email, cpf);
        await _repository.SaveAsync(customer);
        return customer;
    }
}