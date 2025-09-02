using TicketHub.Domain.Entities;
using TicketHub.Application.Interfaces;
using TicketHub.Application.DTOs;
using TicketHub.Application.Validators;
using FluentValidation;

namespace TicketHub.Application.UseCases;

public class CreateCustomerUseCase
{
    private readonly ICustomerRepository _repository;
    private readonly CreateCustomerRequestValidator _validator;

    public CreateCustomerUseCase(ICustomerRepository repository)
    {
        _repository = repository;
        _validator = new CreateCustomerRequestValidator();
    }

    public async Task<Customer> Execute(CreateCustomerRequest request)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException(errors);
        }

        var customer = new Customer(request.Name, request.Email, request.Cpf);
        await _repository.SaveAsync(customer);
        return customer;
    }
}