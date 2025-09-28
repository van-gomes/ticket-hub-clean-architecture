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
        var input = new CreatePartnerInput
        {
            Name = "Partner Name",
            Document = "12345678900000"
        };

        var mockRepository = new Mock<IPartnerRepository>();
        mockRepository
            .Setup(r => r.CreateAsync(It.IsAny<PartnerEntity>()))
            .ReturnsAsync((PartnerEntity p) => p);

        var useCase = new CreatePartnerUseCase(mockRepository.Object);
        var response = await useCase.ExecuteAsync(input);

        Assert.Equal(input.Name, response.Name);
        Assert.Equal(input.Document, response.Document);
    }
}