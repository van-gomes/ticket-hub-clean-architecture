using FluentValidation;
using TicketHub.Application.DTOs;
using TicketHub.Application.UseCases.CustomerUseCases;

namespace Application.IntegrationTests.Customers
{
    public class CreateCustomerUseCaseTests
    {
        [Fact]
        public void Should_ThrowValidationException_When_CpfIsInvalid()
        {
            // Arrange
            var request = new CreateCustomerRequest
            {
                Name = "Maria",
                Email = "maria@email.com",
                Cpf = "123456789" // CPF inválido (9 dígitos)
            };

            // Act & Assert
            var exception = Assert.Throws<ValidationException>(() =>
                CreateCustomerUseCase.Execute(request));

            Assert.Contains("CPF must have exactly 11 digits", exception.Message);
        }

        [Fact]
        public void Should_CreateCustomer_When_RequestIsValid()
        {
            // Arrange
            var request = new CreateCustomerRequest
            {
                Name = "João da Silva",
                Email = "joao@email.com",
                Cpf = "12345678901" // CPF válido (11 dígitos numéricos)
            };

            // Act
            var customer = CreateCustomerUseCase.Execute(request);

            // Assert
            Assert.NotEqual(Guid.Empty, customer.Id); // O ID deve ser gerado
            Assert.Equal(request.Name, customer.Name);
            Assert.Equal(request.Email, customer.Email);
            Assert.Equal(request.Cpf, customer.Cpf);
        }
    }
}