using FluentValidation;
using TicketHub.Application.DTOs;
using TicketHub.Application.Validators;

namespace TicketHub.Application.UseCases;

public class CreateCustomerUseCase
{
    public Domain.Models.Customer Execute(CreateCustomerRequest request)
    {
        var validator = new CustomerValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var customer = new Domain.Models.Customer(request.Name, request.Email, request.Cpf);
        return customer;
    }

  
}