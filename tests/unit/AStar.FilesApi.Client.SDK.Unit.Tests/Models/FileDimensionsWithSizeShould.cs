namespace AStar.FilesApi.Client.SDK.Models;

public class FileDimensionsWithSizeShould
{
    [Fact]
    public void ReturnTheExpectedToString()
        => new FileDimensionsWithSize().ToString().Should().Be(@"{""FileLength"":0,""Height"":0,""Width"":0,""FileSizeForDisplay"":""0.00 Kb""}");
}
