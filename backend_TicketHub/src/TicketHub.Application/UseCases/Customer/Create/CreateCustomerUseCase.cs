using FluentValidation;
using TicketHub.Application.DTOs;
using TicketHub.Application.Validators;
using TicketHub.Domain.Entities;

namespace TicketHub.Application.UseCases;

public class CreateCustomerUseCase
{
    public Customer Execute(CreateCustomerRequest request)
    {
        var validator = new CustomerValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var customer = new Customer(request.Name, request.Email, request.Cpf);
        return customer;
    }
}