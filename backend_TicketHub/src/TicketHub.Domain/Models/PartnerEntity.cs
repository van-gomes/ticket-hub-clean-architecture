namespace TicketHub.Domain.Models;

public class PartnerEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Document { get; private set; } = string.Empty;

    public PartnerEntity(Guid id, string name, string document)
    {
        Id = id;
        Name = name;
        Document = document;
    }
}