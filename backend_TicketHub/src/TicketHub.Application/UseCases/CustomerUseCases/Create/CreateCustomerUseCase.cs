using FluentValidation;
using TicketHub.Application.DTOs;
using TicketHub.Application.Validators;
using TicketHub.Domain.Models;

namespace TicketHub.Application.UseCases.CustomerUseCases;

public class CreateCustomerUseCase
{
    public static CustomerEntity Execute(CreateCustomerRequest request)
    {
        var validator = new CustomerValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var customer = new CustomerEntity(request.Name, request.Email, request.Cpf);
        return customer;
    }
}