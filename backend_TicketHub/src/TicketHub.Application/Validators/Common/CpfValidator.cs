namespace TicketHub.Application.Validators.Common;

public static class CpfValidator
{
    public static bool IsValid(string cpf)
    {
        return !string.IsNullOrWhiteSpace(cpf) && cpf.All(char.IsDigit) && cpf.Length == 11;
    }
}