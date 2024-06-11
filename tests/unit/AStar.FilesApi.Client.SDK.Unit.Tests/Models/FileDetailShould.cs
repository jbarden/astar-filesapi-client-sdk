namespace AStar.FilesApi.Client.SDK.Models;

public class FileDetailShould
{
    [Fact]
    public void ReturnTheExpectedToString()
        => new FileDetail().ToString().Should().Be(@"{""Id"":0,""Name"":""Not Set"",""FullName"":""Not Set"",""DirectoryName"":"""",""Height"":0,""Width"":0,""Size"":0,""SizeForDisplay"":""0.00 Kb""}");
}
