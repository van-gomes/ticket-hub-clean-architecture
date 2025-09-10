using Moq;
using TicketHub.Application.Interfaces;
using TicketHub.Application.UseCases.Customer.GetById;
using TicketHub.Domain.Models;

namespace TicketHub.UnitTests.UseCases.CustomerTests;

public class GetCustomerByIdUseCaseTests
{
    [Fact]
    public async Task ExecuteAsync_ShouldReturnCustomer_WhenCustomerExists()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var expectedCustomer = new CustomerEntity("Nome Teste", "teste@email.com", "123.456.789-00");
        typeof(CustomerEntity).GetProperty("Id")?.SetValue(expectedCustomer, customerId);

        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(r => r.GetByIdAsync(customerId)).ReturnsAsync(expectedCustomer);

        var useCase = new GetCustomerByIdUseCase(mockRepository.Object);

        // Act
        var result = await useCase.ExecuteAsync(customerId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(customerId, result.Id);
        Assert.Equal(expectedCustomer.Name, result.Name);
        Assert.Equal(expectedCustomer.Email, result.Email);
        Assert.Equal(expectedCustomer.Cpf, result.Cpf);
    }

    [Fact]
    public async Task ExecuteAsync_ShouldReturnNull_WhenCustomerDoesNotExist()
    {
        // Arrange
        var customerId = Guid.NewGuid();

        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(r => r.GetByIdAsync(customerId)).ReturnsAsync((CustomerEntity?)null);

        var useCase = new GetCustomerByIdUseCase(mockRepository.Object);

        // Act
        var result = await useCase.ExecuteAsync(customerId);

        // Assert
        Assert.Null(result);
    }
}