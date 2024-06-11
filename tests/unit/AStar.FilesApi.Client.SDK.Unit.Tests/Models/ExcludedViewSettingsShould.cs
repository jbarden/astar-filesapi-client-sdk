namespace AStar.FilesApi.Client.SDK.Models;

public class ExcludedViewSettingsShould
{
    [Fact]
    public void ReturnTheExpectedToString()
        => new ExcludedViewSettings().ToString().Should().Be(@"{""ExcludeViewedPeriodInDays"":7,""ExcludeViewed"":false}");
}
