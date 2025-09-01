namespace TicketHub.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; }
    public string Email { get; }
    public string Cpf { get; }

    public Customer(string name, string email, string cpf)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Cpf = cpf;
    }
}