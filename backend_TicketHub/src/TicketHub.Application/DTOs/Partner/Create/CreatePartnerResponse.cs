namespace TicketHub.Application.UseCases.PartnerUseCases.Create;

public class CreatePartnerResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;

    public CreatePartnerResponse() { }

    public CreatePartnerResponse(Guid id, string name, string document)
    {
        Id = id;
        Name = name;
        Document = document;
    }
}
