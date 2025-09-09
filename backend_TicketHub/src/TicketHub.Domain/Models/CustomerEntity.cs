namespace TicketHub.Domain.Models;

public class CustomerEntity
{
    public Guid Id { get; private set; } // ✅ Chave primária exigida pelo EF
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }

    public CustomerEntity(string name, string email, string cpf)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            throw new ArgumentException("Name must be at least 3 characters long.");

        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Cpf = cpf;
    }
}



