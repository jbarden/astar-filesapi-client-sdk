using AStar.FilesApi.Client.SDK.Helpers;
using AStar.FilesApi.Client.SDK.MockMessageHandlers;
using AStar.FilesApi.Client.SDK.Models;

namespace AStar.FilesApi.Client.SDK.FilesApi;

public class FilesApiClientShould
{
    [Fact]
    public async Task ReturnExpectedFailureFromGetHealthAsyncWhenTheApIsiUnreachable()
    {
        var handler = new MockHttpRequestExceptionErrorHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.GetHealthAsync();

        response.Status.Should().Be("Could not get a response from the Files API.");
    }

    [Fact]
    public async Task ReturnExpectedFailureMessageFromGetHealthAsyncWhenCheckFails()
    {
        var sut = ApiClientFactory<FilesApiClient>.CreateInternalServerErrorClient("Health Check failed.");

        var response = await sut.GetHealthAsync();

        response.Status.Should().Be("Health Check failed.");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromGetHealthAsyncWhenCheckSucceeds()
    {
        var handler = new MockSuccessHttpMessageHandler("");
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.GetHealthAsync();

        response.Status.Should().Be("OK");
    }

    [Fact]
    public async Task ReturnExpectedResponseFromTheCountEndpoint()
    {
        var handler = new MockSuccessHttpMessageHandler("Count");
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.GetFilesCountAsync(new SearchParameters());

        response.Should().Be(0);
    }

    [Fact]
    public async Task ReturnExpectedResponseFromTheCountEndpointWhenAnErrorOccurs()
    {
        var handler = new MockInternalServerErrorHttpMessageHandler("Count");
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.GetFilesCountAsync(new SearchParameters());

        response.Should().Be(-1);
    }

    [Fact]
    public async Task ReturnExpectedResponseFromTheCountDuplicatesEndpoint()
    {
        const int MockDuplicatesCountValue = 1234;
        var handler = new MockSuccessHttpMessageHandler("CountDuplicates") { Counter = MockDuplicatesCountValue };
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.GetDuplicateFilesCountAsync(new SearchParameters());

        response.Should().Be(MockDuplicatesCountValue);
    }

    [Fact]
    public async Task ReturnExpectedResponseFromTheCountDuplicatesEndpointWhenAnErrorOccurs()
    {
        var handler = new MockInternalServerErrorHttpMessageHandler("Count");
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.GetDuplicateFilesCountAsync(new SearchParameters());

        response.Should().Be(-1);
    }

    [Fact]
    public async Task ReturnExpectedResponseFromTheListEndpoint()
    {
        var handler = new MockSuccessHttpMessageHandler("ListFiles");
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.GetFilesAsync(new SearchParameters());

        response.Count().Should().Be(2);
    }

    [Fact]
    public async Task ReturnExpectedResponseFromTheListEndpointWhenAnErrorOccurs()
    {
        var handler = new MockHttpRequestExceptionErrorHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        Func<Task> sutMethod = async () => await sut.GetFilesAsync(new SearchParameters());

        await sutMethod.Should().ThrowAsync<HttpRequestException>();
    }

    [Fact]
    public async Task ReturnExpectedResponseFromTheListDuplicatesEndpoint()
    {
        var handler = new MockSuccessHttpMessageHandler("ListDuplicates");
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.GetDuplicateFilesAsync(new SearchParameters());

        response.Count.Should().Be(3);
    }

    [Fact]
    public async Task ReturnExpectedResponseFromTheListDuplicatesEndpointWhenAnErrorOccurs()
    {
        var handler = new MockHttpRequestExceptionErrorHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        Func<Task> sutMethod = async () => await sut.GetDuplicateFilesAsync(new SearchParameters());

        await sutMethod.Should().ThrowAsync<HttpRequestException>();
    }

    [Fact]
    public async Task ReturnExpectedMessageFromMarkForSoftDeletionWhenSuccessful()
    {
        var handler = new MockSuccessHttpMessageHandler("");
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.MarkForSoftDeletionAsync(1);

        response.Should().Be("Marked for soft deletion");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromMarkForSoftDeletionWhenSuccessfulWhenAnErrorOccurs()
    {
        var handler = new MockHttpRequestExceptionErrorHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.MarkForSoftDeletionAsync(1);

        response.Should().Be("Exception of type 'System.Net.Http.HttpRequestException' was thrown.");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromMarkForSoftDeletionWhenFailure()
    {
        var sut = FilesApiClientFactory.CreateInternalServerErrorClient("Delete failed...");

        var response = await sut.MarkForSoftDeletionAsync(1);

        response.Should().Be("Delete failed...");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromUndoMarkForSoftDeletionWhenFailure()
    {
        var sut = FilesApiClientFactory.CreateInternalServerErrorClient("Undo mark for deletion failed...");

        var response = await sut.UndoMarkForSoftDeletionAsync(1);

        response.Should().Be("Undo mark for deletion failed...");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromUndoMarkForSoftDeletionWhenSuccessful()
    {
        var handler = new MockDeletionSuccessHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.UndoMarkForSoftDeletionAsync(1);

        response.Should().Be("Mark for soft deletion has been undone");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromUndoMarkForSoftDeletionWhenAnErrorOccurs()
    {
        var handler = new MockHttpRequestExceptionErrorHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.UndoMarkForSoftDeletionAsync(1);

        response.Should().Be("Exception of type 'System.Net.Http.HttpRequestException' was thrown.");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromMarkForHardDeletionWhenSuccessful()
    {
        var handler = new MockDeletionSuccessHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.MarkForHardDeletionAsync(1);

        response.Should().Be("Marked for hard deletion.");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromMarkForHardDeletionWhenAnErrorOccurs()
    {
        var handler = new MockHttpRequestExceptionErrorHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.MarkForHardDeletionAsync(1);

        response.Should().Be("Exception of type 'System.Net.Http.HttpRequestException' was thrown.");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromMarkForHardDeletionWhenFailure()
    {
        var sut = FilesApiClientFactory.CreateInternalServerErrorClient("Delete failed...");

        var response = await sut.MarkForHardDeletionAsync(1);

        response.Should().Be("Delete failed...");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromUndoMarkForHardDeletionWhenSuccessful()
    {
        var handler = new MockSuccessHttpMessageHandler("");
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.UndoMarkForHardDeletionAsync(1);

        response.Should().Be("Mark for hard deletion has been undone");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromUndoMarkForHardDeletionWhenAnErrorOccurs()
    {
        var handler = new MockHttpRequestExceptionErrorHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.UndoMarkForHardDeletionAsync(1);

        response.Should().Be("Exception of type 'System.Net.Http.HttpRequestException' was thrown.");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromUndoMarkForHardDeletionWhenFailure()
    {
        var sut = FilesApiClientFactory.CreateInternalServerErrorClient("Undo mark for deletion failed...");

        var response = await sut.UndoMarkForHardDeletionAsync(1);

        response.Should().Be("Undo mark for deletion failed...");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromMarkForMovingWhenSuccessful()
    {
        var handler = new MockDeletionSuccessHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.MarkForMovingAsync(1);

        response.Should().Be("Mark for moving was successful");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromMarkForMovingWhenAnErrorOccurs()
    {
        var handler = new MockHttpRequestExceptionErrorHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.MarkForMovingAsync(1);

        response.Should().Be("Exception of type 'System.Net.Http.HttpRequestException' was thrown.");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromMarkForMovingWhenFailure()
    {
        var sut = FilesApiClientFactory.CreateInternalServerErrorClient("Delete failed...");

        var response = await sut.MarkForMovingAsync(1);

        response.Should().Be("Delete failed...");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromUndoMarkForMovingWhenSuccessful()
    {
        var handler = new MockSuccessHttpMessageHandler("");
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.UndoMarkForMovingAsync(1);

        response.Should().Be("Undo mark for moving was successful");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromUndoMarkForMovingWhenAnErrorOccurs()
    {
        var handler = new MockHttpRequestExceptionErrorHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.UndoMarkForMovingAsync(1);

        response.Should().Be("Exception of type 'System.Net.Http.HttpRequestException' was thrown.");
    }

    [Fact]
    public async Task ReturnExpectedMessageFromUndoMarkForMovingWhenFailure()
    {
        var sut = FilesApiClientFactory.CreateInternalServerErrorClient("Undo mark for deletion failed...");

        var response = await sut.UndoMarkForMovingAsync(1);

        response.Should().Be("Undo mark for deletion failed...");
    }

    [Fact]
    public async Task ReturnExpectedResponseFromThGetFileAccessDetailWhenAnErrorOccurs()
    {
        var handler = new MockHttpRequestExceptionErrorHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        Func<Task> sutMethod = async () => await sut.GetFileAccessDetail(1);

        await sutMethod.Should().ThrowAsync<HttpRequestException>();
    }

    [Fact]
    public async Task ReturnExpectedResponseFromTheGetFileAccessDetailEndpoint()
    {
        const int mockFileId = 123456789;
        var handler = new MockSuccessHttpMessageHandler("FileAccessDetail");
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.GetFileAccessDetail(mockFileId);

        response.Id.Should().Be(mockFileId);
    }

    [Fact]
    public async Task ReturnExpectedResponseFromThGetFileDetailWhenAnErrorOccurs()
    {
        var handler = new MockHttpRequestExceptionErrorHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        Func<Task> sutMethod = async () => await sut.GetFileDetail(1);

        await sutMethod.Should().ThrowAsync<HttpRequestException>();
    }

    [Fact]
    public async Task ReturnExpectedResponseFromTheGetFileDetailEndpoint()
    {
        var handler = new MockSuccessHttpMessageHandler("FileDetail");
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.GetFileDetail(1);

        response.Name.Should().Be("Test File Name");
    }

    [Fact]
    public async Task ReturnExpectedResponseFromTheUpdateFileAsyncWhenAnErrorOccurs()
    {
        var handler = new MockHttpRequestExceptionErrorHttpMessageHandler();
        var sut = FilesApiClientFactory.Create(handler);

        Func<Task> sutMethod = async () => await sut.UpdateFileAsync(new());

        await sutMethod.Should().ThrowAsync<HttpRequestException>();
    }

    [Fact]
    public async Task ReturnExpectedResponseFromTheUpdateFileAsyncEndpoint()
    {
        var handler = new MockSuccessHttpMessageHandler("FileDetail");
        var sut = FilesApiClientFactory.Create(handler);

        var response = await sut.UpdateFileAsync(new());

        response.Should().Be("The file details were updated successfully");
    }
}
