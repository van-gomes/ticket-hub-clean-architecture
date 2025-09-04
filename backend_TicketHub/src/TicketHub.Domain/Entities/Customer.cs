namespace TicketHub.Domain.Entities;

public class Customer
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }

    public Customer(string name, string email, string cpf)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            throw new ArgumentException("Name must be at least 3 characters long.");

        Name = name;
        Email = email;
        Cpf = cpf;
    }
}

