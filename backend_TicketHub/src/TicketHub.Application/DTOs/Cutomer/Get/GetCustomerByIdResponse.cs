namespace TicketHub.Application.DTOs;

public class GetCustomerByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    
    public GetCustomerByIdResponse(Guid id, string name, string email, string cpf)
    {
        Id = id;
        Name = name;
        Email = email;
        Cpf = cpf;
    }
    
    public GetCustomerByIdResponse() { }
}