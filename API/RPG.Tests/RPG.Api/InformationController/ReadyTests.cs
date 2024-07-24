using FluentAssertions;
using System.Net;

namespace RPG.Tests.RPG.Api.InformationController;

public class ReadyTests : ApiTestFixture
{
    [Fact]
    public async Task Ready_ReturnsOk()
    {
        // Act
        var response = await Client.GetAsync($"{InformationUri}/ready");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
