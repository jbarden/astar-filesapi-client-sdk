using AStar.FilesApi.Client.SDK.MockMessageHandlers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AStar.FilesApi.Client.SDK.Helpers;

internal static class FilesApiClientFactory
{
    private static readonly ILogger<FilesApi.FilesApiClient> DummyLogger = NullLogger<FilesApi.FilesApiClient>.Instance;
    private static readonly string IrrelevantUrl = "https://doesnot.matter.com";

    public static FilesApi.FilesApiClient Create(HttpMessageHandler mockHttpMessageHandler)
    {
        var httpClient = new HttpClient(mockHttpMessageHandler)
        {
            BaseAddress = new(IrrelevantUrl)
        };

        return new FilesApi.FilesApiClient(httpClient, DummyLogger);
    }

    public static FilesApi.FilesApiClient CreateInternalServerErrorClient(string errorMessage)
    {
        var handler = new MockInternalServerErrorHttpMessageHandler(errorMessage);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new(IrrelevantUrl)
        };

        return new FilesApi.FilesApiClient(httpClient, DummyLogger);
    }
}
