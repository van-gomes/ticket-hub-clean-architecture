using TicketHub.Application.Interfaces;

namespace TicketHub.Application.UseCases.PartnerUseCases.GetById;

public class GetPartnerByIdUseCase
{
    private readonly IPartnerRepository _repository;

    public GetPartnerByIdUseCase(IPartnerRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetPartnerByIdResponse?> ExecuteAsync(Guid id)
    {
        var partner = await _repository.GetByIdAsync(id);
        if (partner is null) return null;

        return new GetPartnerByIdResponse(partner.Id, partner.Name, partner.Document);
    }
}
