using TicketHub.Application.Interfaces;

namespace TicketHub.Application.UseCases.PartnerUseCases.GetById;

public class GetAllPartnersUseCase
{
    private readonly IPartnerRepository _repository;

    public GetAllPartnersUseCase(IPartnerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetPartnerByIdResponse>> ExecuteAsync()
    {
        var partners = await _repository.GetAllAsync();

        return partners.Select(p => new GetPartnerByIdResponse(
            p.Id,
            p.Name,
            p.Document
        )).ToList();
    }
}