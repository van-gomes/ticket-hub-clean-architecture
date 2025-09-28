using System;
using System.Threading.Tasks;
using Moq;
using TicketHub.Application.Interfaces;
using TicketHub.Application.UseCases.PartnerUseCases.GetById;
using TicketHub.Domain.Models;
using Xunit;

namespace TicketHub.UnitTests.UseCases.PartnerTests;

public class GetPartnerByIdUseCaseTests
{
    [Fact]
    public async Task Should_Return_Null_When_Partner_Not_Exists()
    {
        var mockRepository = new Mock<IPartnerRepository>();
        mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((PartnerEntity?)null);

        var useCase = new GetPartnerByIdUseCase(mockRepository.Object);
        var result = await useCase.ExecuteAsync(Guid.NewGuid());

        Assert.Null(result);
    }

    [Fact]
    public async Task Should_Return_Partner_When_Exists()
    {
        // Arrange
        var id = Guid.NewGuid();
        var partner = new PartnerEntity(id, "ACME Corp", "12345678901234");

        var mockRepository = new Mock<IPartnerRepository>();
        mockRepository.Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync(partner);

        var useCase = new GetPartnerByIdUseCase(mockRepository.Object);

        // Act
        var result = await useCase.ExecuteAsync(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal("ACME Corp", result.Name);
        Assert.Equal("12345678901234", result.Document);
    }
}