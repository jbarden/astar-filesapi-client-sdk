namespace AStar.FilesApi.Client.SDK.Models;

public class DirectoryChangeRequestShould
{
    [Fact]
    public void ReturnTheExpectedToString()
        => new DirectoryChangeRequest().ToString().Should().Be(@"{""OldDirectoryName"":"""",""NewDirectoryName"":"""",""FileName"":""""}");
}
