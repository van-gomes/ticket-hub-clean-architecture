using FluentValidation;
using TicketHub.Application.DTOs;

namespace TicketHub.Application.Validators;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("Email is required.");

        RuleFor(c => c.Cpf)
            .NotEmpty()
            .WithMessage("CPF is required.");
    }
}