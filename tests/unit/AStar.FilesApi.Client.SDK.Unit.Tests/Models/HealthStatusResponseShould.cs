using AStar.Api.HealthChecks;

namespace AStar.FilesApi.Client.SDK.Models;

public class HealthStatusResponseShould
{
    [Fact]
    public void ReturnTheExpectedToString()
                        => new HealthStatusResponse().ToString().Should().Be(@"{""Status"":""Unknown""}");
}
