using FluentValidation;
using TicketHub.Application.Validators;
using TicketHub.Domain.Entities;

namespace TicketHub.Application.UseCases;

public class CreateCustomerUseCase
{
    public Customer Execute(string name, string email, string cpf)
    {
        var customer = new Customer(name, email, cpf);

        var validator = new CustomerValidator();
        var validationResult = validator.Validate(customer);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return customer;
    }
}