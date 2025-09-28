namespace TicketHub.Application.UseCases.PartnerUseCases.Create;

public class CreatePartnerInput
{
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    
    public CreatePartnerInput() { }
    
    public CreatePartnerInput(string name, string document)
    {
        Name = name;
        Document = document;
    }
}