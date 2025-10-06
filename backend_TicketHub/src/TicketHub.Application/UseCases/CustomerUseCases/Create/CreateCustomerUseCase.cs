using TicketHub.Application.DTOs;
using TicketHub.Application.Interfaces;
using TicketHub.Application.Validators;
using TicketHub.Domain.Models;
using FluentValidation;

namespace TicketHub.Application.UseCases.CustomerUseCases.Create;

public class CreateCustomerUseCase
{
    private readonly ICustomarRepository _repository;
    private readonly CreateCustomerRequestValidator _validator;

    public CreateCustomerUseCase(ICustomarRepository repository)
    {
        _repository = repository;
        _validator = new CreateCustomerRequestValidator(); // instancia o validador
    }

    public async Task<CustomerEntity> ExecuteAsync(CreateCustomerRequest request)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var entity = new CustomerEntity(request.Name, request.Email, request.Cpf);
        await _repository.AddAsync(entity);
        return entity;
    }
}