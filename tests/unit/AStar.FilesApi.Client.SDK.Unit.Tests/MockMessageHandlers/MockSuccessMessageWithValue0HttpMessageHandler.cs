using System.Net;

namespace AStar.FilesApi.Client.SDK.MockMessageHandlers;

public class MockSuccessMessageWithValue0HttpMessageHandler : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("0"),
        });
}
