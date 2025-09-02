using Moq;
using TicketHub.Domain.Entities;
using TicketHub.Application.UseCases;
using TicketHub.Application.Interfaces;
using TicketHub.Application.DTOs;

public class CreateCustomerUseCaseTests
{
    [Fact]
    public async Task Should_Create_Customer_Successfully()
    {
        // Arrange
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var createCustomerUseCase = new CreateCustomerUseCase(customerRepositoryMock.Object);

        var request = new CreateCustomerRequest
        {
            Name = "Alice",
            Email = "alice@email.com",
            Cpf = "12345678911"
        };

        // Act
        var createdCustomer = await createCustomerUseCase.Execute(request);

        // Assert
        Assert.Equal(request.Name, createdCustomer.Name);
        Assert.Equal(request.Email, createdCustomer.Email);
        Assert.Equal(request.Cpf, createdCustomer.Cpf);
        customerRepositoryMock.Verify(repo => repo.SaveAsync(It.IsAny<Customer>()), Times.Once);
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Name_Is_Empty()
    {
        // Arrange
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var createCustomerUseCase = new CreateCustomerUseCase(customerRepositoryMock.Object);

        var request = new CreateCustomerRequest
        {
            Name = "",
            Email = "alice@email.com",
            Cpf = "12345678911"
        };

        // Act & Assert
        await Assert.ThrowsAsync<FluentValidation.ValidationException>(async () =>
        {
            await createCustomerUseCase.Execute(request);
        });

        customerRepositoryMock.Verify(repo => repo.SaveAsync(It.IsAny<Customer>()), Times.Never);
    }
}