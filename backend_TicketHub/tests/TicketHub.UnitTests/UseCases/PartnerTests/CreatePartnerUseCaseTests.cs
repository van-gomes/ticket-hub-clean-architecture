using System;
using System.Threading.Tasks;
using Moq;
using TicketHub.Application.Interfaces;
using TicketHub.Application.UseCases.PartnerUseCases.Create;
using TicketHub.Domain.Models;
using Xunit;

namespace TicketHub.UnitTests.UseCases.PartnerTests;

public class CreatePartnerUseCaseTests
{
    [Fact]
    public async Task Should_Create_Partner_Successfully()
    {
        // Arrange
        var input = new CreatePartnerInput
        {
            Name = "Partner Name",
            Document = "12345678900000"
        };

        var expectedId = Guid.NewGuid();
        var expectedEntity = new PartnerEntity(expectedId, input.Name, input.Document);

        var mockRepository = new Mock<IPartnerRepository>();
        mockRepository
            .Setup(r => r.CreateAsync(It.IsAny<PartnerEntity>()))
            .ReturnsAsync(expectedEntity);

        var useCase = new CreatePartnerUseCase(mockRepository.Object);

        // Act
        var response = await useCase.ExecuteAsync(input);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(expectedId, response.Id);
        Assert.Equal(input.Name, response.Name);
        Assert.Equal(input.Document, response.Document);
    }
}