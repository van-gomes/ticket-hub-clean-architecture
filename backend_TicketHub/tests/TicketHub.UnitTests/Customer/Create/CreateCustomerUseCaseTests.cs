using Moq;
using TicketHub.Domain.Entities;
using TicketHub.Application.UseCases;
using TicketHub.Application.Interfaces;

public class CreateCustomerUseCaseTests
{
    [Fact]
    public async Task Should_Create_Customer_Successfully()
    {
        // Arrange
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var createCustomerUseCase = new CreateCustomerUseCase(customerRepositoryMock.Object);

        var expectedName = "Alice";
        var expectedEmail = "alice@email.com";
        var expectedCpf = "123456789";

        // Act
        var createdCustomer = await createCustomerUseCase.Execute(expectedName, expectedEmail, expectedCpf);

        // Assert
        Assert.Equal(expectedName, createdCustomer.Name);
        Assert.Equal(expectedEmail, createdCustomer.Email);
        Assert.Equal(expectedCpf, createdCustomer.Cpf);
        customerRepositoryMock.Verify(repository => repository.SaveAsync(It.IsAny<Customer>()), Times.Once);
    }
}
