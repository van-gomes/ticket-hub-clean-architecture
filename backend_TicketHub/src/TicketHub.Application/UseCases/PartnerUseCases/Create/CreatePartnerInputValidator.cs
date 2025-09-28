namespace TicketHub.Application.UseCases.PartnerUseCases.Create;

using FluentValidation;

public class CreatePartnerInputValidator : AbstractValidator<CreatePartnerInput>
{
    public CreatePartnerInputValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Document)
            .NotEmpty().WithMessage("Document is required.")
            .Length(14).WithMessage("Document must contain 14 characters.");
    }
}