using TicketHub.Domain.Models;
using TicketHub.Infrastructure.Persistence.Repositories;

namespace Application.IntegrationTests.Customers
{
    public class FakeCustomerRepositoryTests
    {
        private readonly FakeCustomerRepository _repository;

        public FakeCustomerRepositoryTests()
        {
            _repository = new FakeCustomerRepository();
        }

        [Fact]
        public async Task CreateAsync_ShouldAddAndReturnCustomer()
        {
            // Arrange
            var customer = new CustomerEntity
            {
                Name = "João da Silva",
                Email = "joao@email.com"
            };

            // Act
            var created = await _repository.CreateAsync(customer);
            var fetched = await _repository.GetByIdAsync(created.Id);

            // Assert
            Assert.NotNull(created.Id);
            Assert.NotNull(fetched);
            Assert.Equal("João da Silva", fetched?.Name);
            Assert.Equal("joao@email.com", fetched?.Email);
        }
    }
}