namespace TicketHub.Domain.Entities
{
    public class Customer
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public Customer(string customerName, string customerEmail, string customerCpf)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Name cannot be empty.");

            if (!IsValidEmail(customerEmail))
                throw new ArgumentException("Email is not valid.");

            if (string.IsNullOrWhiteSpace(customerCpf))
                throw new ArgumentException("CPF cannot be empty.");

            Name = customerName;
            Email = customerEmail;
            Cpf = customerCpf;
        }

        private bool IsValidEmail(string emailToValidate)
        {
            try
            {
                var emailAddress = new System.Net.Mail.MailAddress(emailToValidate);
                return emailAddress.Address == emailToValidate;
            }
            catch
            {
                return false;
            }
        }
    }
}