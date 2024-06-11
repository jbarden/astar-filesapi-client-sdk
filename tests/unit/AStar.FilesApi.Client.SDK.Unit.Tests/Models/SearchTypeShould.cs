namespace AStar.FilesApi.Client.SDK.Models;

public class SearchTypeShould
{
    [Fact]
    public void ContainTheExpectedImagesValue()
        => Enum.IsDefined(typeof(SearchType), 0).Should().BeTrue();

    [Fact]
    public void ContainTheExpectedAllValue()
        => Enum.IsDefined(typeof(SearchType), 1).Should().BeTrue();

    [Fact]
    public void ContainTheExpectedDuplicatesValue()
        => Enum.IsDefined(typeof(SearchType), 2).Should().BeTrue();

    [Fact]
    public void ContainTheExpectedCountOfDefinedValues()
        => Enum.GetNames(typeof(SearchType)).Length.Should().Be(3);
}
