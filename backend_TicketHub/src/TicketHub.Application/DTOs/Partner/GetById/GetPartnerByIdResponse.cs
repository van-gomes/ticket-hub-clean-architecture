namespace TicketHub.Application.UseCases.PartnerUseCases.GetById;

public class GetPartnerByIdResponse
{
    public Guid Id { get; }
    public string Name { get; }
    public string Document { get; }

    public GetPartnerByIdResponse(Guid id, string name, string document)
    {
        Id = id;
        Name = name;
        Document = document;
    }
}
