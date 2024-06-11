using System;

namespace AStar.FilesApi.Client.SDK.Models;

public class SortOrderShould
{
    [Fact]
    public void ContainTheExpectedSizeDescendingValue()
        => Enum.IsDefined(typeof(SortOrder), 0).Should().BeTrue();

    [Fact]
    public void ContainTheExpectedSizeAscendingValue()
        => Enum.IsDefined(typeof(SortOrder), 1).Should().BeTrue();

    [Fact]
    public void ContainTheExpectedNameDescendingValue()
        => Enum.IsDefined(typeof(SortOrder), 2).Should().BeTrue();

    [Fact]
    public void ContainTheExpectedNameAscendingValue()
        => Enum.IsDefined(typeof(SortOrder), 3).Should().BeTrue();

    [Fact]
    public void ContainTheExpectedCountOfDefinedValues()
        => Enum.GetNames(typeof(SortOrder)).Length.Should().Be(4);
}
