using FluentValidation;
using TicketHub.Application.DTOs;
using TicketHub.Application.UseCases.CustomerUseCases.Create;
using TicketHub.Infrastructure.Persistence.Repositories;

namespace Application.IntegrationTests.Customers
{
    public class CreateCustomerUseCaseTests
    {
        private readonly CreateCustomerUseCase _useCase;

        public CreateCustomerUseCaseTests()
        {
            // Usa o repositório fake (sem precisar de banco de dados)
            var repository = new FakeCustomerRepository();
            _useCase = new CreateCustomerUseCase(repository);
        }

        [Fact]
        public async Task Should_ThrowValidationException_When_CpfIsInvalid()
        {
            // Arrange
            var request = new CreateCustomerRequest
            {
                Name = "Maria",
                Email = "maria@email.com",
                Cpf = "123456789" // CPF inválido (9 dígitos)
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(() =>
                _useCase.ExecuteAsync(request));

            Assert.Contains("CPF must have exactly 11 digits", 
                exception.Errors.First().ErrorMessage);
        }

        [Fact]
        public async Task Should_CreateCustomer_When_RequestIsValid()
        {
            // Arrange
            var request = new CreateCustomerRequest
            {
                Name = "João da Silva",
                Email = "joao@email.com",
                Cpf = "12345678901" // CPF válido
            };

            // Act
            var customer = await _useCase.ExecuteAsync(request);

            // Assert
            Assert.NotNull(customer);
            Assert.NotEqual(Guid.Empty, customer.Id);
            Assert.Equal(request.Name, customer.Name);
            Assert.Equal(request.Email, customer.Email);
            Assert.Equal(request.Cpf, customer.Cpf);
        }
    }
}