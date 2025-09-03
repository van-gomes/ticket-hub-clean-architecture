namespace TicketHub.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }

    public Customer(string name, string email, string cpf)
    {
        Name = name;
        Email = email;
        Cpf = cpf;
    }
    
    public void ChangeEmail(string newEmail)
    {
        Email = newEmail;
    }

    public void ChangeName(string newName)
    {
        Name = newName;
    }
}