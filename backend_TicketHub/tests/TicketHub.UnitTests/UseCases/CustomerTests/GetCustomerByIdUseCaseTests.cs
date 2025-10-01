using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using TicketHub.Application.Interfaces;
using TicketHub.Application.UseCases.CustomerUseCases.GetAll;
using TicketHub.Application.UseCases.CustomerUseCases.GetById;
using TicketHub.Domain.Models;
using Xunit;

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
    
    [Fact]
    public async Task ExecuteAsync_ShouldReturnAllCustomers()
    {
        // Arrange
        var customer1 = new CustomerEntity("João", "joao@email.com", "123.456.789-00");
        var customer2 = new CustomerEntity("Maria", "maria@email.com", "987.654.321-00");

        var customersList = new List<CustomerEntity> { customer1, customer2 };

        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(customersList);

        var useCase = new GetAllCustomersUseCase(mockRepository.Object);

        // Act
        var result = await useCase.ExecuteAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, c => c.Name == "João" && c.Email == "joao@email.com");
        Assert.Contains(result, c => c.Name == "Maria" && c.Cpf == "987.654.321-00");
    }

    [Fact]
    public async Task ExecuteAsync_ShouldReturnEmptyList_WhenNoCustomers()
    {
        // Arrange
        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<CustomerEntity>());

        var useCase = new GetAllCustomersUseCase(mockRepository.Object);

        // Act
        var result = await useCase.ExecuteAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }
}