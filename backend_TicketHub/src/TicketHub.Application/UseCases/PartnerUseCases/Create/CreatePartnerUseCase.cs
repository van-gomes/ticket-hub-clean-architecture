using TicketHub.Application.Interfaces;
using TicketHub.Domain.Models;

namespace TicketHub.Application.UseCases.PartnerUseCases.Create;

public class CreatePartnerUseCase
{
    private readonly IPartnerRepository _repository;

    public CreatePartnerUseCase(IPartnerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreatePartnerResponse> ExecuteAsync(CreatePartnerInput input)
    {
       
        var entity = new PartnerEntity(
            Guid.NewGuid(),
            input.Name,
            input.Document
        );

        var result = await _repository.CreateAsync(entity);

        return new CreatePartnerResponse
        {
            Id = result.Id,
            Name = result.Name,
            Document = result.Document
        };
    }
}
