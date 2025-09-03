using FluentValidation;
using TicketHub.Application.Validators.Common;
using TicketHub.Domain.Entities;

namespace TicketHub.Application.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage("Name must be at least 3 characters.");

        RuleFor(c => c.Email)
            .Must(EmailValidator.IsValid)
            .WithMessage("Email format is invalid.");

        RuleFor(c => c.Cpf)
            .Must(BeValidCpf)
            .WithMessage("CPF must be 11 digits.");
    }

    private bool BeValidCpf(string cpf) =>
        !string.IsNullOrWhiteSpace(cpf) && cpf.Length == 11;
}