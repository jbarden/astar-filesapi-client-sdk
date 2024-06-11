namespace AStar.FilesApi.Client.SDK.Models;

public class SearchParametersShould
{
    [Fact]
    public void ReturnTheExpectedToString()
        => new SearchParameters().ToString().Should().Be(@"{""SearchFolder"":"""",""SearchType"":0,""Recursive"":true,""CurrentPage"":1,""ItemsPerPage"":10,""MaximumSizeOfThumbnail"":850,""MaximumSizeOfImage"":1500,""SortOrder"":0,""SearchText"":null,""ExcludedViewSettings"":{""ExcludeViewedPeriodInDays"":7,""ExcludeViewed"":false}}");

    [Fact]
    public void ReturnTheExpectedToQueryString()
        => new SearchParameters().ToQueryString().Should().Be("SearchFolder=&CurrentPage=1&ItemsPerPage=10&SearchType=Images&Recursive=True&ExcludeViewed=False&SortOrder=SizeDescending&MaximumSizeOfThumbnail=850&MaximumSizeOfImage=1500&ExcludeViewedPeriodInDays=7&SearchText=");
}
