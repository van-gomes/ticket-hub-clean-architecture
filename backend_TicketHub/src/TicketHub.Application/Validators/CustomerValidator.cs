using FluentValidation;
using TicketHub.Application.DTOs;

namespace TicketHub.Application.Validators
{
    public class CustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("CPF is required.")
                .Length(11).WithMessage("CPF must have exactly 11 digits.")
                .Matches(@"^\d{11}$").WithMessage("CPF must contain only numbers.");
        }
    }
}
