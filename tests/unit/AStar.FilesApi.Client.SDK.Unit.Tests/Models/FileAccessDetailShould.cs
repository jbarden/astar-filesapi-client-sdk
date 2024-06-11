namespace AStar.FilesApi.Client.SDK.Models;

public class FileAccessDetailShould
{
    [Fact]
    public void ReturnTheExpectedToString()
        => new FileAccessDetail().ToString().Should().Be(@"{""Id"":0,""DetailsLastUpdated"":null,""LastViewed"":null,""SoftDeleted"":false,""SoftDeletePending"":false,""NeedsToMove"":false,""HardDeletePending"":false}");
}
